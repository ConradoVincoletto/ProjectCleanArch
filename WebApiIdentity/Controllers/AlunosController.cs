using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiIdentity.Context;
using WebApiIdentity.Entities;

namespace WebApiIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {

            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(id);

                if (aluno == null)
                {
                    return NotFound();
                }

                return aluno;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }       
   

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAluno", new { id = aluno.AlunoId }, aluno);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    return NotFound();
                }

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        private bool AlunoExist(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }
    }

}
