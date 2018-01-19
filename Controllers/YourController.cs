using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class YourController : Controller
    {
        [HttpGet]
        [Route("JsonExample")]
        public JsonResult Example()
        {
            // Any object can be created
            var AnonObject = new {
                firstName = "Ross",
                lastName = "Hargrove",
                age = 26
            };
            // The Json method converts the object passed to it into JSON
            return Json(AnonObject);
        }

        // Api Caller Route
        [HttpGet]
        [Route("/pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid) {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse => {
                PokeInfo = ApiResponse;
            }).Wait();
        }

        // To store a string in session, we use ".SetString'
        // The first string passed is the key and the second is the value that needs to be retrieved later
        HttpContext.Session.SetString("UserName", "Ross");
        // To retrieve a string from session we use ".GetString"
        string LocalVariable = HttpContext.Session.GetString("UserName");
        // To store an int in session we use ".SetInt32"
        HttpContext.Session.SetInt32("UserAge", 28);
        // To retrieve an int from session we use ".GetInt32"
        // An int? type is used because a session value may be nullable
        int? IntVariable = HttpContext.Session.GetInt32("UserAge");
        // To clear a session, use ".Clear"
        HttpContext.Session.Clear();
    }
}