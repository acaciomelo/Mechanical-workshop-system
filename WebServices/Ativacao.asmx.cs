using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using MechTech.Data;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Globalization;


namespace MechTech.WebServices
{
    /// <summary>
    /// Ativação
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Ativacao : System.Web.Services.WebService
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        AtivacaoDAO ativacaoDAO = null;

        public void FecharConexao()
        {
            connection = Data.Connection;
            connection.Close();
        }

        public int ClienteStatus(string razaosocial, DateTime dataLiberadoAte)
        {
            connection = Data.Connection;
            string query = string.Empty;
            int liberado = 0;
            int diasLiberados = 0;

            if (dataLiberadoAte == DateTime.MinValue)
            {
                liberado = 0;
                return 0;
            }

            //Se existir data de liberação, fazer o cálculo para verificar quantos dias estão disponíveis ainda
            // Data Liberação - Data Hoje         
            query = "SELECT (DATEDIFF(liberado_ate, current_date)) as qtdDias from ativacao where razao_soc = '" + razaosocial + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader DR = cmd.ExecuteReader();

            try
            {
                if (DR.HasRows)
                    while (DR.Read())
                    {
                        diasLiberados = int.Parse(DR["qtdDias"].ToString());
                    }
                DR.Close();

                if (diasLiberados > 0)
                    liberado = 1;
            }
            catch
            {
                return 0;
            }

            return liberado;
        }

        [WebMethod]
        public int VerificarDiasDemonstracao(string ip)
        {
            connection = Data.Connection;
            string query;
            int dias;
            DateTime hoje;
            string data_ini = string.Empty;
            hoje = DateTime.Today;

            try
            {
                var client = new TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    hoje = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).Date;
                }
            }
            catch
            {
                return 9999;
            }

            query = "Select data_ini from ativacao.demonstracao where ip = '" + ip + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader DR = cmd.ExecuteReader();
            try
            {
                if (DR.HasRows)
                    while (DR.Read())
                    {
                        data_ini = DR["data_ini"].ToString();
                    }

                dias = int.Parse(((DateTime.Parse(data_ini) - hoje).Add(TimeSpan.FromDays(16))).TotalDays.ToString());
                DR.Close();
                return dias;
            }
            catch
            {
                return 1;
            }
        }

        [WebMethod]
        public string GetIp()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        [WebMethod]
        public void GravarIp(string ip)
        {
            string query = "Insert into ativacao.demonstracao(ip, data_ini)Values ('" + ip + "',CURRENT_TIMESTAMP())";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public bool VerificaIpNoServidor(string ipmaquina)
        {
            connection = Data.Connection;
            bool ipcadastrado = false;
            string query = "Select ip from ativacao.demonstracao where ip = '" + ipmaquina + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader DR = cmd.ExecuteReader();
            try
            {
                if (DR.HasRows)
                    while (DR.Read())
                    {
                        ipcadastrado = true;
                    }
                DR.Close();
                return ipcadastrado;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public void InserirMaquinaServidor(string razao, string ip)
        {
            string query = string.Empty;
            string nomeMaquina = System.Environment.MachineName;
            MySqlCommand cmd = null;
            int idUltimoInserido = 0;
            connection = Data.Connection;
            query = "Select id from ativacao.ativacao where razao_soc = '" + razao + "'";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader DR = cmd.ExecuteReader();
            if (DR.HasRows)
                while (DR.Read())
                {
                    try
                    {
                        idUltimoInserido = int.Parse(DR["id"].ToString());
                    }
                    catch
                    {
                    }
                }
            DR.Close();

            if (idUltimoInserido != 0)
            {
                try
                {
                    query = "insert into ativacao.ipmaquinas_clientes (ipmaquina,id_ativacao,nome_maquina)";
                    query += "values ('" + ip + "'," + idUltimoInserido + ",'" + nomeMaquina + "')";
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    cmd.Transaction.Rollback();
                }
            }
        }

        [WebMethod]
        public void InserirClienteServidor(string razao, string cnpj, string end, string cidade, string bairro, string num, string cep, string uf, string email, string contato, string telefone, string ip)
        {
            connection = Data.Connection;
            string query = string.Empty;
            MySqlCommand cmd = null;

            try
            {
                query = "insert into ativacao.ativacao (razao_soc,ativo,data_ativ,cnpj,endereco,cidade,bairro,numero,cep,uf,email,contato, telefone, ip_maquina)";
                query += "values ('" + razao + "'," + "1" + ",CURRENT_TIMESTAMP(),'" + cnpj + "','" + end + "','" + cidade + "','" + bairro + "','" + num + "','" + cep + "','" + uf + "','" + email + "','" + contato + "','" + telefone + "','" + ip + "')";
                cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                cmd.Transaction.Rollback();
            }
        }

        [WebMethod]
        public bool VerificaAtivacao(string razaosocial)
        {
            connection = Data.Connection;
            string query;
            bool ativo = false;
            DateTime dataLiberadoAte = DateTime.MinValue;
            query = "Select id,ativo,liberado_ate from ativacao.ativacao where razao_soc = '" + razaosocial + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader DR = cmd.ExecuteReader();
            try
            {
                if (DR.HasRows)
                    while (DR.Read())
                    {
                        ativo = bool.Parse(DR["ativo"].ToString());
                        try
                        {
                            dataLiberadoAte = DateTime.Parse(DR["liberado_ate"].ToString());
                        }
                        catch (Exception)
                        {
                            dataLiberadoAte = DateTime.MinValue;
                        }
                    }

                DR.Close();
            }
            catch
            {
                return false;
            }

            if (ativo && ClienteStatus(razaosocial, dataLiberadoAte) == 1)
                return true;
            else
                return false;
        }

        [WebMethod]
        public bool RazaoSocialJaExisteServidorOnline(string razaosocial)
        {
            connection = Data.Connection;
            MySqlCommand cmd = null;
            MySqlDataReader DR = null;
            bool existeRazaoSocial = false;
            string query;
            query = "Select * from ativacao.ativacao where razao_soc = '" + razaosocial + "'";
            cmd = new MySqlCommand(query, connection);
            DR = cmd.ExecuteReader();
            try
            {
                if (DR.HasRows)
                    existeRazaoSocial = true;

                DR.Close();
            }
            catch { }

            return existeRazaoSocial;
        }

        public bool IPJaExisteServidorOnline(string ip, string nomemaquina)
        {
            bool existeIPCadastrado = false;
            MySqlCommand cmd = null;
            MySqlDataReader DR = null;
            string query;

            query = "Select * from ativacao.ipmaquinas_clientes where ipmaquina = '" + ip + "'" + " or nome_maquina = '" + nomemaquina + "'";
            cmd = new MySqlCommand(query, connection);
            DR = cmd.ExecuteReader();
            try
            {
                if (DR.HasRows)
                    existeIPCadastrado = true;

                DR.Close();
            }
            catch { }

            return existeIPCadastrado;
        }
    }

    public static class Data
    {
        static MySqlConnection connection;

        static MySqlConnection CreateConnection()
        {
            string server;
            string database;
            string uid;
            string password;
            string connectionString;
            AtivacaoDAO ativacaoDAO = new AtivacaoDAO();

            server = "p3plcpnl0299.prod.phx3.secureserver.net";
            database = "ativacao";
            uid = "mechtech";
            password = ativacaoDAO.GetPasswordDatabaseOnline();
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public static MySqlConnection Connection
        {
            get
            {
                if (connection == null || connection.State.Equals(ConnectionState.Closed))
                    LazyInitializer.EnsureInitialized(ref connection, CreateConnection);

                return connection;
            }
        }
    }
}
