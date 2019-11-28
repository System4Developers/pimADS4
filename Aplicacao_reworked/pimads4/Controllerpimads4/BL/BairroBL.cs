using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class BairroBL
    {
        private static BairroBL instance;
        private String mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private BairroBL() { }

        public static BairroBL GetInstance()
        {
            if (instance==null)
            {
                instance = new BairroBL();
            }

            return instance;
        }

        internal void CadastrarBairro(BairroDTO bairro)
        {
            this.Mensagem = "";
            if (bairro.DsBairro != "")
            {
                BairroDAO.GetInstance().CadastrarBairro(bairro);
                if (BairroDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = BairroDAO.GetInstance().Mensagem;
                }
            }
        }

        internal List<BairroDTO> ConsultarBairros()
        {
            this.Mensagem = "";
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = BairroDAO.GetInstance().ConsultarBairrosTodos();
            if (BairroDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroDAO.GetInstance().Mensagem;
            }
            return lstBairros;
        }

        internal BairroDTO ConsultarBairroById(int idBairro)
        {
            this.Mensagem = "";
            BairroDTO bairro = BairroDAO.GetInstance().ConsultarBairroById(idBairro);
            if (BairroDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroDAO.GetInstance().Mensagem;
            }
            return bairro;
        }

        internal void AtualizarBairro(BairroDTO bairro)
        {
            this.Mensagem = "";
            BairroDAO.GetInstance().AtualizarBairro(bairro);
            if (BairroDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroDAO.GetInstance().Mensagem;
            }
        }

        internal void ExcluirBairro(int idBairro)
        {
            this.Mensagem = "";
            BairroDAO.GetInstance().ExlcuirBairro(idBairro);
            if (BairroDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroDAO.GetInstance().Mensagem;
            }
        }
        
        internal List<BairroDTO> ConsultarBairrosByCidade(int idCidade)
        {
            this.Mensagem = "";
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros= BairroDAO.GetInstance().ConsultarBairrosByCidade(idCidade);
            if (BairroDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroDAO.GetInstance().Mensagem;
            }
            return lstBairros;
        }

    }
}
