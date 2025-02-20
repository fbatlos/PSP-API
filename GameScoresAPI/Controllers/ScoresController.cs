using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameScoreAPI.Data;
using GameScoreAPI.Models;

namespace GameScoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly GameScoreContext _context;

        public ScoresController(GameScoreContext context)
        {
            _context = context;
        }

        // Obtener todas las puntuaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        // Obtener una puntuación por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            return score;
        }

        // Agregar una nueva puntuación
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetScore), new { id = score.Id }, score);
        }
    }
}
