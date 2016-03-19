using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class BackupBO
    {
        BackupDAO regrasdados = new BackupDAO();

        /// <summary>
        /// Instância básica para BackupBO.
        /// </summary>
        public BackupBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(BackupDTO backup)
        {
            try
            {
                return regrasdados.Insert(backup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(BackupDTO backup)
        {
            try
            {
                return regrasdados.Update(backup);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                return regrasdados.Delete(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto BackupDTO caso a instrução seja bem sucedida.
        /// </summary>
        public BackupDTO GetBackup(int id)
        {
            try
            {
                return regrasdados.GetBackup(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos BackupDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<BackupDTO> GetGridBackup()
        {
            try
            {
                return regrasdados.GetGridBackup();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto BackupDTO caso com os dados do ultimo backup realizado
        /// </summary>
        public BackupDTO GetLastBackup()
        {
            try
            {
                return regrasdados.GetLastBackup();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna o numero da filial em uso para identificação de backup
        /// </summary>
        public int GetFilialBackup()
        {
            try
            {
                return regrasdados.GetFilialBackup();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Verifica se o backup é monitorado pela MW
        /// </summary>
        public bool MonitoraBackup()
        {
            try
            {
                return regrasdados.MonitoraBackup();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Grava informações sobre o backup na base da MECHTECH
        /// </summary>
        //public bool InsertMW(BackupDTO backup, string sistema, int filial)
        //{
        //    try
        //    {
        //        return regrasdados.InsertMW(backup, sistema, filial);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException(ex.Message);
        //    }
        //}

        public void GravaLOGBackup(int rotina, string ocorrencia)
        {
            try
            {
                regrasdados.GravaLOGBackup(rotina, ocorrencia);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}
