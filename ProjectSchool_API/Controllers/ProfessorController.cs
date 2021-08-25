using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ProfessorController : Controller
  {
    public IRepository _repo { get; }
    public ProfessorController(IRepository repo)
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
    [HttpGet("{professorId}")]
    public IActionResult Get(int professorId)
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
    public async Task<IActionResult> Post(Professor model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangeAsync())
        {
          return Created($"/Professor/{model.Id}", model);
        }

      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
    [HttpPut("{professorId}")]
    public IActionResult Put(int professorId)
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
    [HttpDelete("{professorId}")]
    public IActionResult Delete(int professorId)
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