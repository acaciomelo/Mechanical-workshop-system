using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Util
{
    public sealed class Enumeradores
    {
        public enum TipoRecebimento
        {
            Dinheiro,
            CartaoDebito,
            CartaoCredito,
            Cheque,
            Boleto,
            Outro
        }
        public enum TipoSalario
        {
            /// <summary>
            /// Todos os funcionários exceto Pro-Labore.
            /// </summary>
            TodosEmpregados = -1,
            Todos = 0,
            Mensalista = 1,
            Horista = 2,
            Comissionista = 3,
            Estagiario = 4,
            ProLabore = 5,
            Autonomo = 6
        }

        public enum Processamento
        {
            Mensal = 1
        }
        public enum Sistema
        {
            Mirror,
            Modulos,
            MECHTECH
        }

        public enum Divisor
        {
            Nenhum = 0,
            Dias30 = 1,
            Horas220 = 2,
            Dias28293031 = 3,
            DiasDSR = 4,
            TipoSalario = 5,
            Horas220ref = 6,
            Percentual = 7,
            DiasUteis = 8,
            Horas200 = 9,
            ValorFixo = 10
        }

        public enum RotinaLOG
        {
            Nenhuma = 0,
            Empresas = 1002,
            CBO = 1004,
            Municipio = 1006,
            Sindicatos = 1010,
            Responsaveis = 1012,
            Funcoes = 1013,
            Funcionarios = 1014,
            Departamentos = 1016,
            Eventos = 1019,
            Calendario = 1020,
            DigitacaoHolerith = 1022,
            TabelaINSSIRRF = 1023,
            SelecionarEmpresa = 1028,
            AdiantamentoSalario = 1031,
            ProcessamentoFolha = 1033,
            FinalMes = 1034,
            FolhaPagamento = 1039,
            ImpressaoHolerith = 1042,
            Horarios = 1048,
            FichaFinanceira = 1049,
            Ferias = 1050,
            Rescisao = 1051,
            Salario13 = 1052,
            ProvisaoFerias13Salario = 1056,
            SEFIP = 1057,
            CAGED = 1058,
            GRRF = 1059,
            ConfiguracaoContabil = 1061,
            CopiaConfiguracaoContabil = 106161,
            ExportacaoContabil = 1062,
            ImportacaoComissao = 1064,
            ProgramacaoFerias = 1066,
            FeriasRecebidas = 1067,
            EventosProcessados = 1068,
            Etiquetas = 1070,
            SeguroDesemprego = 1073,
            BancoPadraoFEBRABAN240 = 1075,
            Usuarios = 2,
            MANAD = 1083,
            ImportacaoVales = 1084,
            AtivacaoSistema = 1085,
            Parametros = 1088,
            ReajusteSalarial = 1185,
            ImportacaoDados = 1188,
            HonorariosAutonomos = 1191,
            DuploVinculo = 1193,
            //.
            //.
            //.
            FolhaComplementar = 1238,
            //.
            TransferenciaFuncionario = 1287
        }
        public enum Modulo
        {
            Nenhum,
            Funcionario,
            Adiantamento,
            Holerith,
            Ferias,
            Adiantamento13,
            Salario13,
            Recalculo13,
            Rescisao,
            Provisao,
            SEFIP,
            CAGED,
            GRRF,
            ConfiguracaoContabil,
            ExportacaoContabil,
            ImportacaoComissao,
            ImportacaoVale,
            ExportacaoBancoFEBRABAN240,
            ExportacaoBancoITAUSISPAG240,
            MANAD,
            ReajusteSalarial,
            RAIS,
            SeguroDesemprego,
            Complementar,
            Documentos,
            Media_MediaRemuneracao,
            Ficha_Financeira,
            ExportacaoBancoBradesco
        }

        public enum TipoOperacao
        {
            Insert,
            Update,
            Delete,
            Select,
            Viewer,
            Print,
            Copy,
            None
        }

        public enum TipoResposta
        {
            Completed,
            Cancel
        }

        public enum TipoConexao
        {
            LAN,
            WS
        }

        public enum TipoExcessao
        {
            Sistema,
            Usuario
        }

        public enum TipoAcao
        {
            Desabilitar,
            Ocultar
        }
    }
}