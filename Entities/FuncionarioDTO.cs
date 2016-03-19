using System;
using System.Collections.Generic;

namespace MechTech.Entities
{
    [Serializable]
    public class FuncionarioDTO : IEquatable<FuncionarioDTO>
    {
        public FuncionarioDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FuncionarioDTO(FuncionarioDTO obj)
        {
            if (obj == null)
                obj = new FuncionarioDTO();

            this.Id = obj.Id;
            this.Numficharegistro = obj.Numficharegistro;
            this.Numerochapa = obj.Numerochapa;
            this.Nomereduzido = obj.Nomereduzido;
            this.Nomecompleto = obj.Nomecompleto;
            this.Endereco = obj.Endereco;
            this.Numero = obj.Numero;
            this.Complemento = obj.Complemento;
            this.Bairro = obj.Bairro;
            this.Cep = obj.Cep;
            this.Municipio = new MunicipioDTO(obj.Municipio);
            this.Dddtelefone = obj.Dddtelefone;
            this.Telefone = obj.Telefone;
            this.Dddcelular = obj.Dddcelular;
            this.Celular = obj.Celular;
            this.Email = obj.Email;
            this.Sexo = obj.Sexo;
            this.Datanascimento = obj.Datanascimento;
            this.Municipionatural = new MunicipioDTO(obj.Municipionatural);
            this.Datachegadabr = obj.Datachegadabr;
            this.Fgtsoptante = obj.Fgtsoptante;
            this.Fgtsdataopcao = obj.Fgtsdataopcao;
            this.Bancofgts = new BancoDTO(obj.Bancofgts);
            this.Fgtsagencia = obj.Fgtsagencia;
            this.Fgtsagenciadv = obj.Fgtsagenciadv;
            this.Sindicalizado = obj.Sindicalizado;
            this.Bancosalario = new BancoDTO(obj.Bancosalario);
            this.Salconta = obj.Salconta;
            this.Salcontadv1 = obj.Salcontadv1;
            this.Salcontadv2 = obj.Salcontadv2;
            this.Salagencia = obj.Salagencia;
            this.Salagenciadv = obj.Salagenciadv;
            this.Observacao = obj.Observacao;
            this.Salcontatp = obj.Salcontatp;
            this.Foto = obj.Foto;
            this.Nomepai = obj.Nomepai;
            this.Nomemae = obj.Nomemae;
            this.Nomeconjuge = obj.Nomeconjuge;
            this.Documento = new FuncDocumentoDTO(obj.Documento);
            this.Contrato = new FuncContratoDTO(obj.Contrato);
            this.Naturalizado = obj.Naturalizado;

            //LISTAS GENÉRICAS
            foreach (FuncSalarioDTO umsalario in obj.Salario)
            {
                this.Salario.Add(new FuncSalarioDTO(umsalario));
            }
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private List<FuncSalarioDTO> salario = new List<FuncSalarioDTO>();
        public List<FuncSalarioDTO> Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        private int numficharegistro = 0;
        public int Numficharegistro
        {
            get { return numficharegistro; }
            set { numficharegistro = value; }
        }

        private int numerochapa = 0;
        public int Numerochapa
        {
            get { return numerochapa; }
            set { numerochapa = value; }
        }

        private string nomereduzido = string.Empty;
        public string Nomereduzido
        {
            get { return nomereduzido; }
            set { nomereduzido = value; }
        }

        private string nomecompleto = string.Empty;
        public string Nomecompleto
        {
            get { return nomecompleto; }
            set { nomecompleto = value; }
        }

        private string endereco = string.Empty;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string numero = string.Empty;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento = string.Empty;
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string bairro = string.Empty;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cep = string.Empty;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private MunicipioDTO municipio = new MunicipioDTO();
        public MunicipioDTO Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        private string dddtelefone = string.Empty;
        public string Dddtelefone
        {
            get { return dddtelefone; }
            set { dddtelefone = value; }
        }

        private string telefone = string.Empty;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string dddcelular = string.Empty;
        public string Dddcelular
        {
            get { return dddcelular; }
            set { dddcelular = value; }
        }

        private string celular = string.Empty;
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string sexo = string.Empty;
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private string tiposangue = string.Empty;
        public string Tiposangue
        {
            get { return tiposangue; }
            set { tiposangue = value; }
        }

        private DateTime? datanascimento = null;
        public DateTime? Datanascimento
        {
            get { return datanascimento; }
            set { datanascimento = value; }
        }

        private MunicipioDTO municipionatural = new MunicipioDTO();
        public MunicipioDTO Municipionatural
        {
            get { return municipionatural; }
            set { municipionatural = value; }
        }

        private DateTime? datachegadabr = null;
        public DateTime? Datachegadabr
        {
            get { return datachegadabr; }
            set { datachegadabr = value; }
        }

        private bool fgtsoptante = true;
        public bool Fgtsoptante
        {
            get { return fgtsoptante; }
            set { fgtsoptante = value; }
        }

        private DateTime? fgtsdataopcao = null;
        public DateTime? Fgtsdataopcao
        {
            get { return fgtsdataopcao; }
            set { fgtsdataopcao = value; }
        }

        private BancoDTO bancofgts = new BancoDTO();
        public BancoDTO Bancofgts
        {
            get { return bancofgts; }
            set { bancofgts = value; }
        }

        private string fgtsagencia = string.Empty;
        public string Fgtsagencia
        {
            get { return fgtsagencia; }
            set { fgtsagencia = value; }
        }

        private string fgtsagenciadv = string.Empty;
        public string Fgtsagenciadv
        {
            get { return fgtsagenciadv; }
            set { fgtsagenciadv = value; }
        }

        private bool sindicalizado = false;
        public bool Sindicalizado
        {
            get { return sindicalizado; }
            set { sindicalizado = value; }
        }

        private BancoDTO bancosalario = new BancoDTO();
        public BancoDTO Bancosalario
        {
            get { return bancosalario; }
            set { bancosalario = value; }
        }

        private string salconta = string.Empty;
        public string Salconta
        {
            get { return salconta; }
            set { salconta = value; }
        }

        private string salcontadv1 = string.Empty;
        public string Salcontadv1
        {
            get { return salcontadv1; }
            set { salcontadv1 = value; }
        }

        private string salcontadv2 = string.Empty;
        public string Salcontadv2
        {
            get { return salcontadv2; }
            set { salcontadv2 = value; }
        }

        private string salagencia = string.Empty;
        public string Salagencia
        {
            get { return salagencia; }
            set { salagencia = value; }
        }

        private string salagenciadv = string.Empty;
        public string Salagenciadv
        {
            get { return salagenciadv; }
            set { salagenciadv = value; }
        }

        private string observacao = string.Empty;
        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        private string salcontatp = string.Empty;
        public string Salcontatp
        {
            get { return salcontatp; }
            set { salcontatp = value; }
        }

        private byte[] foto = null;
        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private string nomepai = string.Empty;
        public string Nomepai
        {
            get { return nomepai; }
            set { nomepai = value; }
        }

        private string nomemae = string.Empty;
        public string Nomemae
        {
            get { return nomemae; }
            set { nomemae = value; }
        }

        private string nomeconjuge = string.Empty;
        public string Nomeconjuge
        {
            get { return nomeconjuge; }
            set { nomeconjuge = value; }
        }

        private FuncDocumentoDTO documento = new FuncDocumentoDTO();
        public FuncDocumentoDTO Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private FuncContratoDTO contrato = new FuncContratoDTO();
        public FuncContratoDTO Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        //SELEÇÃO POR DEPARTAMENTO
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private DepartamentoDTO departamento = new DepartamentoDTO();
        public DepartamentoDTO Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        //

        private bool selecao = false;
        public bool Selecao
        {
            get { return selecao; }
            set { selecao = value; }
        }

        private bool naturalizado = false;
        public bool Naturalizado
        {
            get { return naturalizado; }
            set { naturalizado = value; }
        }

        private string obsbasica = string.Empty; //11141
        public string Obsbasica
        {
            get { return obsbasica; }
            set { obsbasica = value; }
        }

        private string situacao = string.Empty;
        /// <summary>
        /// Admitido, Demitido, Afastado, etc.
        /// </summary>
        public string Situacao //41252
        {
            get { return situacao; }
            set { situacao = value; }
        }

        private FuncSalarioDTO salarioAtual = new FuncSalarioDTO(); //41252
        public FuncSalarioDTO SalarioAtual
        {
            get { return salarioAtual; }
            set { salarioAtual = value; }
        }

        #region IEquatable<FuncionarioDTO> Members
        public bool Equals(FuncionarioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Numficharegistro != obj.Numficharegistro) return false;
            else if (this.Numerochapa != obj.Numerochapa) return false;
            else if (this.Nomereduzido != obj.Nomereduzido) return false;
            else if (this.Nomecompleto != obj.Nomecompleto) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Dddtelefone != obj.Dddtelefone) return false;
            else if (this.Telefone != obj.Telefone) return false;
            else if (this.Dddcelular != obj.Dddcelular) return false;
            else if (this.Celular != obj.Celular) return false;
            else if (this.Email != obj.Email) return false;
            else if (this.Sexo != obj.Sexo) return false;
            else if (this.Tiposangue != obj.Tiposangue) return false;
            else if (this.Datanascimento != obj.Datanascimento) return false;
            else if (!this.Municipionatural.Equals(obj.Municipionatural)) return false;
            else if (this.Datachegadabr != obj.Datachegadabr) return false;
            else if (this.Fgtsoptante != obj.Fgtsoptante) return false;
            else if (this.Fgtsdataopcao != obj.Fgtsdataopcao) return false;
            else if (!this.Bancofgts.Equals(obj.Bancofgts)) return false;
            else if (this.Fgtsagencia != obj.Fgtsagencia) return false;
            else if (this.Fgtsagenciadv != obj.Fgtsagenciadv) return false;
            else if (this.Sindicalizado != obj.Sindicalizado) return false;
            else if (!this.Bancosalario.Equals(obj.Bancosalario)) return false;
            else if (this.Salconta != obj.Salconta) return false;
            else if (this.Salcontadv1 != obj.Salcontadv1) return false;
            else if (this.Salcontadv2 != obj.Salcontadv2) return false;
            else if (this.Salagencia != obj.Salagencia) return false;
            else if (this.Salagenciadv != obj.Salagenciadv) return false;
            else if (this.Observacao != obj.Observacao) return false;
            else if (this.Salcontatp != obj.Salcontatp) return false;
            else if (this.Foto != obj.Foto) return false;
            else if (this.Nomepai != obj.Nomepai) return false;
            else if (this.Nomemae != obj.Nomemae) return false;
            else if (this.Nomeconjuge != obj.Nomeconjuge) return false;
            else if (!this.Documento.Equals(obj.Documento)) return false;
            else if (!this.Contrato.Equals(obj.Contrato)) return false;
            else if (!this.Naturalizado.Equals(obj.Naturalizado)) return false;

