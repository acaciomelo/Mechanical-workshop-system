using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class OrcamentoDAO
    {
        Database db = new GenericDatabase((Global.ConnectionStringUser == string.Empty ? Global.ConnectionStringPg : Global.ConnectionStringUser), PgSqlProviderFactory.Instance);
        DbCommand dbCommand = null;

        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para OrcamentoDAO.
        /// </summary>
        public OrcamentoDAO()
        { }

        /// <summary>
        /// Instância para OrcamentoDAO com controle de transação.
        /// </summary>

        public List<OrcamentoDTO> GetGridOrcamento(string campo, string valorPesquisa)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("getgridorcamento");
                db.AddInParameter(dbCommand, "campo", DbType.String, campo);
                db.AddInParameter(dbCommand, "valorPesquisa", DbType.String, valorPesquisa);
                db.AddInParameter(dbCommand, "mesanoativo", DbType.Date, Global.MesanoAtivo);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    List<OrcamentoDTO> List = new List<OrcamentoDTO>();
                    while (DR.Read())
                    {
                        OrcamentoDTO tab = new OrcamentoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Cliente = new ClienteDAO().GetCliente(int.Parse(DR["id_cliente"].ToString()));
                        tab.PlacaVeiculo = DR["placa"].ToString();
                        if (Convert.IsDBNull(DR["data"]))
                            tab.DataOrcamento = null;
                        else
                            tab.DataOrcamento = (DateTime)DR["data"];
                        tab.PosicaoOrcamentoDescricao = Veiculo.ObterPosicaoOrcamento(int.Parse(DR["id_posicaoorcamento"].ToString())).Descricao;
                        tab.AtendidoPor = DR["atendidopor"].ToString();
                        
                        List.Add(tab);
                    }
                    return List;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(OrcamentoDTO orcamento)
        {
            DbConnection connection = null;
            bool transactionstart = false;


            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                    }

                    dbCommand = db.GetSqlStringCommand(" INSERT INTO public.orcamento(" +
                                                       "    id_cliente," +
                                                       "    data," +
                                                       "    placa," +
                                                       "    atendidopor," +
                                                       "    notafiscalprodutos," +
                                                       "    notafiscalservicos," +
                                                       "    QuantidadeParcelas," +
                                                       "    IdEspecieRecebimento," +
                                                       "    ValorEspecieRecebimento," +
                                                       "    id_posicaoorcamento" +
                                                       ") VALUES (" +
                                                       "    @id_cliente," +
                                                       "    @data," +
                                                       "    @placa," +
                                                       "    @atendidopor," +
                                                       "    @notafiscalprodutos," +
                                                       "    @notafiscalservicos," +
                                                       "    @QuantidadeParcelas," +
                                                       "    @IdEspecieRecebimento," +
                                                       "    @ValorEspecieRecebimento," +
                                                       "    @id_posicaoorcamento);" +
                                                       " SELECT currval('orcamento_id_seq');");
                    db.AddInParameter(dbCommand, "@id_cliente", DbType.Int32, orcamento.Cliente.Id);
                    db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)orcamento.DataOrcamento);
                    db.AddInParameter(dbCommand, "@placa", DbType.String, orcamento.PlacaVeiculo);
                    db.AddInParameter(dbCommand, "@atendidopor", DbType.String, orcamento.AtendidoPor);
                    db.AddInParameter(dbCommand, "@id_posicaoorcamento", DbType.Int32, orcamento.PosicaoOrcamento);
                    db.AddInParameter(dbCommand, "@notafiscalprodutos", DbType.String, orcamento.NotaFiscalProdutos);
                    db.AddInParameter(dbCommand, "@notafiscalservicos", DbType.String, orcamento.NotaFiscalServicos);
                    db.AddInParameter(dbCommand, "@QuantidadeParcelas", DbType.Int32, orcamento.QuantidadeParcelas);
                    db.AddInParameter(dbCommand, "@IdEspecieRecebimento", DbType.Int32, orcamento.IdEspecieRecebimento);
                    db.AddInParameter(dbCommand, "@ValorEspecieRecebimento", DbType.Decimal, orcamento.ValorEspecieRecebimento);
                    int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    PersisteListas(orcamento, id);
                    connection.Close();
                    return id;
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }

        private void PersisteListas(OrcamentoDTO orcamento, int id_orcamento)
        {
            LancamentoProdutoServicoDAO lancamentoProdServDAO = new LancamentoProdutoServicoDAO();
            List<LancamentoProdutoServicoDTO> items = new List<LancamentoProdutoServicoDTO>();
            items.AddRange(orcamento.Produtoservico);

            if (lancamentoProdServDAO.DeleteOrcamento(id_orcamento))
            {
                foreach (LancamentoProdutoServicoDTO orcamentoitem in items)
                {
                    orcamentoitem.Id_orcamento = id_orcamento;
                    lancamentoProdServDAO.Insert(orcamentoitem);
                }
            }
        }
        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(OrcamentoDTO orcamento)
        {
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                    }
                dbCommand = db.GetSqlStringCommand(" UPDATE " + "public" + ".orcamento SET" +
                                                   "    id_cliente = @id_cliente," +
                                                   "    data = @data, " +
                                                   "    placa = @placa, " +
                                                   "    atendidopor = @atendidopor, " +
                                                   "    notafiscalprodutos = @notafiscalprodutos, " +
                                                   "    notafiscalservicos = @notafiscalservicos, " +
                                                   "    IdEspecieRecebimento = @IdEspecieRecebimento, " +
                                                   "    ValorEspecieRecebimento = @ValorEspecieRecebimento, " +
                                                   "    QuantidadeParcelas = @QuantidadeParcelas, " +
                                                   "    id_posicaoorcamento = @id_posicaoorcamento " +
                                                  " WHERE" +
                                                       " id = @id");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, orcamento.Id);
                db.AddInParameter(dbCommand, "@id_cliente", DbType.Int32, orcamento.Cliente.Id);
                db.AddInParameter(dbCommand, "@data", DbType.Date, (DateTime?)orcamento.DataOrcamento);
                db.AddInParameter(dbCommand, "@placa", DbType.String, orcamento.PlacaVeiculo);
                db.AddInParameter(dbCommand, "@atendidopor", DbType.String, orcamento.AtendidoPor);
                db.AddInParameter(dbCommand, "@id_posicaoorcamento", DbType.Int32, orcamento.PosicaoOrcamento);
                db.AddInParameter(dbCommand, "@notafiscalprodutos", DbType.String, orcamento.NotaFiscalProdutos);
                db.AddInParameter(dbCommand, "@notafiscalservicos", DbType.String, orcamento.NotaFiscalServicos);
                db.AddInParameter(dbCommand, "@QuantidadeParcelas", DbType.Int32, orcamento.QuantidadeParcelas);
                db.AddInParameter(dbCommand, "@IdEspecieRecebimento", DbType.Int32, orcamento.IdEspecieRecebimento);
                db.AddInParameter(dbCommand, "@ValorEspecieRecebimento", DbType.Decimal, orcamento.ValorEspecieRecebimento);

                db.ExecuteNonQuery(dbCommand, Transaction);

                PersisteListas(orcamento, orcamento.Id);

                if (transactionstart)
                {
                    Transaction.Commit();
                    Transaction = null;
                }
                connection.Close();
                return true;
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                    }

                    dbCommand = db.GetSqlStringCommand(" DELETE FROM " + "public" + ".orcamento" +
                                                       " WHERE" +
                                                       "    id = @id;");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
                    db.ExecuteNonQuery(dbCommand, Transaction);

                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }
                    connection.Close();
                    LancamentoProdutoServicoDAO lancamentoProdServDAO = new LancamentoProdutoServicoDAO();
                    lancamentoProdServDAO.DeleteOrcamento(id);                    
                    
                    return true;
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }

        /// <summary>
        /// Transferência de Funcionários.
        /// </summary>
        public void InsertTotal(OrcamentoDTO orcamento)
        {
            try
            {
                //dbCommand = db.GetSqlStringCommand(" INSERT INTO " + MechTech.Util.Global.EmpresaAtiva + ".orcamento(" +
                //                                   "    id_funcionario," +
                //                                   "    mesano" +
                //                                   ") VALUES (" +
                //                                   "    @id_funcionario," +
                //                                   "    @mesano);" +
                //                                   " SELECT currval('" + MechTech.Util.Global.EmpresaAtiva + ".orcamento_id_seq');");
                //db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, orcamento.Id_funcionario);
                //db.AddInParameter(dbCommand, "@mesano", DbType.Date, (DateTime?)orcamento.Mesano);
                //int id = Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction.DBTransaction));

                //OrcamentoEventoDAO orcamentoeventodata = new OrcamentoEventoDAO();
                //foreach (OrcamentoEventoDTO itemorcamento in orcamento.Orcamentoevento)
                //{
                //    itemorcamento.Id_orcamento = id;
                //    orcamentoeventodata.Insert(itemorcamento);
                //}
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Responsável apenas por verificar a existência do Orcamento no Banco de dados (Importação de dados).
        /// </summary>
        /// <param name="id_funcionario">ID do Funcionário</param>
        /// <param name="mesano">Mês/Ano de processamento</param>
        /// <returns>true = existe, não = não existe</returns>
        public bool ExistsOrcamento(int id_funcionario, DateTime mesano)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamento");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, mesano);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    while (DR.Read())
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }


        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_orcamento)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetOrcamento");
                db.AddInParameter(dbCommand, "@id", DbType.Int32, id_orcamento);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    OrcamentoDTO tab = new OrcamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    tab.Cliente = new ClienteDAO().GetCliente(int.Parse(DR["id_cliente"].ToString()));
                    tab.PlacaVeiculo = DR["placa"].ToString();
                    if (Convert.IsDBNull(DR["data"]))
                        tab.DataOrcamento = null;
                    else
                        tab.DataOrcamento = (DateTime)DR["data"];
                    tab.PosicaoOrcamento = int.Parse(DR["id_posicaoorcamento"].ToString());
                    tab.PosicaoOrcamentoDescricao = Veiculo.ObterPosicaoOrcamento(int.Parse(DR["id_posicaoorcamento"].ToString())).Descricao;
                    tab.AtendidoPor = DR["atendidopor"].ToString();
                    tab.Produtoservico = new LancamentoProdutoServicoDAO().GetListOrcamentoItem(tab.Id);
                    tab.NotaFiscalProdutos = DR["notafiscalprodutos"].ToString();
                    tab.NotaFiscalServicos = DR["notafiscalservicos"].ToString();
                    tab.IdEspecieRecebimento = int.Parse(DR["idespecierecebimento"].ToString());
                    tab.ValorEspecieRecebimento = decimal.Parse(DR["valorespecierecebimento"].ToString());
                    tab.QuantidadeParcelas = int.Parse(DR["quantidadeparcelas"].ToString());

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        public OrcamentoDTO GetOrcamento(int id_funcionario, DateTime mesano)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamento");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, mesano);

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    OrcamentoDTO tab = new OrcamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    //tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());
                    //if (Convert.IsDBNull(DR["mesano"]))
                    //    tab.Mesano = null;
                    //else
                    //    tab.Mesano = (DateTime)DR["mesano"];

                    //if (Convert.IsDBNull(DR["envioemail"]))
                    //    tab.EnvioEmail = null;
                    //else
                    //    tab.EnvioEmail = (DateTime)DR["envioemail"];

                    //tab.Orcamentoevento = new OrcamentoEventoDAO().GetOrcamentoeventoOrcamento(tab.Id, processamento, false);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="todoseventos">true = Todos os eventos inclusive os não disponíveis para visualização, caso contrário, todos os eventos exceto os não disponíveis para visualização</param>
        /// <returns></returns>
        public OrcamentoDTO GetOrcamento(int id_funcionario, int processamento, DateTime mesano, bool todoseventos)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamento");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, mesano);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    DR.Read();
                    OrcamentoDTO tab = new OrcamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());
                    //tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());
                    //if (Convert.IsDBNull(DR["mesano"]))
                    //    tab.Mesano = null;
                    //else
                    //    tab.Mesano = (DateTime)DR["mesano"];

                    //if (Convert.IsDBNull(DR["envioemail"]))
                    //    tab.EnvioEmail = null;
                    //else
                    //    tab.EnvioEmail = (DateTime)DR["envioemail"];

                    //tab.Orcamentoevento = new OrcamentoEventoDAO().GetOrcamentoeventoOrcamento(tab.Id, processamento, todoseventos);

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos OrcamentoDTO caso a instrução seja bem sucedida.
        /// Os períodos indicam o intervalo de tempo onde deve ser encontrado o evento especificado.
        /// </summary>
        public List<OrcamentoDTO> GetOrcamento(int id_funcionario, int id_evento, int processamento, DateTime periodoinicial, DateTime periodofinal)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamento2");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "@id_evento", DbType.Int32, id_evento);
                db.AddInParameter(dbCommand, "@processamento", DbType.Int32, processamento);
                db.AddInParameter(dbCommand, "@periodoinicial", DbType.Date, periodoinicial);
                db.AddInParameter(dbCommand, "@periodofinal", DbType.Date, periodofinal);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<OrcamentoDTO> List = new List<OrcamentoDTO>();
                    while (DR.Read())
                    {
                        OrcamentoDTO tab = new OrcamentoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        //tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());
                        //if (Convert.IsDBNull(DR["mesano"]))
                        //    tab.Mesano = null;
                        //else
                        //    tab.Mesano = (DateTime)DR["mesano"];

                        //if (Convert.IsDBNull(DR["envioemail"]))
                        //    tab.EnvioEmail = null;
                        //else
                        //    tab.EnvioEmail = (DateTime)DR["envioemail"];

                        //tab.Orcamentoevento.Add(new OrcamentoEventoDAO().GetEventoOrcamentoevento(tab.Id, id_evento, processamento));
                        List.Add(tab);
                    }
                    return List;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos OrcamentoDTO caso a instrução seja bem sucedida. (MANAD)
        /// </summary>
        public List<OrcamentoDTO> GetOrcamento(DateTime periodoinicial, DateTime periodofinal)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamentoByPeriodo");
                db.AddInParameter(dbCommand, "@periodoinicial", DbType.Date, periodoinicial);
                db.AddInParameter(dbCommand, "@periodofinal", DbType.Date, periodofinal);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<OrcamentoDTO> List = new List<OrcamentoDTO>();
                    while (DR.Read())
                    {
                        OrcamentoDTO tab = new OrcamentoDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        //tab.Id_funcionario = int.Parse(DR["id_funcionario"].ToString());
                        //if (Convert.IsDBNull(DR["mesano"]))
                        //    tab.Mesano = null;
                        //else
                        //    tab.Mesano = (DateTime)DR["mesano"];

                        //if (Convert.IsDBNull(DR["envioemail"]))
                        //    tab.EnvioEmail = null;
                        //else
                        //    tab.EnvioEmail = (DateTime)DR["envioemail"];

                        //List.Add(tab);

                        //if (!this.Funcionarios.ContainsKey(tab.Id_funcionario))
                        //    Funcionarios.Add(tab.Id_funcionario, tab.Id_funcionario);
                    }
                    return List;
                }
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Retorna um objeto OrcamentoDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="mesano">null = Mês anterior em relação ao mês/ano ativo, caso contrário, mês anterior em relação a data informada</param>
        /// <returns></returns>
        public OrcamentoDTO GetOrcamentoMesanterior(int id_funcionario, int processamento, DateTime? mesano)
        {
            DateTime? mesanoanterior = null;
            if (!mesano.HasValue)
                mesanoanterior = MechTech.Util.Global.MesanoAtivo.AddDays(-1);
            else
                mesanoanterior = mesano;

            try
            {
                dbCommand = db.GetStoredProcCommand(MechTech.Util.Global.EmpresaAtiva + ".GetOrcamento");
                db.AddInParameter(dbCommand, "@id_funcionario", DbType.Int32, id_funcionario);
                db.AddInParameter(dbCommand, "@mesano", DbType.Date, Convert.ToDateTime("01/" + mesanoanterior.Value.Month.ToString() + "/" + mesanoanterior.Value.Year.ToString()));

                using (IDataReader DR = (Transaction == null ? db.ExecuteReader(dbCommand) : db.ExecuteReader(dbCommand, Transaction)))
                {
                    DR.Read();
                    OrcamentoDTO tab = new OrcamentoDTO();
                    tab.Id = int.Parse(DR["id"].ToString());

                    return tab;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool AtualizarEstoque(int produtoId, int qtdEstoqueAtualizada)
        {
            DbConnection connection = null;
            bool transactionstart = false;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    if (Transaction == null)
                    {
                        Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        transactionstart = true;
                    }

                    dbCommand = db.GetSqlStringCommand(" UPDATE public.produto_servico " +
                                                       " SET estoqueatual = @qtdestoqueatualizada " +
                                                       " WHERE" +
                                                       "    id = @id;");
                    db.AddInParameter(dbCommand, "@id", DbType.Int32, produtoId);
                    db.AddInParameter(dbCommand, "@qtdestoqueatualizada", DbType.Int32, qtdEstoqueAtualizada);
                    db.ExecuteNonQuery(dbCommand, Transaction);

                    if (transactionstart)
                    {
                        Transaction.Commit();
                        Transaction = null;
                    }

                    connection.Close();
                    return true;
                }
            }
            catch
            {
                if (transactionstart)
                {
                    if (Transaction.Connection.State == ConnectionState.Open)
                        Transaction.Rollback();
                    Transaction = null;
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                throw;
            }
        }
    }
}