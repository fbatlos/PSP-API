using Microsoft.EntityFrameworkCore;
using GameScoreAPI.Models;

namespace GameScoreAPI.Data
{
    public class GameScoreContext : DbContext
    {
        public GameScoreContext(DbContextOptions<GameScoreContext> options) : base(options) { }

        public DbSet<Score> Scores { get; set; }
    }
}
