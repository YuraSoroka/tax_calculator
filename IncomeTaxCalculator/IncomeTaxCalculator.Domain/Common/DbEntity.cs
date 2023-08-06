namespace IncomeTaxCalculator.Domain.Common
{
    public class DbEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
    }
}
