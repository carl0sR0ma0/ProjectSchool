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
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _repo.GetAllAlunosAsync(true);
        return Ok(result);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpGet("{alunoId}")]
    public async Task<IActionResult> GetByAlunoId(int alunoId)
    {
      try
      {
        var result = await _repo.GetAlunoAsyncById(alunoId, true);
        return Ok(result);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }
    [HttpGet("ByProfessor/{professorId}")]
    public async Task<IActionResult> GetByProfessorId(int professorId)
    {
      try
      {
        var result = await _repo.GetAlunosAsyncByProfessorId(professorId, true);
        return Ok(result);
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
    public async Task<IActionResult> Put(int alunoId, Aluno model)
    {
      try
      {
        var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
        if (aluno == null) return NotFound();
        _repo.Update(model);

        if (await _repo.SaveChangeAsync())
        {
          aluno = await _repo.GetAlunoAsyncById(alunoId, true);
          return Created($"/Aluno/{model.Id}", aluno);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
    [HttpDelete("{alunoId}")]
    public async Task<IActionResult> Delete(int alunoId)
    {
      try
      {
        var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
        if (aluno == null) return NotFound();
        _repo.Delete(aluno);

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