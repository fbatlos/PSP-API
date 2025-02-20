namespace GameScoreAPI.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int Points { get; set; }

        //public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
