using CGenius.Data;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CGenius.Controllers
{
    public class ScriptVendasController : Controller
    {
        private readonly DataContext _context;

        public ScriptVendasController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ListarScripts()
        {
            var scripts = _context.Scripts.ToList();
            return View(scripts);
        }

        public IActionResult CriarScript()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarScript(ScriptVendas script)
        {
            if (ModelState.IsValid)
            {
                _context.Scripts.Add(script);
                _context.SaveChanges();

                return RedirectToAction("ListarScripts");
            }
            return View("CriarScript", script);
        }

        [HttpGet]
        public IActionResult ExibirScript(long id)
        {
            var script = _context.Scripts.FirstOrDefault(s => s.Id == id);

            if (script == null)
            {
                ModelState.AddModelError("", "Nenhum script encontrado!");
                return View("ListarScripts", _context.Scripts.ToList());
            }

            return View("AtualizarScript", script);
        }

        [HttpGet]
        public IActionResult BuscarPorId(long id)
        {
            var script = _context.Scripts.FirstOrDefault(s => s.Id == id);
            if (script == null)
            {
                ModelState.AddModelError("", "Nenhum script com esse ID foi encontrado!");
                return View("ListarScripts", _context.Scripts.ToList());
            }

            return View("ListarScripts", new List<ScriptVendas> { script });
        }

        [HttpPost]
        public IActionResult AtualizarScript(ScriptVendas script)
        {
            if (ModelState.IsValid)
            {
                var scriptExistente = _context.Scripts.FirstOrDefault(s => s.Id == script.Id);

                if (scriptExistente != null)
                {
                    scriptExistente.IdCompra = script.IdCompra;
                    scriptExistente.IdProduto = script.IdProduto;
                    scriptExistente.IdChamada = script.IdChamada;
                    scriptExistente.CpfCliente = script.CpfCliente;
                    scriptExistente.DescricaoScript = script.DescricaoScript;

                    _context.SaveChanges();
                    return RedirectToAction("ListarScripts");
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum Script Encontrado!");
                }
            }
            return View("AtualizarScript", script);
        }

        [HttpPost]
        public IActionResult DeletarScript(long id)
        {
            var script = _context.Scripts.FirstOrDefault(s => s.Id == id);

            if (script == null)
            {
                return NotFound();
            }

            _context.Scripts.Remove(script);
            _context.SaveChanges();

            return RedirectToAction("ListarScripts");
        }
    }
}