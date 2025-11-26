using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSW1_T1_SALAS_JEREMY.Data;
using DSW1_T1_SALAS_JEREMY.Models;

namespace DSW1_T1_SALAS_JEREMY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NivelesAcademicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NivelesAcademicosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/nivelesacademicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelAcademico>>> GetNivelesAcademicos()
        {
            return await _context.NivelesAcademicos.Include(n => n.Cursos).ToListAsync();
        }

        // POST: api/nivelesacademicos
        [HttpPost]
        public async Task<ActionResult<NivelAcademico>> PostNivelAcademico(NivelAcademico nivelAcademico)
        {
            _context.NivelesAcademicos.Add(nivelAcademico);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNivelesAcademicos), new { id = nivelAcademico.NivelAcademicoId }, nivelAcademico);
        }
    }
}