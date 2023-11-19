using Microsoft.AspNetCore.Mvc;
using PainelPokemon.Data;
using PainelPokemon.Models.Users;

namespace PainelPokemon.Controllers
{
    public class AccountController : Controller
    {
        private readonly PokeContext _pokeContext;

        public AccountController(PokeContext pokeContext ) {
            _pokeContext = pokeContext;
        
        
        }
          


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            
            var user = _pokeContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)


            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                
                HttpContext.Session.SetString("UserName", user.Email);

                HttpContext.Session.SetString("UserPassword", user.Password);

                ViewBag.UserId = HttpContext.Session.Get("UserId");

                return RedirectToAction("Pokemons", "Pokemon");
            }
            else
            {
                
                ViewBag.ErrorMessage = "Email ou senha inválidos.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            var user = HttpContext.Session.GetString("UserId");

            if (User != null)
            {
                HttpContext.Session.Remove("UserId");
            }
            return RedirectToAction("", "Pokemon");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                await _pokeContext.Users.AddAsync(user);
                await _pokeContext.SaveChangesAsync();
                
            }
            return StatusCode(201, user);
        }
    }

}
