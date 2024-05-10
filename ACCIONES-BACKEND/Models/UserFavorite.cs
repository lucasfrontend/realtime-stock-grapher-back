namespace ACCIONES_BACKEND.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}