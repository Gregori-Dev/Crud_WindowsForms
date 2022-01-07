using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace WebCrud.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepositorio repositorio;
        public DadosUsuario dadosUsuario;
        public ClienteController(IRepositorio _repositorio)
        {
            repositorio = _repositorio;
            DadosUsuario dadosUsuario = new();
        }
        [HttpGet("{id}")]
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
            var dados = repositorio.ExibirTodos();
            return  Ok(dados);
            
        }
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar( DadosUsuario dadosUsuario)
        {
              repositorio.Adicionar(dadosUsuario);
            return Ok(dadosUsuario);
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
            return Ok(dadosUsuario);
        }
        [HttpPut]
       
        public async Task<IActionResult> Editar([FromBody] DadosUsuario dadosUsuario)
        {
            
            repositorio.Update(dadosUsuario);          
            return Ok(dadosUsuario);
        }
        
        
    }
}
