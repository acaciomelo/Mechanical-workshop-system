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
    public class MunicipioBO : IDados<MunicipioDTO>
    {
        MunicipioDAO regrasdados = new MunicipioDAO();

        /// <summary>
        /// Instância básica para MunicipioBO.
        /// </summary>
        public MunicipioBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(MunicipioDTO Municipio)
        {
            try
            {
                return regrasdados.Insert(Municipio);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(MunicipioDTO Municipio)
        {
            try
            {
                return regrasdados.Update(Municipio);
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

        /// <summary>
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipio(int id)
        {
            try
            {
                return regrasdados.GetMunicipio(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<MunicipioDTO> GetGridMunicipio(string Campo, string ValorPesquisa)
        {
            try
            {
                return regrasdados.GetGridMunicipio(Campo, ValorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipioIBGE(int codigoibge)
        {
            try
            {
                return regrasdados.GetMunicipioIBGE(codigoibge);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}