using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly SqlDal _service = new SqlDal();
        public HomeController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            // Sqldal = new SqlDal(connectionString);
        }

        
        /// <summary>
        /// Ruft eine Liste von Booten aus der Datenbank ab.
        /// </summary>
        /// <returns>Die Ansicht mit der Liste der Boote.</returns>
        public IActionResult Index()
        {
            List<Boot> Boote = _service.GetAllBoats();
            return View(Boote);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        /// <summary>
        /// Ruft einen Bootseintrag aus der Datenbank ab.
        /// </summary>
        /// <param name="bid">Die ID des Bootseintrags.</param>
        /// <returns>Die Ansicht mit den Details des Bootseintrags.</returns>
        public IActionResult Detail(int bid)
        {

            Boot boot = _service.GetBoatById(bid);

            return View(boot);
        }
        
        /// <summary>
        /// Fügt einen neuen Eintrag in die Datenbank ein.
        /// </summary>
        /// <param name="name">Der Name des Eintrags.</param>
        /// <param name="laenge">Die Länge des Eintrags.</param>
        /// <param name="motorleistung">Die Motorleistung des Eintrags (optional).</param>
        /// <param name="segelboot">Gibt an, ob es sich um ein Segelboot handelt.</param>
        /// <param name="tiefgang">Der Tiefgang des Eintrags.</param>
        /// <param name="baujahr">Das Baujahr des Eintrags.</param>
        /// <returns>Die Ansicht für den eingefügten Eintrag.</returns>

        public IActionResult Inser2(string name, double laenge, int? motorleistung, bool segelboot, double tiefgang, string baujahr)
     
        {
            if(name == null || laenge == 0 || motorleistung == 0 || tiefgang == 0 || baujahr == null)
            {
                return View();
            }
            //dto wäre nicht nötig, da wir die daten direkt in die datenbank einfügen könnten.
            DtoInsert dto = Mapping.DataToDtoInsert(name, laenge, motorleistung, segelboot, tiefgang, baujahr);
            _service.Insert2(dto);
            return View();
        }

        
        /// <summary>
        /// Löscht einen Bootseintrag aus der Datenbank.
        /// </summary>
        /// <param name="bid">Die ID des Bootseintrags.</param>
        /// <returns>Die Weiterleitung zur "Index"-Ansicht.</returns>
        public IActionResult Delete(int bid)
        {
            _service.DeleteBoat(bid);
            return RedirectToAction("Index");
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int bid)
        {
            Boot boot = _service.GetBoatById(bid);
            
            return View(boot); 
        }
       [HttpPost]
        public IActionResult Edit(int bid, string name, double laenge, int? motorleistung, bool segelboot, double tiefgang, string baujahr)
        {
            if(name == null || laenge == 0 || motorleistung == 0 || tiefgang == 0 || baujahr == null)
            {
                return View();
            }
            Boot boot = Mapping.MappingEditBoot(bid, name, laenge, motorleistung, segelboot, tiefgang, baujahr);
            _service.UpdateBoat(boot);
            
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Diese Methode behandelt eine HTTP-POST-Anfrage zum Hinzufügen eines Bootes.
        /// </summary>
        /// <returns>Ein ActionResult mit der eingefügten Boot-ID.</returns>
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

        [HttpGet]
        public IActionResult PersonDaten()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult PersonDaten(string? Name, string? Nachname,DateTime? Geburtsdatum, string? Lieblingsfarbe)
        {
          
            List<string> person = new List<string>();
           
            person.Add(Name);
            person.Add(Nachname);
            person.Add(Geburtsdatum.ToString());
            person.Add(Lieblingsfarbe);
            
           
            
            return View(person);
        }
        
       
        
    }
        
    }



