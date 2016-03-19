using System;
using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class FeriadoGL : IDados<FeriadoDTO>
    {
        FeriadoBO regrasnegocio = new FeriadoBO();

        /// <summary>
        /// Instância básica para FeriadoGL.
        /// </summary>
        public FeriadoGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(FeriadoDTO Feriado)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Feriado);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(FeriadoDTO Feriado)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                {
                    if (Feriado.Repete)
                        return regrasnegocio.Update(Feriado, Feriado.Repete);
                    else
                        return regrasnegocio.Update(Feriado);
                }
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(FeriadoDTO feriado) 
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(feriado);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public FeriadoDTO GetFeriado(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFeriado(id);
                else
                    return new FeriadoDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FeriadoDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<FeriadoDTO> GetGridFeriado(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridFeriado(campo, valorPesquisa);
                else
                    return new List<FeriadoDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// </summary>
        public int ObterFeriadosDSR(DateTime datainicial, DateTime datafinal)
        {
            try
            {
                return regrasnegocio.ObterFeriadosDSR(datainicial, datafinal);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// </summary>
        public int ObterFeriadosDSR(List<DateTime> datas)
        {
            try
            {
                return regrasnegocio.ObterFeriadosDSR(datas);
            }
            catch
            {
                throw;
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
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetFeriadoPeriodo(periodoInicial, periodoFinal, idMunicipio, idUF);
                else
                    return new List<FeriadoDTO>();
            }
            catch
            {
                throw;
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
                return regrasnegocio.GetFeriados();
            }
            catch
            {
                throw;
            }
        }
    }
}