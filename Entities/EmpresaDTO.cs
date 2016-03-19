using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using MechTech.Entities;

namespace MechTech.Entities
{
    [Serializable]
    public class EmpresaDTO : IEquatable<EmpresaDTO>
    {
        public EmpresaDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public EmpresaDTO(EmpresaDTO obj)
        {
            this.Id = obj.Id;
            this.Nomefantasia = obj.Nomefantasia;
            this.Razaosocial = obj.Razaosocial;
            this.Endereco = obj.Endereco;
            this.Numero = obj.Numero;
            this.Complemento = obj.Complemento;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.Municipio = new MunicipioDTO(obj.Municipio);
            this.Dddtelefone = obj.Dddtelefone;
            this.Telefone = obj.Telefone;
            this.Dddfax = obj.Dddfax;
            this.Fax = obj.Fax;
            this.Cnpj = obj.Cnpj;
            this.Cei = obj.Cei;
            this.Iestadual = obj.Iestadual;
            this.Imunicipal = obj.Imunicipal;
            this.Registro = obj.Registro;
            this.Orgaoregistro = obj.Orgaoregistro;
            this.Dataregistro = obj.Dataregistro;
            this.Inicioatividade = obj.Inicioatividade;
            this.Encerratividade = obj.Encerratividade;
            this.Naturezajuridica = new NaturezaJuridicaDTO(obj.Naturezajuridica);
            this.CNAE = new CNAEDTO(obj.CNAE);
            this.Url = obj.Url;
            this.Email = obj.Email;
            this.Especialidade = obj.Especialidade;
            this.Tipo = obj.Tipo;
            this.Mesano = obj.Mesano;
            this.Arredondamento = obj.Arredondamento;
            this.Proprietario = obj.Proprietario;
            this.Logotipo = obj.Logotipo;
            this.Marcadagua = obj.Marcadagua;
            this.Porte = new PorteDTO(obj.Porte);
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nomefantasia = string.Empty;
        public string Nomefantasia
        {
            get { return nomefantasia; }
            set { nomefantasia = value; }
        }

        private string razaosocial = string.Empty;
        public string Razaosocial
        {
            get { return razaosocial; }
            set { razaosocial = value; }
        }

        private string endereco = string.Empty;
        [XmlIgnore]
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string numero = string.Empty;
        [XmlIgnore]
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento = string.Empty;
        [XmlIgnore]
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string bairro = string.Empty;
        [XmlIgnore]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cep = string.Empty;
        [XmlIgnore]
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private MunicipioDTO municipio = new MunicipioDTO();
        [XmlIgnore]
        public MunicipioDTO Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private string dddtelefone = string.Empty;
        [XmlIgnore]
        public string Dddtelefone
        {
            get { return dddtelefone; }
            set { dddtelefone = value; }
        }

        private string telefone = string.Empty;
        [XmlIgnore]
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string dddfax = string.Empty;
        [XmlIgnore]
        public string Dddfax
        {
            get { return dddfax; }
            set { dddfax = value; }
        }

        private string fax = string.Empty;
        [XmlIgnore]
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string cnpj = string.Empty;
        [XmlIgnore]
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string cei = string.Empty;
        [XmlIgnore]
        public string Cei
        {
            get { return cei; }
            set { cei = value; }
        }

        private string iestadual = string.Empty;
        [XmlIgnore]
        public string Iestadual
        {
            get { return iestadual; }
            set { iestadual = value; }
        }

        private string imunicipal = string.Empty;
        [XmlIgnore]
        public string Imunicipal
        {
            get { return imunicipal; }
            set { imunicipal = value; }
        }

        private string registro = string.Empty;
        [XmlIgnore]
        public string Registro
        {
            get { return registro; }
            set { registro = value; }
        }

        private string orgaoregistro = string.Empty;
        [XmlIgnore]
        public string Orgaoregistro
        {
            get { return orgaoregistro; }
            set { orgaoregistro = value; }
        }

        private DateTime? dataregistro = null;
        [XmlIgnore]
        public DateTime? Dataregistro
        {
            get { return dataregistro; }
            set { dataregistro = value; }
        }

        private DateTime? inicioatividade = null;
        [XmlIgnore]
        public DateTime? Inicioatividade
        {
            get { return inicioatividade; }
            set { inicioatividade = value; }
        }

        private DateTime? encerratividade = null;
        [XmlIgnore]
        public DateTime? Encerratividade
        {
            get { return encerratividade; }
            set { encerratividade = value; }
        }

        private decimal valorcapital = 0;
        [XmlIgnore]
        public decimal Valorcapital
        {
            get { return valorcapital; }
            set { valorcapital = value; }
        }

        private NaturezaJuridicaDTO naturezajuridica = new NaturezaJuridicaDTO();
        [XmlIgnore]
        public NaturezaJuridicaDTO Naturezajuridica
        {
            get { return naturezajuridica; }
            set { naturezajuridica = value; }
        }

        private CNAEDTO _CNAE = new CNAEDTO();
        [XmlIgnore]
        public CNAEDTO CNAE
        {
            get { return _CNAE; }
            set { _CNAE = value; }
        }

        private string url = string.Empty;
        [XmlIgnore]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string email = string.Empty;
        [XmlIgnore]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        //private GPSPagamentoDTO _GPSpagamento = new GPSPagamentoDTO();
        //[XmlIgnore]
        //public GPSPagamentoDTO GPSpagamento
        //{
        //    get { return _GPSpagamento; }
        //    set { _GPSpagamento = value; }
        //}

        //private FPASDTO _FPAS = new FPASDTO();
        //[XmlIgnore]
        //public FPASDTO FPAS
        //{
        //    get { return _FPAS; }
        //    set { _FPAS = value; }
        //}

        private DateTime mesano = Convert.ToDateTime("01/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
        public DateTime Mesano
        {
            get { return mesano; }
            set { mesano = value; }
        }

        private bool arredondamento = false;
        [XmlIgnore]
        public bool Arredondamento
        {
            get { return arredondamento; }
            set { arredondamento = value; }
        }

        //private string regimepagtoirrf = "Competência";
        //[XmlIgnore]
        //public string Regimepagtoirrf
        //{
        //    get { return regimepagtoirrf; }
        //    set { regimepagtoirrf = value; }
        //}

        //private string codigoterceiro = string.Empty;
        //[XmlIgnore]
        //public string Codigoterceiro
        //{
        //    get { return codigoterceiro; }
        //    set { codigoterceiro = value; }
        //}

        //private decimal percentualterceiro = 0;
        //[XmlIgnore]
        //public decimal Percentualterceiro
        //{
        //    get { return percentualterceiro; }
        //    set { percentualterceiro = value; }
        //}

        //private decimal percentualrat = 0;
        //[XmlIgnore]
        //public decimal Percentualrat
        //{
        //    get { return percentualrat; }
        //    set { percentualrat = value; }
        //}

        //private decimal percentualempresa = 0;
        //[XmlIgnore]
        //public decimal Percentualempresa
        //{
        //    get { return percentualempresa; }
        //    set { percentualempresa = value; }
        //}

        private int proprietario = 1;
        [XmlIgnore]
        public int Proprietario
        {
            get { return proprietario; }
            set { proprietario = value; }
        }

        private SimplesDTO simples = new SimplesDTO();
        [XmlIgnore]
        public SimplesDTO Simples
        {
            get { return simples; }
            set { simples = value; }
        }

        private bool pat = false;
        [XmlIgnore]
        public bool Pat
        {
            get { return pat; }
            set { pat = value; }
        }

        //
        private string especialidade = string.Empty;
        [XmlIgnore]
        public string Especialidade
        {
            get { return especialidade; }
            set { especialidade = value; }
        }

        private byte[] logotipo = null;
        [XmlIgnore]
        public byte[] Logotipo
        {
            get { return logotipo; }
            set { logotipo = value; }
        }

        private byte[] marcadagua = null;
        [XmlIgnore]
        public byte[] Marcadagua
        {
            get { return marcadagua; }
            set { marcadagua = value; }
        }

        private int transparenciaMarcaDagua = 0;
        public int TransparenciaMarcaDagua
        {
            get { return transparenciaMarcaDagua; }
            set { transparenciaMarcaDagua = value; }
        }

        private string chave = string.Empty;
        [XmlIgnore]
        public string Chave
        {
            get { return chave; }
            set { chave = value; }
        }

        private string tipo = "J";
        [XmlIgnore]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private PorteDTO porte = new PorteDTO();
        [XmlIgnore]
        public PorteDTO Porte
        {
            get { return porte; }
            set { porte = value; }
        }

        private List<FAPDTO> faps = new List<FAPDTO>();
        [XmlIgnore]
        public List<FAPDTO> FAPS
        {
            get { return faps; }
            set { faps = value; }
        }

        private DateTime? datatrava = null;
        [XmlIgnore]
        public DateTime? DataTrava
        {
            get { return datatrava; }
            set { datatrava = value; }
        }

        #region XMLSERIALIZER
        public void Serializar()
        {
            try
            {
                XmlSerializer serializar = new XmlSerializer(typeof(EmpresaDTO));
                FileStream fs = File.Create(MechTech.Util.Global.LocalPath + @"\Sistemas\MechTech\appConfig.xml");
                serializar.Serialize(fs, this);
                fs.Close();
            }
            catch { }
        }

        public EmpresaDTO Deserializar()
        {
            EmpresaDTO empresa = null;
            try
            {
                XmlSerializer deserializar = new XmlSerializer(typeof(EmpresaDTO));
                FileStream fs = File.OpenRead(MechTech.Util.Global.LocalPath + @"\Sistemas\MechTech\appConfig.xml");
                empresa = (EmpresaDTO)deserializar.Deserialize(fs);
                fs.Close();
            }
            catch { }
            return empresa;
        }
        #endregion

        #region IEquatable<EmpresaDTO> Members
        public bool Equals(EmpresaDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nomefantasia != obj.Nomefantasia) return false;
            else if (this.Razaosocial != obj.Razaosocial) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Dddtelefone != obj.Dddtelefone) return false;
            else if (this.Telefone != obj.Telefone) return false;
            else if (this.Dddfax != obj.Dddfax) return false;
            else if (this.Fax != obj.Fax) return false;
            else if (this.Cnpj != obj.Cnpj) return false;
            else if (this.Cei != obj.Cei) return false;
            else if (this.Iestadual != obj.Iestadual) return false;
            else if (this.Imunicipal != obj.Imunicipal) return false;
            else if (this.Registro != obj.Registro) return false;
            else if (this.Orgaoregistro != obj.Orgaoregistro) return false;
            else if (this.Dataregistro != obj.Dataregistro) return false;
            else if (this.Inicioatividade != obj.Inicioatividade) return false;
            else if (this.Encerratividade != obj.Encerratividade) return false;
            else if (!this.Naturezajuridica.Equals(obj.Naturezajuridica)) return false;
            else if (!this.CNAE.Equals(obj.CNAE)) return false;
            else if (this.Url != obj.Url) return false;
            else if (this.Email != obj.Email) return false;
            else if (this.Mesano != obj.Mesano) return false;
            else if (this.Especialidade != obj.Especialidade) return false;
            else if (this.Tipo != obj.Tipo) return false;
            else if (!this.Porte.Equals(obj.Porte)) return false;
            return true;
        }
        #endregion
    }
}
