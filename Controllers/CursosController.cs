using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSW1_T1_SALAS_JEREMY.Data;
using DSW1_T1_SALAS_JEREMY.Models;

namespace DSW1_T1_SALAS_JEREMY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Cursos.Include(c => c.NivelAcademico).ToListAsync();
        }

        // GET: api/cursos/por-nivel/5
        [HttpGet("por-nivel/{nivelId}")]
        public async Task<ActionResult<IEnumerable<Curso>>> ListarCursosPorNivel(int nivelId)
        {
            var cursos = await _context.Cursos
                .Where(c => c.NivelAcademicoId == nivelId)
                .Include(c => c.NivelAcademico)
                .ToListAsync();

            if (cursos.Count == 0)
                return NotFound("No hay cursos para este nivel académico");

            return Ok(cursos);
        }

        // POST: api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCursos), new { id = curso.CursoId }, curso);
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.CursoId)
                return BadRequest();

            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}