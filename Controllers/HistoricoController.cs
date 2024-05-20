using CGenius.Data;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CGenius.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly DataContext _context;

        public HistoricoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ListarHistoricos()
        {
            var historicos = _context.Historicos.ToList();
            return View(historicos);
        }

        public IActionResult CriarHistorico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarHistorico(Historico historico)
        {
            if (ModelState.IsValid)
            {
                _context.Historicos.Add(historico);
                _context.SaveChanges();

                return RedirectToAction("ListarHistoricos");
            }
            return View("CriarHistorico", historico);
        }

        [HttpGet]
        public IActionResult ExibirHistorico(long id)
        {
            var historico = _context.Historicos.FirstOrDefault(h => h.Id == id);

            if (historico == null)
            {
                ModelState.AddModelError("", "Nenhum histórico encontrado!");
                return View("ListarHistoricos", _context.Historicos.ToList());
            }

            return View("AtualizarHistorico", historico);
        }

        [HttpGet]
        public IActionResult BuscarPorId(long id)
        {
            var historico = _context.Historicos.FirstOrDefault(h => h.Id == id);
            if (historico == null)
            {
                ModelState.AddModelError("", "Nenhum histórico com esse ID foi encontrado!");
                return View("ListarHistoricos", _context.Historicos.ToList());
            }

            return View("ListarHistoricos", new List<Historico> { historico });
        }

        [HttpPost]
        public IActionResult AtualizarHistorico(Historico historico)
        {
            if (ModelState.IsValid)
            {
                var historicoExistente = _context.Historicos.FirstOrDefault(h => h.Id == historico.Id);

                if (historicoExistente != null)
                {
                    historicoExistente.IdProduto = historico.IdProduto;
                    historicoExistente.CpfCliente = historico.CpfCliente;
                    historicoExistente.DataCompra = historico.DataCompra;

                    _context.SaveChanges();
                    return RedirectToAction("ListarHistoricos");
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum Histórico Encontrado!");
                }
            }
            return View("AtualizarHistorico", historico);
        }

        [HttpPost]
        public IActionResult DeletarHistorico(long id)
        {
            var historico = _context.Historicos.FirstOrDefault(h => h.Id == id);

            if (historico == null)
            {
                return NotFound();
            }

            _context.Historicos.Remove(historico);
            _context.SaveChanges();

            return RedirectToAction("ListarHistoricos");
        }
    }
}
