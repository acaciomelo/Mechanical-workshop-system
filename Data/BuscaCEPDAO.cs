using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

#region DEVART
using Devart.Data.PostgreSql;
#endregion

#region MECHTECH
using MechTech.Entities;
using MechTech.Util;
#endregion


namespace MechTech.Data
{
    public class BuscaCEPDAO
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
        /// Instância básica para BuscaCEPDAO.
        /// </summary>
        public BuscaCEPDAO()
        { }

        /// <summary>
        /// Instância para BuscaCEPDAO com controle de transação.
        /// </summary>
        public BuscaCEPDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }


        public List<BuscaCEPDTO> GetEndereco(string uf, string municipio, string logradouro, string cep)
        {
            db = new GenericDatabase("host=www.webpav.com.br;Port=5432;Database=cep;User=webpav;Password=WAvPaul;Unicode=False;Protocol=2", PgSqlProviderFactory.Instance);
            DbConnection connection = null;
            List<BuscaCEPDTO> List = new List<BuscaCEPDTO>();
            try
            {

                using (connection = db.CreateConnection())
                {

                    connection.Open();

                    string where1 = string.Empty;
                    string where2 = string.Empty;


                    if (cep.Trim() != "")
                    {
                        where1 = where1 + " AND loc.cep = @cep ";
                        where2 = where2 + " AND log.cep = @cep ";
                    }

                    if (municipio.Trim() != "")
                    {
                        where2 = where2 + " AND loc.nome ILIKE @municipio ";
                    }

                    if (logradouro.Trim() != "")
                    {
                        where2 = where2 + " AND log.nome ILIKE @logradouro ";
                    }

                    if (uf.Trim() != "")
                    {
                        where1 = where1 + " AND loc.sigla_uf = @uf ";
                        where2 = where2 + " AND log.sigla_uf = @uf ";
                    }




                    string SQL1 = string.Empty;
                    if (cep.Trim() != "")
                        SQL1 = "SELECT '' as logradouro, '' as patante, '' as preposicao,'' as endereco,'' as Bairro, loc.nome as Localidade, loc.sigla_uf as uf, loc.codigo_ibge_municipio as ibge, loc.cep as cep   " +
                                                           " FROM dne_localidade loc " +
                                                            "  WHERE 1 = 1 " + where1 +
                                                            " UNION ALL ";

                    string SQL2 = " SELECT (CASE WHEN log.tipo_logradouro <> '' THEN log.tipo_logradouro || ' '   ELSE '' END) as logradouro, " +
                                                        "        (CASE WHEN log.titulo_patente <> ''  THEN log.titulo_patente  || ' '   ELSE '' END) as patante, " +
                                                        "        (CASE WHEN log.preposicao <> ''      THEN log.preposicao      || ' '   ELSE '' END) as preposicao, " +
                                                        "log.nome as endereco , bai.nome as Bairro, loc.nome as Localidade, log.sigla_uf as uf, loc.codigo_ibge_municipio as ibge, log.cep as cep " +
                                                        " FROM dne_logradouro log " +
                                                        " LEFT JOIN dne_bairro bai ON log.chave_bairro_inicial = bai.chave_bairro OR log.chave_bairro_final = bai.chave_bairro " +
                                                        " LEFT JOIN dne_localidade loc ON log.chave_localidade = loc.chave_localidade " +
                                                        " WHERE 1 = 1  " + where2 +
                                                        " UNION ALL ";

                    string SQL3 = " SELECT (CASE WHEN log.tipo_logradouro <> '' THEN log.tipo_logradouro || ' '   ELSE '' END) as logradouro,  " +
                                                        "        (CASE WHEN log.titulo_patente <> ''  THEN log.titulo_patente  || ' '   ELSE '' END) as patante,  " +
                                                        "        (CASE WHEN log.preposicao <> ''      THEN log.preposicao      || ' '   ELSE '' END) as preposicao, " +
                                                        "log.nome as endereco, bai.nome as Bairro, loc.nome as Localidade, log.sigla_uf as uf, loc.codigo_ibge_municipio as ibge, log.cep as cep " +
                                                        " FROM dne_logradouro_seccionamento log " +
                                                        " LEFT JOIN dne_bairro bai ON log.chave_bairro_inicial = bai.chave_bairro OR log.chave_bairro_final = bai.chave_bairro " +
                                                        " LEFT JOIN dne_localidade loc ON log.chave_localidade = loc.chave_localidade " +
                                                        " WHERE 1 = 1 " + where2 +
                                                        " UNION ALL ";

                    string SQL4 = " SELECT (CASE WHEN log.tipo_logradouro <> '' THEN log.tipo_logradouro || ' '   ELSE '' END) as logradouro, " +
                                                        "        (CASE WHEN log.titulo_patente <> ''  THEN log.titulo_patente  || ' '   ELSE '' END) as patante,  " +
                                                        "        (CASE WHEN log.preposicao <> ''      THEN log.preposicao      || ' '   ELSE '' END) as preposicao, " +
                                                        "log.nome as endereco, bai.nome as Bairro, loc.nome as Localidade, log.sigla_uf as uf, loc.codigo_ibge_municipio as ibge, log.cep as cep " +
                                                        " FROM dne_logradouro_numeracao_lote log " +
                                                        " LEFT JOIN dne_bairro bai ON log.chave_bairro_inicial = bai.chave_bairro OR log.chave_bairro_final = bai.chave_bairro " +
                                                        " LEFT JOIN dne_localidade loc ON log.chave_localidade = loc.chave_localidade " +
                                                        " WHERE 1 = 1 " + where2 +
                                                        " UNION ALL ";

                    string SQL5 = " SELECT (CASE WHEN log.tipo_logradouro <> '' THEN log.tipo_logradouro || ' '   ELSE '' END) as logradouro,  " +
                                                        "        (CASE WHEN log.titulo_patente <> ''  THEN log.titulo_patente  || ' '   ELSE '' END) as patante,  " +
                                                        "        (CASE WHEN log.preposicao <> ''      THEN log.preposicao      || ' '   ELSE '' END) as preposicao, " +
                                                        "log.nome as endereco, bai.nome as Bairro, loc.nome as Localidade, log.sigla_uf as uf, loc.codigo_ibge_municipio as ibge, log.cep as cep " +
                                                        " FROM dne_logradouro_complemento1 log " +
                                                        " LEFT JOIN dne_bairro bai ON log.chave_bairro_inicial = bai.chave_bairro OR log.chave_bairro_final = bai.chave_bairro " +
                                                        " LEFT JOIN dne_localidade loc ON log.chave_localidade = loc.chave_localidade " +
                                                        " WHERE 1 = 1 " + where2;


                    dbCommand = db.GetSqlStringCommand(SQL1 + SQL2 + SQL3 + SQL4 + SQL5);




                    if (cep.Trim() != "")
                        db.AddInParameter(dbCommand, "@cep", DbType.String, cep);

                    if (municipio.Trim() != "")
                        db.AddInParameter(dbCommand, "@municipio", DbType.String, "%" + municipio + "%");

                    if (logradouro.Trim() != "")
                        db.AddInParameter(dbCommand, "@logradouro", DbType.String, "%" + logradouro + "%");

                    if (uf.Trim() != "")
                        db.AddInParameter(dbCommand, "@uf", DbType.String, uf);

                    using (IDataReader DR = db.ExecuteReader(dbCommand))
                    {

                        while (DR.Read())
                        {
                            BuscaCEPDTO tab = new BuscaCEPDTO();
                            if (DR["uf"].ToString() != "")
                                tab.Uf = DR["uf"].ToString();
                            if (DR["Localidade"].ToString() != "")
                                tab.Municipio = DR["Localidade"].ToString();
                            if (DR["Bairro"].ToString() != "")
                                tab.Bairro = DR["Bairro"].ToString();
                            if (DR["cep"].ToString() != "")
                                tab.Cep = DR["cep"].ToString();
                            if (DR["ibge"].ToString() != "")
                                tab.CodMun = int.Parse(DR["ibge"].ToString());
                            tab.Endereco = DR["logradouro"].ToString() + DR["patante"].ToString() + DR["preposicao"].ToString() + DR["endereco"].ToString();
                            List.Add(tab);
                        }
                    }

                    connection.Close();
                    //KILL INSTANCE
                    db = null;


                }

            }
            catch
            {
                throw;
            }

            return List;


        }




    }
}
