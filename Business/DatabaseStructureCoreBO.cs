using System;
using System.ServiceModel;

#region MECHTECH
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    /// <summary>
    /// Representa um conjunto de métodos para manipulação a nível de estrutura do Banco de dados.
    /// </summary>
    public class DatabaseStructureCoreBO
    {
        DatabaseStructureCoreDAO regrasdados = new DatabaseStructureCoreDAO();

        /// <summary>
        /// Instância básica para DatabaseStructureCoreBO.
        /// </summary>
        public DatabaseStructureCoreBO()
        { }

        /// <summary>
        /// Verifica a existência de um Banco de dados específico no servidor.
        /// </summary>
        /// <param name="databasename">Nome do Banco de dados</param>
        /// <returns>VERDADEIRO caso já exista o Banco de dados</returns>
        public bool ExistsDatabase(string databasename)
        {
            try
            {
                return regrasdados.ExistsDatabase(databasename);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo usuário para o Banco de dados.
        /// </summary>
        /// <param name="id_user">Chave do usuário</param>
        /// <param name="username">Login do usuário</param>
        /// <param name="password">Senha do usuário</param>
        public void CreateRole(int id_user, string username, string password)
        {
            try
            {
                regrasdados.CreateRole(id_user, username, password);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Ativa/Desativa a permissão de acesso no Banco de dados.
        /// </summary>
        /// <param name="username">Login do usuário</param>
        /// <param name="haslogin">Verdadeiro caso o usuário tenha permissão de login no Sistema</param>
        public void AlterRole(string username, bool haslogin)
        {
            try
            {
                regrasdados.AlterRole(username, haslogin);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Altera a senha de um usuário para um login existente.
        /// </summary>
        /// <param name="id_user">Chave do usuário</param>
        /// <param name="username">Login do usuário</param>
        /// <param name="newpassword">Nova senha do usuário</param>
        public void AlterRole(int id_user, string username, string newpassword)
        {
            try
            {
                regrasdados.AlterRole(id_user, username, newpassword);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Remove o usuário do Banco de dados.
        /// </summary>
        /// <param name="username">Login do usuário</param>
        public void DropRole(string username)
        {
            try
            {
                regrasdados.DropRole(username);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna a versão do servidor de Banco de dados.
        /// </summary>
        public string GetVersion()
        {
            try
            {
                return regrasdados.GetVersion();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}