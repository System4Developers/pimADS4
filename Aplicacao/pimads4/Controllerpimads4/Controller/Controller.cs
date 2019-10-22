﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelpimads4.DTO;
using Controllerpimads4.BL;

namespace Controllerpimads4.Controller
{
    public class Controller
    {
        private static Controller instance;

        private Controller() { }

        public static Controller GetInstance()
        {
            if (instance==null)
            {
                instance = new Controller();
            }

            return instance;
        }
       
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().CadastrarUsuario(usuario);
            
        }

        public void ConsultaLogin(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().ConsultaLogin(usuario);
            
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioBL.GetInstance().ConsultarUsuarios();
            return lstUsuarios;
        }

    }
}