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
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _repo.GetAllProfessoresAsync(true);
        return Ok(result);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpGet("{professorId}")]
    public async Task<IActionResult> GetByProfessorId(int professorId)
    {
      try
      {
        var result = await _repo.GetProfessorAsyncById(professorId, true);
        return Ok(result);
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
    public async Task<IActionResult> Put(int professorId, Professor model)
    {
      try
      {
        var professor = await _repo.GetProfessorAsyncById(professorId, false);
        if (professor == null) return NotFound();

        _repo.Update(model);
        if (await _repo.SaveChangeAsync())
        {
          professor = await _repo.GetProfessorAsyncById(professorId, true);
          return Created($"/Professor/{model.Id}", professor);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
    [HttpDelete("{professorId}")]
    public async Task<IActionResult> Delete(int professorId)
    {
      try
      {
        var professor = await _repo.GetProfessorAsyncById(professorId, false);
        if (professor == null) return NotFound();

        _repo.Delete(professor);
        if (await _repo.SaveChangeAsync())
        {
          return Ok();
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
  }
}