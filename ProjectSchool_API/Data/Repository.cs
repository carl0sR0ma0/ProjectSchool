using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
  public class Repository : IRepository
  {
    public DataContext _context { get; }
    public Repository(DataContext context)
    {
      this._context = context;
    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }
    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }
    public async Task<bool> SaveChangeAsync()
    {
      return (await _context.SaveChangesAsync() > 0);
    }

    // ALUNOS
    public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
    {
      IQueryable<Aluno> query = _context.Alunos;
      if (includeProfessor)
      {
        query = query.Include(a => a.Professor);
      }
      query = query.AsNoTracking().OrderBy(a => a.Id);
      return await query.ToArrayAsync();
    }

    public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor)
    {
      IQueryable<Aluno> query = _context.Alunos;
      if (includeProfessor)
      {
        query = query.Include(a => a.Professor);
      }
      query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.ProfessorId == ProfessorId);
      return await query.ToArrayAsync();
    }

    public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor)
    {
      IQueryable<Aluno> query = _context.Alunos;
      if (includeProfessor)
      {
        query = query.Include(a => a.Professor);
      }
      query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == AlunoId);
      return await query.FirstOrDefaultAsync();
    }

    // PROFESSOR
    public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false)
    {
      IQueryable<Professor> query = _context.Professores;
      if (includeAluno)
      {
        query = query.Include(p => p.Alunos);
      }
      query = query.AsNoTracking().OrderBy(p => p.Id);
      return await query.ToArrayAsync();
    }

    public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno = false)
    {
      IQueryable<Professor> query = _context.Professores;
      if (includeAluno)
      {
        query = query.Include(p => p.Alunos);
      }
      query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == ProfessorId);
      return await query.FirstOrDefaultAsync();
    }
  }
}