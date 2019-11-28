using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class EstadoDAO
    {
        private static EstadoDAO instance;
        private String mensagem;

        private EstadoDAO() { }

        public string Mensagem { get => mensagem; set => mensagem = value; }

        public static EstadoDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new EstadoDAO();
            }
            return instance;
        }

        internal List<EstadoDTO> ConsultarEstadosTodos()
        {
            this.Mensagem = "";
            String sqlText = "select * from Estados";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<EstadoDTO> lstObj = new List<EstadoDTO>();
            EstadoDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new EstadoDTO();
                    mObj.IdEstado = Convert.ToInt32(dr["idEstado"]);
                    mObj.NmEstado = dr["nmEstado"].ToString();
                    mObj.CodIbge = dr["codIBGE"].ToString();
                    mObj.DsSigla = dr["dsSigla"].ToString();


                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR ESTADOS";
            }

            return lstObj;
        }

    }
}
