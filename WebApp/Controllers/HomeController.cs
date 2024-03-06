using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Artikel> artikelListe = new List<Artikel>();
            artikelListe.Add(new Artikel{Aid = 1, Bezeichnung = "Schraube", Preis = 0.10, Vorrätig = true});
            artikelListe.Add(new Artikel{Aid = 2, Bezeichnung = "Mutter", Preis = 0.05, Vorrätig = true});
            artikelListe.Add(new Artikel{Aid = 3, Bezeichnung = "Blech", Preis = 1.50, Vorrätig = false});
            return View(artikelListe);
        }
        public IActionResult Detail(int aid)
        {
           
            return View();
        }
        public IActionResult Delete(int aid)
        {
            return View();
        }
        public IActionResult Edit(int aid)
        {
            return View();
        }
    }
}
