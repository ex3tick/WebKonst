using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Controller]
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
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int bid)
        {
            Boot boot = _service.GetBoatById(bid);
            
            return View(boot); 
        }
        [HttpPost]
        public async Task<ActionResult> AddBoat()
        {
            try
            {
                using var reader = new StreamReader(Request.Body);
                var body = await reader.ReadToEndAsync();


                var boat = JsonSerializer.Deserialize<Boot>(body);

                
                int insertedID = _service.InsertBoat(boat);
                return Json(new { id = insertedID });
            }
            catch (Exception ex)
            {
                // Log the exception message to your server logs
                Console.WriteLine(ex.Message);
                // Return a 500 status code with a detailed error message
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
    }
        
    }



