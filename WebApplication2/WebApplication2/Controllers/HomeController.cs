using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
     
       
        private readonly WebApplication2Context _context;
        public HomeController(WebApplication2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
         var announcements = _context.Haberler.ToList();
            return View(announcements);
        }
      
        [HttpGet("Haber")]
        public IEnumerable<Haberler> GetHaberlers()
        {
            return _context.Haberler.ToList();  
        }
        [HttpGet("Haber/{id}")]
        public ActionResult<Haberler> GetHaberler(int id)
        {
            var haber = _context.Haberler.Find(id);
            if (haber == null)
            {
                return NotFound();
            }
            return haber;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}