using CGenius.Data;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CGenius.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ListarClientes()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        public IActionResult CriarCliente()
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
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction("ListarClientes");
            }

            return NoContent();
        }

        [HttpGet]
        public ActionResult EditarPorId(long id)
        {
            var cliente = _context.Clientes.FirstOrDefault(b => b.Id == id);

            if (cliente == null)
            {
                ModelState.AddModelError("", "Nenhum cliente encontrado!");
                return View("ListarClientes");
            }

            return View("AtualizarCliente", cliente);
        }

        [HttpGet]
        public ActionResult BuscarPorCpf(string cpf)
        {
            if (!ValidarCPF(cpf))
            {
                ModelState.AddModelError("", "CPF Inválido!");
                return View("ListarClientes", _context.Clientes.ToList());
            }

            var buscarCpf = _context.Clientes.Where(b => b.CpfCliente == cpf).ToList();
            if (buscarCpf.Count == 0)
            {
                ModelState.AddModelError("", "Nenhum cliente com esse CPF foi encontrado!");
                return View("ListarClientes", _context.Clientes.ToList());
            }

            return View("ListarClientes", buscarCpf);
        }

        [HttpPost]
        public ActionResult AtualizarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var DadosCliente = _context.Clientes.FirstOrDefault(d => d.Id == cliente.Id);

                if (DadosCliente != null)
                {
                    DadosCliente.NomeCliente = cliente.NomeCliente;
                    DadosCliente.CpfCliente = cliente.CpfCliente;
                    DadosCliente.Telefone = cliente.Telefone;
                    DadosCliente.Email = cliente.Email;
                    DadosCliente.PreferenciaContato = cliente.PreferenciaContato;
                    DadosCliente.DtNascimento = cliente.DtNascimento;

                    _context.SaveChanges();
                    return RedirectToAction("ListarClientes");
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum Cliente Encontrado!");
                }
            }
            return View("AtualizarCliente", cliente);
        }

        [HttpPost]
        public ActionResult DeletarCliente(long id)
        {
            var cliente = _context.Clientes.FirstOrDefault(a => a.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("ListarClientes");
        }
    }
}
