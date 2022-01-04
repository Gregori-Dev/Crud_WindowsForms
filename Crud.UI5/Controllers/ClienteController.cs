using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebCrud.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepositorio repositorio;

        public ClienteController(IRepositorio _repositorio)
        {            
            repositorio = _repositorio;
        }
        [HttpGet]
        [Route("ExibirUsuario")]
        public IActionResult ExibirUsuario(int id)
        {
            var unicoUsuario = repositorio.ExibirUsuario(id);
            return Ok(unicoUsuario);
        }

        [HttpGet]
        [Route("Inicio")]
        public IActionResult Inicio()
        {
            var retorno = repositorio.ExibirTodos();
            return  Ok(retorno);
            
        }
        [HttpPost]
        [Route("Cadastrar")]
        public  IActionResult Cadastrar(DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(dadosUsuario);
                return RedirectToAction(nameof(Inicio));

            }
            return View(dadosUsuario);
        }
        [HttpPost]
        [Route("Deletar")]
        public ActionResult Deletar(DadosUsuario dadosUsuario,int id)
        {
            if (ModelState.IsValid)
            {
                repositorio.Delete(dadosUsuario);
                return RedirectToAction(nameof(Inicio));
            }
            return View(dadosUsuario);
        }
        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(dadosUsuario);
                return RedirectToAction(nameof(Inicio));
            }
            return View(dadosUsuario);
        }
        
        
    }
}
