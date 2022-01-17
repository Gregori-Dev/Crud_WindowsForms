using System;
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

        [HttpGet("{id}")]
        [Route("ExibirUsuario")]
        public IActionResult ExibirUsuario(int id)
        {        
              try
                {
                    var unicoUsuario = repositorio.ExibirUsuario(id);
                    return Ok(unicoUsuario);
                }
                catch (NullReferenceException) { throw new NullReferenceException("Exceção ocorrida por passar um valor nulo."); }
                catch (FormatException) { throw new FormatException("Exceção desencadeada por um tipo de valor invalido"); }
                catch (Exception) { throw new Exception("Error desconhecido: "); }   
        }

        [HttpGet]
        [Route("Inicio")]
        public IActionResult Inicio()
        {
            try
                {
                    var dados = repositorio.ExibirTodos();
                    return Ok(dados);
                }
                catch (NullReferenceException) { throw new NullReferenceException("Exceção ocorrida por passar um valor nulo."); }
                catch (FormatException) { throw new FormatException("Exceção desencadeada por um tipo de valor invalido"); }
                catch (Exception) { throw new Exception("Error desconhecido: "); }
            }       

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] DadosUsuario dadosUsuario)
        {
            try
                {
                    repositorio.Adicionar(dadosUsuario);
                    return Ok(dadosUsuario);
                }
                catch (NullReferenceException) { throw new NullReferenceException("Exceção ocorrida por passar um valor nulo."); }
                catch (FormatException) { throw new FormatException("Exceção desencadeada por um tipo de valor invalido"); }
                catch (Exception) { throw new Exception("Error desconhecido: "); }
            }      

        [HttpDelete("{dadosUsuario}")]
        [Route("Excluir")]
        public async Task<IActionResult> Excluir([FromBody]  DadosUsuario dadosUsuario)
        {
            try
                {
                    repositorio.Delete(dadosUsuario);
                    return Ok(dadosUsuario);
                }
                catch (NullReferenceException) { throw new NullReferenceException("Exceção ocorrida por passar um valor nulo."); }
                catch (FormatException) { throw new FormatException("Exceção desencadeada por um tipo de valor invalido"); }
                catch (Exception) { throw new Exception("Error desconhecido: "); }           
        }

        [HttpPut]
    //    [Route("edit")]

        public async Task<IActionResult> Editar([FromBody] DadosUsuario dadosUsuario)
        {
            try
                {
                    repositorio.Update(dadosUsuario);
                    return Ok(dadosUsuario);
                }
                catch (NullReferenceException) { throw new NullReferenceException("Exceção ocorrida por passar um valor nulo."); }
                catch (FormatException) { throw new FormatException("Exceção desencadeada por um tipo de valor invalido"); }
                catch (Exception) { throw new Exception("Error desconhecido: "); }            
        }
    }
}
