using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Devart.Data.PostgreSql;

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Data
{
    public class PerfilRotinaDAO
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
        /// Instância básica para PerfilRotinaDAO.
        /// </summary>
        public PerfilRotinaDAO()
        { }

        /// <summary>
        /// Instância para PerfilRotinaDAO com controle de transação.
        /// </summary>
        public PerfilRotinaDAO(DbTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(PerfilRotinaDTO perfilrotina)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" INSERT INTO public.perfilrotina(" +
                                                   " id_perfil," +
                                                   " id_rotina" +
                                                   ") VALUES (" +
                                                   " @id_perfil," +
                                                   " @id_rotina);" +
                                                   " SELECT currval('perfilrotina_id_seq');");
                db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, perfilrotina.Id_Perfil);
                db.AddInParameter(dbCommand, "@id_rotina", DbType.Int32, perfilrotina.Id_Rotina);
                return Convert.ToInt32(db.ExecuteScalar(dbCommand, Transaction));
            }
            catch
            {
                throw;
            }
        }

        //TODO: Implemente códigos adicionais aqui.

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool DeletePerfil(int id_perfil)
        {
            try
            {
                dbCommand = db.GetSqlStringCommand(" DELETE FROM public.perfilrotina" +
                                                       " WHERE" +
                                                       " id_perfil = @id_perfil;");
                db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, id_perfil);
                db.ExecuteNonQuery(dbCommand, Transaction);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos PerfilRotinaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<PerfilRotinaDTO> GetPerfilRotinaPerfil(int id_perfil)
        {
            try
            {
                dbCommand = db.GetStoredProcCommand("GetPerfilRotinaPerfil");
                db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, id_perfil);

                using (IDataReader DR = db.ExecuteReader(dbCommand))
                {
                    List<PerfilRotinaDTO> List = new List<PerfilRotinaDTO>();
                    while (DR.Read())
                    {
                        PerfilRotinaDTO tab = new PerfilRotinaDTO();
                        tab.Id = int.Parse(DR["id"].ToString());
                        tab.Id_Perfil = int.Parse(DR["id_perfil"].ToString());
                        tab.Id_Rotina = int.Parse(DR["id_rotina"].ToString());
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
    }
}