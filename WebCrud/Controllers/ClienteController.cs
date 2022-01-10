using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebCrud.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IRepositorio repositorio;

        public ClienteController(IRepositorio _repositorio)
        {            
            repositorio = _repositorio;
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Deletar(int id)
        {
           
            DadosUsuario dadosUsuario = repositorio.ExibirUsuario(id);
            
            return View(dadosUsuario);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            DadosUsuario dadosUsuario = repositorio.ExibirUsuario(id);

            return View(dadosUsuario);
        }
        [HttpGet]
        public IActionResult InicioCadastro()
        {
            var retorno = repositorio.ExibirTodos();
            return View (retorno.ToList());
            
        }




        [HttpPost]
        public  IActionResult Cadastrar(DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(dadosUsuario);
                return RedirectToAction(nameof(InicioCadastro));

            }
            return View(dadosUsuario);
        }
        [HttpPost]
        public ActionResult Deletar(DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Delete(dadosUsuario);
                return RedirectToAction(nameof(InicioCadastro));
            }
            return View(dadosUsuario);
        }
        [HttpPost]
        public IActionResult Editar(DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(dadosUsuario);
                return RedirectToAction(nameof(InicioCadastro));
            }
            return View(dadosUsuario);
        }
        
        
    }
}
