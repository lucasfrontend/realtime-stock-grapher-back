namespace ACCIONES_BACKEND.Models
{
    public class User
    {
        //[Key] por que llevaria key?
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
