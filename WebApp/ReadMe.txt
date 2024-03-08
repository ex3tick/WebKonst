Von leerer Web-App zu vollständiger Web-App
-Verzeichnesstruktur anlegen
--Controllers
--Models
--Views

-Controller anlegen (z.B. HomeController)
-View anlegen (z.B. Index.cshtml)

- Web APP als MVC Anwendung festlegen
-- builder.Services.AddControllersWithViews();

- Routing aktivieren
-- app.UseRouting();

-Standartroute festlegen
--app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

Infos zum Pogramm und zur Entwicklung
Nützlich für die Nutzer:
-Null Werte können nicht eingegeben werden da Eine Sqlite Datenbank verwendet wird.
-Sollte auf zb eine MariaDB umgestellt werden, so müsste die Datenbank auf Null Werte überprüft werden.
-Bei der Entwicklung wurde nicht Null verzichtet also könnte es zu fehlern kommen .
