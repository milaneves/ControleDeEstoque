﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Models
{
    public class UsuarioModel
    {
      public static bool ValidarUsuario(string login, string senha)
        {
            var retorno = false;
            using (var conexao = new SqlConnection())
            
            {
               
                conexao.ConnectionString = @"Data Source =DESKTOP-TPLPAFM\SQLEXPRESS;Initial Catalog=ControleEstoque;User Id=sa;Password=123456"; // realizando a conexão com o banco de dados
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("Select count(*) from usuario where login= '{0}' and senha='{1}'", login, senha);
                    retorno = ((int)comando.ExecuteScalar()>0);// se achou algum registro maior que zero
                }
            }
            return retorno;
        }
       
    }
}