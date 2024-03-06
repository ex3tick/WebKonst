using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CrudInterfaceServices _service = new CrudInterfaceServices();

        public IActionResult Index()
        {
            List<Boot> Boote = _service.GetAllBoats();
            return View(Boote);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int bid)
        {

            Boot boot = _service.GetBoatById(bid);

            return View(boot);
        }

        public IActionResult Delete(int bid)
        {
            _service.DeleteBoat(bid);
            return View();
        }

        public IActionResult Edit(int bid)
        {
            Boot boot = _service.GetBoatById(bid);
            
            return View(boot); 
        }
        
        
    }
        
    }



