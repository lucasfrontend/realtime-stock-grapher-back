using ACCIONES_BACKEND.Context;
using ACCIONES_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ACCIONES_BACKEND.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly string _staticKey = "4cGL4F3YjnEPrYiwH7BzrCEWlgKm9KVpBh0rFT/T2Ak=";

    public UsersController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET para traer los datos del usuario por id,
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    // POST /api/users/login endpoint para loguearse
    // Verifico si el usuario existe, genero token y devuelvo token, id y username
    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginRequest loginRequest)
    {
      var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);
      if (existingUser == null)
      {
        return Unauthorized("Usuario o clave inválida");
      }

      var token = GenerateJwtToken(loginRequest.Username);
      return Ok(new { token, userId = existingUser.Id, username = existingUser.Username });
    }

    // POST /api/users/create Creación de nuevo usuario
    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
      try
      {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al crear usuario:", ex);
        return BadRequest("No se pudo creaer el usuario");
      }
    }

    private string GenerateJwtToken(string username)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_staticKey);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    // GET /api/users/Id/favorites para traer listado de favoritos por usuario
    [HttpGet("{userId}/favorites")]
    public async Task<ActionResult<IEnumerable<UserFavorite>>> GetUserFavorites(int userId)
    {
      try
      {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
          return NotFound("Usuario no encontrado");
        }

        var favorites = await _context.UserFavorites.Where(f => f.UserId == userId).ToListAsync();
        return Ok(favorites);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al obtener las acciones favoritas del usuario: {ex.Message}");
      }
    }

    // POST /api/users/Id/favorites endpoint para agregar una acción como favorita
    [HttpPost("{userId}/favorites")]
    public async Task<ActionResult> AddFavorite(int userId, [FromBody] UserFavorite favorite)
    {
      Console.WriteLine($"id usu: {userId}");
      try
      {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
          return NotFound("Usuario no encontrado");
        }

        var existingFavorite = await _context.UserFavorites.FirstOrDefaultAsync(f => f.UserId == userId && f.Symbol == favorite.Symbol);
        if (existingFavorite != null)
        {
          return Conflict("La acción ya está marcada como favorita");
        }

        _context.UserFavorites.Add(favorite);
        await _context.SaveChangesAsync();

        return Ok("Acción agregada como favorita");
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al agregar la acción como favorita: {ex.Message}");
      }
    }

    // DELETE /api/users/Id/favorites/{symbol} Endpoint para eliminar una acción de favoritos
    [HttpDelete("{userId}/favorites/{symbol}")]
    public async Task<ActionResult> RemoveFavorite(int userId, string symbol)
    {
      var existingFavorite = await _context.UserFavorites.FirstOrDefaultAsync(f => f.UserId == userId && f.Symbol == symbol);
      if (existingFavorite == null)
      {
        return NotFound("La acción no está marcada como favorita para este usuario");
      }

      _context.UserFavorites.Remove(existingFavorite);
      await _context.SaveChangesAsync();

      return Ok("Acción eliminada de favoritas");
    }

    // GET /api/users/test endpoint para testear conectividad
    [HttpGet("test")]
    public ActionResult<string> Test()
    {
      var users = _context.Users.ToList();

      var response = new
      {
        Message = "El servidor está levantado y funcionando correctamente.",
        Users = users
      };

      return Ok(response);
    }
  }
}
