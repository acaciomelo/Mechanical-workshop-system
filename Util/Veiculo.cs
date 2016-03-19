using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Util
{
    public class Veiculo
    {
        public static List<Rotina> ObterTipo()
        {
            List<Rotina> Tipos = new List<Rotina>();
            Tipos.Add(new Rotina(1, "AUTOMÓVEL"));
            Tipos.Add(new Rotina(5, "BUGGY"));
            Tipos.Add(new Rotina(6, "CAMINHAO"));
            Tipos.Add(new Rotina(7, "CARRETA"));
            Tipos.Add(new Rotina(9, "EMPILHADEIRA"));
            //Tipos.Add(new Rotina(10, "GAIOLA"));
            Tipos.Add(new Rotina(11, "MOTO AQUÁTICA"));
            Tipos.Add(new Rotina(12, "LANCHA"));
            //Tipos.Add(new Rotina(13, "MINI BUGGY"));
            //Tipos.Add(new Rotina(14, "MINI MOTO"));
            //Tipos.Add(new Rotina(15, "MOTO NIVELADORA"));
            Tipos.Add(new Rotina(16, "MOTOR DE POPA"));
            Tipos.Add(new Rotina(17, "MOTO"));
            //Tipos.Add(new Rotina(18, "MOTO ELÉTRICA"));
            Tipos.Add(new Rotina(19, "ÔNIBUS"));
            Tipos.Add(new Rotina(20, "QUADRICULO"));
            //Tipos.Add(new Rotina(21, "REBOQUE"));
            Tipos.Add(new Rotina(22, "TRATOR"));
            //Tipos.Add(new Rotina(23, "TRICICLO"));
            Tipos.Add(new Rotina(24, "BARCO"));
            return Tipos;
        }

        public static List<Rotina> ObterMarcasCarros()
        {
            List<Rotina> Veiculos = new List<Rotina>();

            Veiculos.Add(new Rotina(1, "ASIA MOTORS"));
            Veiculos.Add(new Rotina(2, "AUDI"));
            Veiculos.Add(new Rotina(3, "BMW"));
            Veiculos.Add(new Rotina(4, "CBT"));
            Veiculos.Add(new Rotina(5, "CHANA"));
            Veiculos.Add(new Rotina(6, "CHERY"));
            Veiculos.Add(new Rotina(7, "CHEVROLET"));
            Veiculos.Add(new Rotina(8, "CHRYSLER"));
            Veiculos.Add(new Rotina(9, "CITROEN"));
            Veiculos.Add(new Rotina(10, "DAEWOO"));
            Veiculos.Add(new Rotina(11, "DAIHATSU"));
            Veiculos.Add(new Rotina(12, "DESOTO"));
            Veiculos.Add(new Rotina(13, "DKV"));
            Veiculos.Add(new Rotina(14, "DODGE"));
            Veiculos.Add(new Rotina(15, "EFFA MOTORS"));
            Veiculos.Add(new Rotina(16, "FIAT"));
            Veiculos.Add(new Rotina(17, "FORD"));
            Veiculos.Add(new Rotina(18, "GURGEL"));
            Veiculos.Add(new Rotina(19, "HAFEI"));
            Veiculos.Add(new Rotina(20, "HONDA"));
            Veiculos.Add(new Rotina(21, "JAC"));
            Veiculos.Add(new Rotina(23, "HUMMER"));
            Veiculos.Add(new Rotina(24, "HYUNDAI"));
            Veiculos.Add(new Rotina(25, "INFINITI"));
            Veiculos.Add(new Rotina(26, "LADA"));
            Veiculos.Add(new Rotina(27, "JAGUAR"));
            Veiculos.Add(new Rotina(28, "JEEP"));
            Veiculos.Add(new Rotina(29, "JPX"));
            Veiculos.Add(new Rotina(30, "KIA"));
            Veiculos.Add(new Rotina(31, "LADA"));
            Veiculos.Add(new Rotina(32, "LAND ROVER"));
            Veiculos.Add(new Rotina(33, "LIFAN"));
            Veiculos.Add(new Rotina(34, "MAZDA"));
            Veiculos.Add(new Rotina(35, "MERCEDES-BENZ"));
            Veiculos.Add(new Rotina(36, "MINI"));
            Veiculos.Add(new Rotina(37, "MITSUBISHI"));
            Veiculos.Add(new Rotina(38, "MIURA"));
            Veiculos.Add(new Rotina(39, "MP"));
            Veiculos.Add(new Rotina(40, "NISSAN"));
            Veiculos.Add(new Rotina(41, "OLDSMOBILE"));
            Veiculos.Add(new Rotina(42, "PEUGEOT"));
            Veiculos.Add(new Rotina(43, "PORSCHE"));
            Veiculos.Add(new Rotina(44, "PUMA"));
            Veiculos.Add(new Rotina(45, "RELY"));
            Veiculos.Add(new Rotina(46, "RENAULT"));
            Veiculos.Add(new Rotina(47, "SEAT"));
            Veiculos.Add(new Rotina(48, "SHELBY"));
            Veiculos.Add(new Rotina(49, "SMART"));
            Veiculos.Add(new Rotina(50, "SSANGYONG"));
            Veiculos.Add(new Rotina(51, "SUBARU"));
            Veiculos.Add(new Rotina(52, "SUZUKI"));
            Veiculos.Add(new Rotina(53, "TOYOTA"));
            Veiculos.Add(new Rotina(54, "TROLLER"));
            Veiculos.Add(new Rotina(55, "VOLKSWAGEN"));
            Veiculos.Add(new Rotina(56, "WILLYS"));
            Veiculos.Add(new Rotina(57, "WILLYS OVERLAND"));
            Veiculos.Add(new Rotina(58, "VOLVO"));
            Veiculos.Add(new Rotina(59, "ALFA ROMEO"));
            return Veiculos;
        }

        public static List<Rotina> ObterMarcasMotorPopa()
        {
            List<Rotina> Motor = new List<Rotina>();
            Motor.Add(new Rotina(1, "MERCURY"));
            Motor.Add(new Rotina(2, "YAMAHA"));
            return Motor;
        }

        public static List<Rotina> ObterMarcasOnibus()
        {
            List<Rotina> Onibus = new List<Rotina>();
            Onibus.Add(new Rotina(1, "AGRALE"));
            Onibus.Add(new Rotina(2, "BUSSCAR"));
            Onibus.Add(new Rotina(3, "CAIO"));
            Onibus.Add(new Rotina(4, "CHEVROLET"));
            Onibus.Add(new Rotina(5, "CIFERAL"));
            Onibus.Add(new Rotina(6, "COBRASMA"));
            Onibus.Add(new Rotina(7, "COMIL"));
            Onibus.Add(new Rotina(8, "FORD"));
            Onibus.Add(new Rotina(9, "IVECO"));
            Onibus.Add(new Rotina(10, "MARCOPOLO"));
            Onibus.Add(new Rotina(11, "MERCEDES-BENZ"));
            Onibus.Add(new Rotina(12, "NEOBUS"));
            Onibus.Add(new Rotina(13, "SCANIA"));
            Onibus.Add(new Rotina(14, "VOLKSWAGEN"));
            Onibus.Add(new Rotina(15, "VOLVO"));
            return Onibus;

        }

        public static List<Rotina> ObterMarcasBarcos()
        {
            List<Rotina> Barcos = new List<Rotina>();

            Barcos.Add(new Rotina(1, "ARUAK"));
            Barcos.Add(new Rotina(2, "BIG FISH"));
            Barcos.Add(new Rotina(3, "CHATA"));
            Barcos.Add(new Rotina(4, "GRAND FISH"));
            Barcos.Add(new Rotina(5, "ARUAK"));
            Barcos.Add(new Rotina(6, "MG"));
            Barcos.Add(new Rotina(7, "KARIB"));
            Barcos.Add(new Rotina(8, "QUEST"));
            Barcos.Add(new Rotina(9, "SAVAGE"));

            return Barcos;
        }

        public static List<Rotina> ObterMarcasQuadricliclos()
        {
            List<Rotina> Quadriciclos = new List<Rotina>();
            Quadriciclos.Add(new Rotina(1, "ATV"));
            Quadriciclos.Add(new Rotina(2, "HONDA"));
            Quadriciclos.Add(new Rotina(3, "POLARIS"));
            return Quadriciclos;
        }

        public static List<Rotina> ObterMarcasLanchas()
        {
            List<Rotina> Lanchas = new List<Rotina>();
            Lanchas.Add(new Rotina(1, "DIAMAR"));
            Lanchas.Add(new Rotina(2, "FIBRAFORT"));
            Lanchas.Add(new Rotina(3, "NAUPLAS"));
            Lanchas.Add(new Rotina(4, "PHOENIX"));
            Lanchas.Add(new Rotina(5, "VENTURA"));
            return Lanchas;

        }

        public static List<Rotina> ObterMarcasMotos()
        {
            List<Rotina> Motos = new List<Rotina>();
            Motos.Add(new Rotina(1, "AMAZONAS"));
            Motos.Add(new Rotina(2, "BMW"));
            Motos.Add(new Rotina(3, "DAELIM"));
            Motos.Add(new Rotina(4, "DAFRA"));
            Motos.Add(new Rotina(5, "DUCATI"));
            Motos.Add(new Rotina(6, "GREEN"));
            Motos.Add(new Rotina(7, "HAOBAO"));
            Motos.Add(new Rotina(8, "HARLEY-DAVIDSON"));
            Motos.Add(new Rotina(9, "HONDA"));
            Motos.Add(new Rotina(10, "HUSQVARNA"));
            Motos.Add(new Rotina(11, "KASINSKI"));
            Motos.Add(new Rotina(12, "KAWASAKI"));
            Motos.Add(new Rotina(13, "KTM"));
            Motos.Add(new Rotina(14, "MIZA"));
            Motos.Add(new Rotina(15, "MVK"));
            Motos.Add(new Rotina(16, "PIAGGIO"));
            Motos.Add(new Rotina(17, "REGAL RAPTOR"));
            Motos.Add(new Rotina(18, "SHINERAY"));
            Motos.Add(new Rotina(19, "SUNDOWN"));
            Motos.Add(new Rotina(20, "SUZUKI"));
            Motos.Add(new Rotina(21, "TRIUMPH"));
            Motos.Add(new Rotina(22, "YAMAHA"));
            return Motos;
        }

        public static List<Rotina> ObterMarcasBuggys()
        {
            List<Rotina> Buggys = new List<Rotina>();
            Buggys.Add(new Rotina(1, "BABY"));
            Buggys.Add(new Rotina(2, "BRM"));
            Buggys.Add(new Rotina(3, "BUGRE"));
            Buggys.Add(new Rotina(4, "CARIBE"));
            Buggys.Add(new Rotina(5, "FIBRAV"));
            Buggys.Add(new Rotina(6, "JOBBY"));
            Buggys.Add(new Rotina(7, "KADRON"));
            return Buggys;
        }

        public static List<Rotina> ObterMarcasTratores()
        {
            List<Rotina> Tratores = new List<Rotina>();
            Tratores.Add(new Rotina(1, "AGRALE"));
            Tratores.Add(new Rotina(2, "FORD"));
            Tratores.Add(new Rotina(3, "MASSEY FERGUSON"));
            Tratores.Add(new Rotina(4, "TROY BILT"));
            Tratores.Add(new Rotina(5, "VALMET"));
            return Tratores;
        }

        public static List<Rotina> ObterMarcasCaminhoes()
        {
            List<Rotina> Caminhoes = new List<Rotina>();
            Caminhoes.Add(new Rotina(1, "CHEVROLET"));
            Caminhoes.Add(new Rotina(2, "FIAT"));
            Caminhoes.Add(new Rotina(3, "FORD"));
            Caminhoes.Add(new Rotina(4, "GMC"));
            Caminhoes.Add(new Rotina(5, "HYUNDAI"));
            Caminhoes.Add(new Rotina(6, "IVECO"));
            Caminhoes.Add(new Rotina(7, "KIA"));
            Caminhoes.Add(new Rotina(8, "MERCEDES-BENZ"));
            Caminhoes.Add(new Rotina(9, "SCANIA"));
            Caminhoes.Add(new Rotina(10, "VOLKSWAGEN"));
            return Caminhoes;
        }

        public static List<Rotina> ObterMarcasCarretas()
        {
            List<Rotina> Carretas = new List<Rotina>();
            Carretas.Add(new Rotina(1, "FNG"));
            Carretas.Add(new Rotina(2, "LIBRELATO"));
            Carretas.Add(new Rotina(3, "GUERRA"));
            Carretas.Add(new Rotina(4, "FACCHINI"));
            Carretas.Add(new Rotina(5, "SCHIFFER"));
            Carretas.Add(new Rotina(6, "NOMA"));
            Carretas.Add(new Rotina(7, "IDEROL"));
            Carretas.Add(new Rotina(8, "KRONE"));
            Carretas.Add(new Rotina(9, "METALPI"));
            Carretas.Add(new Rotina(10, "RODOTEC"));
            Carretas.Add(new Rotina(11, "ROSSETI"));
            Carretas.Add(new Rotina(12, "RODOFORT"));

            return Carretas;
        }

        public static List<Rotina> ObterMarcasEmpilhadeiras()
        {
            List<Rotina> Empilhadeiras = new List<Rotina>();
            Empilhadeiras.Add(new Rotina(1, "BT"));
            Empilhadeiras.Add(new Rotina(2, "CLARK"));
            Empilhadeiras.Add(new Rotina(3, "CROWN"));
            Empilhadeiras.Add(new Rotina(4, "DOOSAN"));
            Empilhadeiras.Add(new Rotina(5, "HANGCHA"));
            Empilhadeiras.Add(new Rotina(6, "HELI"));
            Empilhadeiras.Add(new Rotina(7, "HYSTER"));
            Empilhadeiras.Add(new Rotina(8, "HYUNDAI"));
            Empilhadeiras.Add(new Rotina(9, "JUNGHEINRICH"));
            Empilhadeiras.Add(new Rotina(10, "KOMATSU"));
            Empilhadeiras.Add(new Rotina(11, "LINDE"));
            Empilhadeiras.Add(new Rotina(12, "MITSUBISHI"));
            Empilhadeiras.Add(new Rotina(13, "NISSAN"));
            Empilhadeiras.Add(new Rotina(14, "PALE TRANS"));
            Empilhadeiras.Add(new Rotina(15, "RAYMOND"));
            Empilhadeiras.Add(new Rotina(16, "SKAM"));
            Empilhadeiras.Add(new Rotina(17, "STILL"));
            Empilhadeiras.Add(new Rotina(18, "TCM"));
            Empilhadeiras.Add(new Rotina(19, "TOYOTA"));
            Empilhadeiras.Add(new Rotina(20, "YALE"));
            return Empilhadeiras;
        }

        public static List<Rotina> ObterMarcasMotosAquaticas()
        {
            List<Rotina> Motos = new List<Rotina>();
            Motos.Add(new Rotina(1, "FUN JET"));
            Motos.Add(new Rotina(2, "HONDA"));
            Motos.Add(new Rotina(3, "HYDROSPACE"));
            Motos.Add(new Rotina(4, "KAWASAKI"));
            Motos.Add(new Rotina(5, "LENZI"));
            Motos.Add(new Rotina(6, "POLARIS"));
            Motos.Add(new Rotina(7, "SAILOR"));
            Motos.Add(new Rotina(8, "SEA DOO"));
            Motos.Add(new Rotina(9, "SEA JET"));
            Motos.Add(new Rotina(10, "YAMAHA"));
            return Motos;
        }

        public static Rotina ObterMarcasVeiculos(int id, int tipo)
        {
            Rotina umabase = new Rotina();
            List<Rotina> bases = null;
            switch (tipo)
            {
                case 1:
                    bases = ObterMarcasCarros();
                    break;
                case 5:
                    bases = ObterMarcasBuggys();
                    break;
                case 6:
                    bases = ObterMarcasCaminhoes();
                    break;
                case 7:
                    bases = ObterMarcasCarretas();
                    break;
                case 9:
                    bases = ObterMarcasEmpilhadeiras();
                    break;
                case 11:
                    bases = ObterMarcasMotosAquaticas();
                    break;
                case 12:
                    bases = ObterMarcasLanchas();
                    break;
                case 16:
                    bases = ObterMarcasMotorPopa();
                    break;
                case 17:
                    bases = ObterMarcasMotos();
                    break;
                case 19:
                    bases = ObterMarcasOnibus();
                    break;
                case 20:
                    bases = ObterMarcasQuadricliclos();
                    break;
                case 22:
                    bases = ObterMarcasTratores();
                    break;
                case 24:
                    bases = ObterMarcasBarcos();
                    break;
            }

            foreach (Rotina itembase in bases)
            {
                if (itembase.Id.ToString().Equals(id.ToString()))
                {
                    umabase = itembase;
                    break;
                }
            }
            return umabase;
        }

        public static Rotina ObterTipo(int id)
        {
            Rotina umabase = new Rotina();
            List<Rotina> bases = ObterTipo();
            foreach (Rotina itembase in bases)
            {
                if (itembase.Id.ToString().Equals(id.ToString()))
                {
                    umabase = itembase;
                    break;
                }
            }
            return umabase;
        }

        public static List<Rotina> ObterPosicaoOrcamento()
        {
            List<Rotina> Tipos = new List<Rotina>();
            Tipos.Add(new Rotina(1, "Orçamento – Em elaboração"));
            Tipos.Add(new Rotina(2, "Orçamento Cancelado – Desistência"));
            Tipos.Add(new Rotina(3, "Orçamento Cancelado – Preço"));
            Tipos.Add(new Rotina(4, "Orçamento Cancelado – Condição de pagamento"));
            Tipos.Add(new Rotina(5, "Orçamento Cancelado – Prazo de entrega"));
            Tipos.Add(new Rotina(6, "Pedido – Em elaboração"));
            Tipos.Add(new Rotina(7, "Pedido Cancelado – Desistência"));
            Tipos.Add(new Rotina(8, "Pedido Cancelado – Preço"));
            Tipos.Add(new Rotina(9, "Pedido Cancelado – Condição de pagamento"));
            Tipos.Add(new Rotina(10, "Pedido Cancelado – Prazo de entrega"));
            Tipos.Add(new Rotina(11, "Pedido – Aguardando faturamento"));
            Tipos.Add(new Rotina(12, "Pedido – Faturado"));
            Tipos.Add(new Rotina(14, "Pedido – Faturado e Cancelado"));
            Tipos.Add(new Rotina(15, "Pedido Finalizado"));
            return Tipos;
        }

        public static Rotina ObterPosicaoOrcamento(int id)
        {
            Rotina umabase = new Rotina();
            List<Rotina> bases = ObterPosicaoOrcamento();
            foreach (Rotina itembase in bases)
            {
                if (itembase.Id.ToString().Equals(id.ToString()))
                {
                    umabase = itembase;
                    break;
                }
            }
            return umabase;
        }

        public static List<Rotina> ObterTipoRecebimento()
        {
            List<Rotina> Tipos = new List<Rotina>();
            Tipos.Add(new Rotina(0, "Dinheiro"));
            Tipos.Add(new Rotina(1, "Cartão Débito"));
            Tipos.Add(new Rotina(2, "Cartão Crédito"));
            Tipos.Add(new Rotina(3, "Cheque"));
            Tipos.Add(new Rotina(4, "Boleto Bancário"));
            Tipos.Add(new Rotina(5, "Outro"));
            return Tipos;
        }

        public static Rotina ObterTipoRecebimento(int id)
        {
            Rotina umabase = new Rotina();
            List<Rotina> bases = ObterTipoRecebimento();
            foreach (Rotina itembase in bases)
            {
                if (itembase.Id.ToString().Equals(id.ToString()))
                {
                    umabase = itembase;
                    break;
                }
            }
            return umabase;
        }

        public static List<Rotina> ObterQuantidadeParcelas()
        {
            List<Rotina> Tipos = new List<Rotina>();

            for (int i = 1; i < 25; i++)
            {
                var Vezes = i.ToString() + "X";
                Tipos.Add(new Rotina(i, Vezes));
            }
            
            return Tipos;
        }

        public static Rotina ObterQuantidadeParcelas(int id)
        {
            Rotina umabase = new Rotina();
            List<Rotina> bases = ObterQuantidadeParcelas();
            foreach (Rotina itembase in bases)
            {
                if (itembase.Id.ToString().Equals(id.ToString()))
                {
                    umabase = itembase;
                    break;
                }
            }
            return umabase;
        }
    }
}
