using CGenius.Data;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;

namespace CGenius.Controllers
{
    public class AtendenteController : Controller
    {
        private readonly DataContext _context;

        public AtendenteController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ListarAtendentes()
        {
            var atendentes = _context.Atendentes.ToList();
            return View(atendentes);
        }
        public IActionResult CriarAtendente()
        {
            return View();
        }

        private bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            foreach (char c in cpf)
            {
                if (!char.IsDigit(c)) return false;
            }

            return true;
        }

        [HttpPost]
        public ActionResult CadastrarAtendente(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                _context.Atendentes.Add(atendente);
                _context.SaveChanges();

                return RedirectToAction("ListarAtendentes");
            }

            return NoContent();
        }


        [HttpGet]
        public ActionResult EditarPorId(long id)
        {
            var atendente = _context.Atendentes.FirstOrDefault(a => a.Id == id);

            if (atendente == null)
            {
                ModelState.AddModelError("", "Nenhum atendente encontrado!");
                return View("ListarAtendente");
            }

            return View("AtualizarAtendente", atendente);
        }

        [HttpGet]
        public ActionResult BuscarPorCpf(string cpf)
        {
            if (!ValidarCPF(cpf))
            {
                ModelState.AddModelError("", "CPF Inválido!");
                return View("ListarAtendentes", _context.Atendentes.ToList());
            }
                var buscarCpf = _context.Atendentes.Where(b => b.Cpf == cpf).ToList();
            if (buscarCpf.Count == 0)
            {
                ModelState.AddModelError("", "Nenhum atendente com esse CPF foi encontrado!");
                return View("ListarAtendentes", _context.Atendentes.ToList());
            }
            return View("ListarAtendentes", buscarCpf);
        }

        [HttpPost]
        public ActionResult AtualizarAtendente(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                var DadosAtendente = _context.Atendentes.FirstOrDefault(d => d.Id == atendente.Id);

                if(DadosAtendente != null)
                {
                    DadosAtendente.NomeAtendente = atendente.NomeAtendente;
                    DadosAtendente.Cpf = atendente.Cpf;
                    DadosAtendente.Setor = atendente.Setor;
                    DadosAtendente.Senha = atendente.Senha;

                    _context.SaveChanges();
                    return RedirectToAction("ListarAtendentes");

                } else
                {
                    ModelState.AddModelError("", "Nenhum Atendente Encontrado!");
                }
            }
            return View("AtualizarAtendente", atendente);
        }

        [HttpPost]
        public ActionResult DeletarAtendente(long id)
        {
            var atendente = _context.Atendentes.FirstOrDefault(a => a.Id == id);

            if(atendente == null)
            {
                return NotFound();
            }
            _context.Atendentes.Remove(atendente);
            _context.SaveChanges();

            return RedirectToAction("ListarAtendentes");
        }
    }
}
