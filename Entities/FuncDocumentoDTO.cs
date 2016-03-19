using System;

namespace MechTech.Entities
{
    [Serializable]
    public class FuncDocumentoDTO : IEquatable<FuncDocumentoDTO>
    {
        public FuncDocumentoDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FuncDocumentoDTO(FuncDocumentoDTO obj)
        {
            this.Id = obj.Id;
            this.Id_funcionario = obj.Id_funcionario;
            this.Cpf = obj.Cpf;
            this.Rg = obj.Rg;
            this.Rgemissao = obj.Rgemissao;
            this.Rgorgao = obj.Rgorgao;
            this.UFRG = new UFDTO(obj.UFRG);
            this.Carteiramodelo = obj.Carteiramodelo;
            this.Ctps = obj.Ctps;
            this.Ctpsserie = obj.Ctpsserie;
            this.Ctpsemissao = obj.Ctpsemissao;
            this.UFCTPS = new UFDTO(obj.UFCTPS);
            this.Titulo = obj.Titulo;
            this.Titulozona = obj.Titulozona;
            this.Titulosecao = obj.Titulosecao;
            this.Cnh = obj.Cnh;
            this.Cnhcategoria = obj.Cnhcategoria;
            this.Cnhvencimento = obj.Cnhvencimento;
            this.Reservista = obj.Reservista;
            this.Rescategoria = obj.Rescategoria;
            this.UFreservista = new UFDTO(obj.UFreservista);
            this.Banco = obj.Banco;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_funcionario = 0;
        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }

        private string cpf = string.Empty;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string rg = string.Empty;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        private DateTime? rgemissao = null;
        public DateTime? Rgemissao
        {
            get { return rgemissao; }
            set { rgemissao = value; }
        }

        private string rgorgao = string.Empty;
        public string Rgorgao
        {
            get { return rgorgao; }
            set { rgorgao = value; }
        }

        private BancoDTO banco = new BancoDTO();
        public BancoDTO Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        private UFDTO ufrg = new UFDTO();
        public UFDTO UFRG
        {
            get { return ufrg; }
            set { ufrg = value; }
        }

        private string carteiramodelo = string.Empty;
        public string Carteiramodelo
        {
            get { return carteiramodelo; }
            set { carteiramodelo = value; }
        }

        private string ctps = string.Empty;
        public string Ctps
        {
            get { return ctps; }
            set { ctps = value; }
        }

        private string ctpsserie = string.Empty;
        public string Ctpsserie
        {
            get { return ctpsserie; }
            set { ctpsserie = value; }
        }

        private DateTime? ctpsemissao = null;
        public DateTime? Ctpsemissao
        {
            get { return ctpsemissao; }
            set { ctpsemissao = value; }
        }

        private UFDTO ufctps = new UFDTO();
        public UFDTO UFCTPS
        {
            get { return ufctps; }
            set { ufctps = value; }
        }

        private string titulo = string.Empty;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private string titulozona = string.Empty;
        public string Titulozona
        {
            get { return titulozona; }
            set { titulozona = value; }
        }

        private string titulosecao = string.Empty;
        public string Titulosecao
        {
            get { return titulosecao; }
            set { titulosecao = value; }
        }

        private string cnh = string.Empty;
        public string Cnh
        {
            get { return cnh; }
            set { cnh = value; }
        }

        private string cnhcategoria = string.Empty;
        public string Cnhcategoria
        {
            get { return cnhcategoria; }
            set { cnhcategoria = value; }
        }

        private DateTime? cnhvencimento = null;
        public DateTime? Cnhvencimento
        {
            get { return cnhvencimento; }
            set { cnhvencimento = value; }
        }

        private string reservista = string.Empty;
        public string Reservista
        {
            get { return reservista; }
            set { reservista = value; }
        }

        private string rescategoria = string.Empty;
        public string Rescategoria
        {
            get { return rescategoria; }
            set { rescategoria = value; }
        }

        private UFDTO ufreservista = new UFDTO();
        public UFDTO UFreservista
        {
            get { return ufreservista; }
            set { ufreservista = value; }
        }

        #region IEquatable<FuncDocumentoDTO> Members
        public bool Equals(FuncDocumentoDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Id_funcionario != obj.Id_funcionario) return false;
            else if (this.Cpf != obj.Cpf) return false;
            else if (this.Rg != obj.Rg) return false;
            else if (this.Rgemissao != obj.Rgemissao) return false;
            else if (this.Rgorgao != obj.Rgorgao) return false;
            else if (!this.UFRG.Equals(obj.UFRG)) return false;
            else if (this.Carteiramodelo != obj.Carteiramodelo) return false;
            else if (this.Ctps != obj.Ctps) return false;
            else if (this.Ctpsserie != obj.Ctpsserie) return false;
            else if (this.Ctpsemissao != obj.Ctpsemissao) return false;
            else if (!this.UFCTPS.Equals(obj.UFCTPS)) return false;
            else if (this.Titulo != obj.Titulo) return false;
            else if (this.Titulozona != obj.Titulozona) return false;
            else if (this.Titulosecao != obj.Titulosecao) return false;
            else if (this.Cnh != obj.Cnh) return false;
            else if (this.Cnhcategoria != obj.Cnhcategoria) return false;
            else if (this.Cnhvencimento != obj.Cnhvencimento) return false;
            else if (this.Reservista != obj.Reservista) return false;
            else if (this.Rescategoria != obj.Rescategoria) return false;
            else if (!this.UFreservista.Equals(obj.UFreservista)) return false;

            return true;
        }
        #endregion
    }
}