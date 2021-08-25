using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class AlunoController : Controller
  {
    public IRepository _repo { get; }
    public AlunoController(IRepository repo)
    {
      this._repo = repo;
    }


    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpGet("{alunoId}")]
    public IActionResult Get(int alunoId)
    {
      try
      {
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpPost]
    public async Task<IActionResult> Post(Aluno model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangeAsync())
        {
          return Created($"/Aluno/{model.Id}", model);
        }

      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
    [HttpPut("{alunoId}")]
    public IActionResult Put(int alunoId)
    {
      try
      {
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpDelete("{alunoId}")]
    public IActionResult Delete(int alunoId)
    {
      try
      {
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
  }
}