using MechTech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

#region DEVART
using Devart.Data.PostgreSql;
#endregion


namespace MechTech
{
    internal class ping
    {
        /// <summary>
        /// Envia uma solicitação para o servidor de Banco de dados para testar a validade da conexão.
        /// </summary>
        /// <param name="oConn">Objeto de conexão</param>
        /// <returns>Verdadeiro caso a conexão seja estabelecida com sucesso.</returns>
        public static bool Send(ConexoesDTO oConn)
        {
            try
            {
                PgSqlConnection connection = new PgSqlConnection("host=" + oConn.Servidor + ";Port=" + oConn.Porta + ";Database=" + oConn.Banco + ";User=" + oConn.Usuario + ";Password=" + oConn.Senha + ";Unicode=False;Protocol=2");
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação.\n\n" +
                                "Motivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }
    }
}