            //LISTAS GENÉRICAS
            if (this.Salario.Count != obj.Salario.Count)
                return false;
            else
            {
                foreach (FuncSalarioDTO umsalario in this.Salario)
                {
                    try
                    {
                        if (!umsalario.Equals(obj.Salario.Find(delegate(FuncSalarioDTO item) { return item.Id == umsalario.Id; })))
                            return false;
                    }
                    catch { return false; }
                }
            }
            //

            return true;
        }

        public bool EqualsAltCadastral(FuncionarioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Nomecompleto != obj.Nomecompleto) return false;
            else if (this.Endereco != obj.Endereco) return false;
            else if (this.Numero != obj.Numero) return false;
            else if (this.Complemento != obj.Complemento) return false;
            else if (this.Bairro != obj.Bairro) return false;
            else if (this.Cep != obj.Cep) return false;
            else if (!this.Municipio.Equals(obj.Municipio)) return false;
            else if (this.Dddtelefone != obj.Dddtelefone) return false;
            else if (this.Telefone != obj.Telefone) return false;
            else if (this.Dddcelular != obj.Dddcelular) return false;
            else if (this.Celular != obj.Celular) return false;
            else if (this.Email != obj.Email) return false;
            else if (this.Sexo != obj.Sexo.Substring(0, 1)) return false;
            else if (this.Datanascimento != obj.Datanascimento) return false;
            else if (!this.Municipionatural.Equals(obj.Municipionatural)) return false;
            else if (!this.Bancosalario.Equals(obj.Bancosalario)) return false;
            else if (this.Salconta != obj.Salconta) return false;
            else if (this.Salcontadv1 != obj.Salcontadv1) return false;
            else if (this.Salcontadv2 != obj.Salcontadv2) return false;
            else if (this.Salagencia != obj.Salagencia) return false;
            else if (this.Salagenciadv != obj.Salagenciadv) return false;
            else if (this.Salcontatp != obj.Salcontatp) return false;
            else if (this.Nomepai != obj.Nomepai) return false;
            else if (this.Nomemae != obj.Nomemae) return false;
            else if (this.Documento.Cpf != obj.Documento.Cpf) return false;
            else if (this.Documento.Rg != obj.Documento.Rg) return false;
            else if (this.Documento.Rgemissao != obj.Documento.Rgemissao) return false;
            else if (this.Documento.Rgorgao != obj.Documento.Rgorgao) return false;
            else if (this.Documento.Ctps != obj.Documento.Ctps) return false;
            else if (this.Documento.Ctpsserie != obj.Documento.Ctpsserie) return false;
            else if (!this.Documento.UFCTPS.Equals(obj.Documento.UFCTPS)) return false;

            return true;
        }

        public bool EqualsAltContratual(FuncionarioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Salario[0].Funcao.Id != obj.Salario[0].Funcao.Id) return false;
            else if (this.Departamento.Id != obj.Departamento.Id) return false;
            else if (this.Salario[0].Salario != obj.Salario[0].Salario) return false;

            return true;
        }
        #endregion
    }
}