using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        // A GET Method
        [HttpGet]
        // This route matches the url localhost:5000/index
        [Route("")]
        public IActionResult Index()
        {
            // return View();
            // or
            return View("Index");
            // Both of these returns will render the same view
            // ASP.NET will look for a view file with the same name as the method
            // if View() has no parameters
        }

        // A POST Method
        // All POST routes must have [HttpPost]
        [HttpPost]
        [Route("method")]
        public IActionResult Method(string textField, int numberField)
        {
            // Return a view
            ViewBag.TextExample = textField;
            ViewBag.NumberExample = numberField;
            return View("Index");
        }
    }
}