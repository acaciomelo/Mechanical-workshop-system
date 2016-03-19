using System.Runtime.InteropServices;

namespace MechTech.Util
{
    /// <summary>
    /// Representa um conjunto de métodos para validação de documentos. Essa classe não pode ser herdada.
    /// </summary>
    public sealed class Documentos
    {
        /// <summary>
        /// Instância básica para Documentos.
        /// </summary>
        public Documentos()
        { }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para CPF válido, caso contrário FALSO.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ValidarCPF(string cpf)
        {
            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCPF;
                string digito;
                int soma;
                int resto;

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "").Replace("_", "").PadLeft(11, '0');

                tempCPF = cpf.Substring(0, 9);
                soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCPF[i].ToString()) * multiplicador1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCPF = tempCPF + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCPF[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para CNPJ válido, caso contrário FALSO.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool ValidarCNPJ(string cnpj)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCNPJ;

                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "").PadLeft(14, '0');

                tempCNPJ = cnpj.Substring(0, 12);

                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCNPJ[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCNPJ = tempCNPJ + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCNPJ[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para PIS válido, caso contrário FALSO.
        /// </summary>
        /// <param name="pis"></param>
        /// <returns></returns>
        public static bool ValidarPIS(string pis)
        {
            try
            {
                int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;

                if (pis.Trim().Length == 0)
                    return false;

                pis = pis.Trim();
                pis = pis.Replace("-", "").Replace(".", "").Replace("_", "").PadLeft(11, '0');

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(pis[i].ToString()) * multiplicador[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                return pis.EndsWith(resto.ToString());
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se o número do CEI é válido
        /// </summary>
        /// <param name="cei">número do CEI sem caracateres de formatação</param>
        /// <returns>true=verdadeiro / false=errado ou falso</returns>
        public static bool ValidarCEI(string cei)
        {
            try
            {
                cei = cei.Replace(".", "").Replace("-", "").Replace("_", "").PadLeft(12, '0');

                string cNumero = cei.Substring(0, 11);
                int nDv = int.Parse(cei.Substring(11, 1));
                int[] matriz = new int[11] { 7, 4, 1, 8, 5, 2, 1, 6, 3, 7, 4 };
                int nTam = 0;
                int nSoma = 0;

                for (int i = 0; i <= 10; i++)
                {
                    nSoma += int.Parse(cNumero.Substring(i, 1)) * matriz[i];
                }

                string cSoma = nSoma.ToString() + "";
                nTam = cSoma.Length;
                int nAux = (int.Parse(cSoma.Substring(0, nTam - 1)) * 1) + (int.Parse(cSoma.Substring(nTam - 1)) * 1);
                string cAux = nAux.ToString() + "";
                nTam = cAux.Length;
                int nUnidade = 0;

                if (nTam == 1)
                    nUnidade = int.Parse(cAux.Substring(0, 1));
                else
                    nUnidade = int.Parse(cAux.Substring(1, 1));

                int nDvCalc = 10 - (nUnidade * 1);
                if (nDvCalc > 9)
                    nDvCalc = 0;

                if (nDvCalc == nDv)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna um tipo INTEIRO 0 para Incrição Estadual válida, caso contrário 1 ou 2.
        /// </summary>
        /// <param name="ie"></param>
        /// <param name="uf"></param>
        /// <returns></returns>
        [DllImport("dllinsce32.dll")]
        public static extern int ConsisteInscricaoEstadual(string ie, string uf);
    }
}