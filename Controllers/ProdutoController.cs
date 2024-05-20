using CGenius.Data;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;

namespace CGenius.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ListarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult CriarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return RedirectToAction("ListarProdutos");
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult ExibirProdutos(long id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                ModelState.AddModelError("", "Nenhum produto encontrado!");
                return View("ListarProdutos");
            }

            return View("AtualizarProduto", produto);
        }

        [HttpPost]
        public ActionResult AtualizarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var dadosProduto = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);

                if (dadosProduto != null)
                {
                    dadosProduto.NomeProduto = produto.NomeProduto;
                    dadosProduto.DescricaoProduto = produto.DescricaoProduto;
                    dadosProduto.ValorProduto = produto.ValorProduto;

                    _context.SaveChanges();
                    return RedirectToAction("ListarProdutos");
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum produto encontrado!");
                }
            }
            return View("AtualizarProduto", produto);
        }

        [HttpPost]
        public ActionResult DeletarProduto(long id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("ListarProdutos");
        }
    }
}
