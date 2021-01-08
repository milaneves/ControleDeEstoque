using ControleDeEstoque.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class CadastroController : Controller
    {

        private static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel() {Id=1, Nome="Livros", Ativo=true},
            new GrupoProdutoModel() {Id=2, Nome="Mouses", Ativo=true},
            new GrupoProdutoModel() {Id=3, Nome="Monitores", Ativo=true}
        };



        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(_listaGrupoProduto);
        }
        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }
       [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }
       [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

       [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

       [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }

    }
}