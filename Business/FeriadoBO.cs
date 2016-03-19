using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class FeriadoBO : IDados<FeriadoDTO>
    {
        FeriadoDAO regrasdados = new FeriadoDAO();

        /// <summary>
        /// Instância básica para FeriadoBO.
        /// </summary>
        public FeriadoBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FeriadoDTO feriado)
        {
            try
            {
                if (feriado.Repete)
                {
                    int terminaano = feriado.TerminaAno;

                    if (feriado.Termina == true)
                        terminaano = 2050;


                    this.Converter(feriado, true);
                    int retorna = regrasdados.Insert(feriado);



                    for (int i = feriado.Data.Value.Year + 1; i <= terminaano; i++)
                    {
                        feriado.Data = feriado.Data.Value.AddYears(1);
                        int id = regrasdados.Insert(feriado);
                    }

                    return retorna;

                }
                else
                {
                    this.Converter(feriado, true);
                    return regrasdados.Insert(feriado);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(FeriadoDTO feriado)
        {
            try
            {

                this.Converter(feriado, true);
                return regrasdados.Update(feriado);

            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool Update(FeriadoDTO feriado, bool Repetir) 
        {
            try
            {

                this.Converter(feriado, true);
                return regrasdados.Update(feriado, Repetir);

            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
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


        public bool Delete(FeriadoDTO feriado) 
        {
            try
            {
                return regrasdados.Delete(feriado);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        /// <summary>
        /// Retorna um objeto FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public FeriadoDTO GetFeriado(int id)
        {
            try
            {
                FeriadoDTO feriado = regrasdados.GetFeriado(id);
                this.Converter(feriado, false);
                return feriado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<FeriadoDTO> GetGridFeriado(string campo, string valorPesquisa)
        {
            try
            {
                List<FeriadoDTO> lstFeriado = regrasdados.GetGridFeriado(campo, valorPesquisa);
                foreach (FeriadoDTO feriado in lstFeriado)
                {
                    this.Converter(feriado, false);
                }
                return lstFeriado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// </summary>
        public int ObterFeriadosDSR(DateTime datainicial, DateTime datafinal)
        {
            try
            {
                return regrasdados.ObterFeriadosDSR(datainicial, datafinal);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// </summary>
        public int ObterFeriadosDSR(List<DateTime> datas)
        {
            try
            {
                return regrasdados.ObterFeriadosDSR(datas);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FeriodoDTO definida por período inicial e final
        /// </summary>
        /// <param name="periodoInicial">Data inicial</param>
        /// <param name="periodoFinal">Data final</param>
        /// <param name="idMunicipio">id do municipio que deseja os feriados</param>
        /// <param name="idUF">id do estado que deseja os feriados</param>
        /// <returns>lista de objetos FeriadoDTO</returns>
        public List<FeriadoDTO> GetFeriadoPeriodo(DateTime periodoInicial, DateTime periodoFinal, int idMunicipio, int idUF)
        {
            try
            {
                List<FeriadoDTO> lstFeriado = regrasdados.GetFeriadoPeriodo(periodoInicial, periodoFinal, idMunicipio, idUF);
                foreach (FeriadoDTO feriado in lstFeriado)
                {
                    this.Converter(feriado, false);
                }
                return lstFeriado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão dos campos entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        private void Converter(FeriadoDTO item, bool isLarge)
        {
            if (isLarge)
            {
                switch (item.Tipo.ToUpper())
                {
                    default:
                        item.Tipo = item.Tipo.Substring(0, 1);
                        break;
                }
                switch (item.Especie.ToUpper())
                {
                    default:
                        item.Especie = item.Especie.Substring(0, 1);
                        break;
                }
            }
            else
            {
                switch (item.Tipo.ToUpper())
                {
                    case "F":
                        item.Tipo = "Federal";
                        break;
                    case "E":
                        item.Tipo = "Estadual";
                        break;
                    case "M":
                        item.Tipo = "Municipal";
                        break;
                }
                switch (item.Especie.ToUpper())
                {
                    case "F":
                        item.Especie = "Fixo";
                        break;
                    case "M":
                        item.Especie = "Móvel";
                        break;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de datas de feriados
        /// </summary>
        /// <returns>lista de feriados (DateTime)</returns>
        public List<DateTime> GetFeriados()
        {
            try
            {
                return regrasdados.GetFeriados();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}