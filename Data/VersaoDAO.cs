using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MechTech
using MechTech.Entities;
using MechTech.Util;
#endregion

namespace MechTech.Data
{
    public class VersaoDAO
    {
        Database db = null;
        DbCommand dbCommand = null;


        private DbTransaction transaction = null;
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Instância básica para CpArqDbDAO.
        /// </summary>
        public VersaoDAO()
        { }

        /// <summary>
        /// Instância para CpArqDbDAO com controle de transação.
        /// </summary>
        public VersaoDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        public void Insert(int versao, int modulo, string data, string hora, string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    dbCommand = db.GetSqlStringCommand("Insert Into public.pacote(" +
                        " versao," +
                        " modulo," +
                        " dataatualiza," +
                        " horaatualiza" +
                        ") VALUES (" +
                        " @versao," +
                        " @modulo," +
                        " @dataatualiza," +
                        " @horaatualiza);" +
                        " SELECT currval('pacote_id_seq');");
                    db.AddInParameter(dbCommand, "@versao", DbType.Int16, versao);
                    db.AddInParameter(dbCommand, "@modulo", DbType.Int16, modulo);
                    db.AddInParameter(dbCommand, "@dataatualiza", DbType.String, data);
                    db.AddInParameter(dbCommand, "@horaatualiza", DbType.String, hora);
                    db.ExecuteNonQuery(dbCommand, transaction);
                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Carrega os dados da tabela CpArq para copiar para o C:
        /// </summary>
        /// <returns>Lista do tipo CpArqDbDTO com os arquivos da tabela</returns>
        public List<CpArqDbDTO> GetCpArqDb(string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();

                    dbCommand = db.GetSqlStringCommand(" select path, arquivo, hash" +
                                                       " from cparq" +
                                                       " order by path");

                    List<CpArqDbDTO> List = new List<CpArqDbDTO>();
                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {

                        while (DR.Read())
                        {
                            CpArqDbDTO tab = new CpArqDbDTO();
                            tab.Path = DR["path"].ToString();
                            tab.Arquivo = DR["arquivo"].ToString();
                            tab.Hash = DR["hash"].ToString();

                            List.Add(tab);
                        }
                    }

                    connection.Close();
                    return List;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Carrega a versão do sistema pela tabela Pacote.
        /// </summary>
        /// <param name="conexao">string de conexão atualmente em uso</param>
        /// <returns>Retorna a versão atual do sistema informado pela tabela Pacote</returns>
        public string VersaoAtual(string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT versao,modulo FROM PACOTE" +
                                                       " ORDER BY versao desc, modulo desc" +
                                                       " LIMIT 1");

                    string versao = "1.00.000";

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            versao = decimal.Parse(DR["versao"].ToString()).ToString("N02") + "." + Global.CompletarZerosEsquerda(DR["modulo"].ToString(), 4);
                            versao = versao.Replace(",", ".");
                        }
                    }

                    return versao;
                }
            }
            catch
            {
                throw;
            }
        }

        public string DataVersaoAtual(string conexao)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT versao,modulo,dataatualiza FROM PACOTE" +
                                                       " ORDER BY versao desc, modulo desc" +
                                                       " LIMIT 1");

                    string dataAtualiza = string.Empty;

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            dataAtualiza = DR["dataAtualiza"].ToString();
                        }
                    }

                    return dataAtualiza;
                }
            }
            catch
            {
                throw;
            }
        }
       
        public int ModuloDesatualizado(int filial, decimal versao, int modulo, string sistema)
        {
            return 1;
            //Database db = new GenericDatabase("host=www.webpav.com.br;Port=5432;Database=modulo;User=modulo;Password=AvCS856;Unicode=False;Protocol=2", PgSqlProviderFactory.Instance);
            //DbConnection connection = null;

            //try
            //{
            //    using (connection = db.CreateConnection())
            //    {
            //        // CHECANDO CIRCULARES NA BASE DA MechTech
            //        connection.Open();

            //        dbCommand = db.GetSqlStringCommand(" SELECT " + sistema + ".pacote.id," + sistema + ".pacote.versao," + sistema + ".pacote.modulo, " +
            //                                           "        CASE WHEN (" + sistema + ".pacote.pessoaliberada='Geral' OR (SELECT COUNT(*) FROM " + sistema + ".pessoapacote  " +
            //                                           "                                                          WHERE " + sistema + ".pessoapacote.id_pacote = " + sistema + ".pacote.id  " +
            //                                           "                                                          AND " + sistema + ".pessoapacote.filial=@Filial)<>0)  " +
            //                                           "             THEN 'Sim' ELSE 'Não' END as liberado,  " +
            //                                           "        CASE WHEN (SELECT count(*) FROM " + sistema + ".pessoapacote " +
            //                                           "                   WHERE " + sistema + ".pessoapacote.id_pacote = " + sistema + ".pacote.id and " + sistema + ".pessoapacote.filial=@Filial" +
            //                                           "                   LIMIT 1) <> 0 " +
            //                                           "                   THEN " +
            //                                           "                       (SELECT formata_dataclarion(" + sistema + ".pessoapacote.dataliberacao) " +
            //                                           "                        FROM " + sistema + ".pessoapacote " +
            //                                           "                        WHERE " + sistema + ".pessoapacote.id_pacote = " + sistema + ".pacote.id and " + sistema + ".pessoapacote.filial=@Filial" +
            //                                           "                        LIMIT 1) " +
            //                                           "             WHEN " + sistema + ".pacote.pessoaliberada='Geral' " +
            //                                           "                   THEN formata_dataclarion(" + sistema + ".pacote.datalibgeral) " +
            //                                           "             ELSE 0 END as datalib " +
            //                                           " FROM " + sistema + ".pacote  " +
            //                                           " WHERE " + sistema + ".pacote.versao>@Versao" +
            //                                           "       OR (" + sistema + ".pacote.versao=@Versao AND " + sistema + ".pacote.modulo>@Modulo)  " +
            //                                           " ORDER BY " + sistema + ".pacote.versao," + sistema + ".pacote.modulo " +
            //                                           " LIMIT 1");
            //        db.AddInParameter(dbCommand, "@Filial", DbType.Int32, filial);
            //        db.AddInParameter(dbCommand, "@Versao", DbType.Decimal, versao);
            //        db.AddInParameter(dbCommand, "@Modulo", DbType.Int32, modulo);

            //        string liberado = "Não";
            //        int datalib = 0;

            //        using (IDataReader DR = db.ExecuteReader(dbCommand))
            //        {

            //            while (DR.Read())
            //            {
            //                liberado = DR["liberado"].ToString();
            //                datalib = int.Parse(DR["datalib"].ToString());
            //            }
            //        }

            //        if (liberado != "Sim" || datalib == 0)
            //            return 0;

            //        return datalib;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public int VerificaVersaoModulo(string conexao, int versao, int modulo)
        {
            db = new GenericDatabase(conexao, PgSqlProviderFactory.Instance);
            DbConnection connection = null;

            try
            {
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    dbCommand = db.GetSqlStringCommand(" SELECT id, versao, modulo FROM PACOTE" +
                                                       " where versao = @versao and modulo = @modulo" +
                                                       " ORDER BY versao desc, modulo desc");
                    db.AddInParameter(dbCommand, "@versao", DbType.Int32, versao);
                    db.AddInParameter(dbCommand, "@modulo", DbType.Int32, modulo);

                    int idPacote = 0;

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {
                        while (DR.Read())
                        {
                            idPacote = int.Parse(DR["id"].ToString());
                        }
                    }

                    return idPacote;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
