using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Configuration;

namespace ControleDeEstoque.Models
{
    public class GrupoProdutoModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public bool Ativo { get; set; }

        public static List<GrupoProdutoModel> RecuperarLista()
        {
            var ret = new List<GrupoProdutoModel>();
            using (var conexao = new SqlConnection())

            {

                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ; // realizando a conexão com o banco de dados
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "Select * from GrupoProduto order by nome";
                    var reader = comando.ExecuteReader();// se achou algum registro maior que zero
                    while (reader.Read()) //enquanto tiver objeto para ler
                    {
                        ret.Add(new GrupoProdutoModel //populando a lista de objetos
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]

                        });
                    }
                }
            }
            return ret;
        }

        public static GrupoProdutoModel RecuperarPeloId(int id)
        {
            GrupoProdutoModel ret = null;
            using (var conexao = new SqlConnection())

            {

                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ; // realizando a conexão com o banco de dados
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("Select * from GrupoProduto where(id = {0})", id);
                    var reader = comando.ExecuteReader();// se achou algum registro maior que zero
                    if (reader.Read())
                    {
                        ret = new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]

                        };
                    }
                }
            }
            return ret;
        }

        public static bool ExcluirPeloId(int id)
        {
            var ret = false;

            if (RecuperarPeloId(id) != null)
            {
                using (var conexao = new SqlConnection())
                {

                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ; // realizando a conexão com o banco de dados
                    conexao.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = string.Format("delete from GrupoProduto where(id = {0})", id);
                        ret = (comando.ExecuteNonQuery() > 0);// se achou algum registro maior que zero
                    }
                }
            }
            return ret;
        }

        public int Salvar()
        {
            var ret = 0;
            var model = RecuperarPeloId(this.Id);


                using (var conexao = new SqlConnection())
                {

                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; // realizando a conexão com o banco de dados
                    conexao.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        if (model == null)
                        {
                            comando.CommandText = string.Format("insert into GrupoProduto (nome, ativo) values ('{0}', {1}); select convert(int, scope_identity())", this.Nome, this.Ativo?1:0);
                            ret = (int)comando.ExecuteScalar();
                        }
                        else
                        {
                            comando.CommandText = string.Format(
                                "update GrupoProduto set nome ='{1}', ativo ={2} where id ={0}", 
                                 this.Id, this.Nome, this.Ativo ? 1 : 0);
                            if (comando.ExecuteNonQuery()>0)
                            {
                                ret = this.Id;
                            }
                            
                        }
                    }
                }

            return ret;
        }
    }
}