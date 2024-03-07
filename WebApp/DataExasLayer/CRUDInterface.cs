namespace WebApp.Models;

public interface CRUDInterface
{
  List<Boot>GetAllBoats();
  Boot GetBoatById(int id);
  bool DeleteBoat(int id);
  bool UpdateBoat(Boot boot);
  int InsertBoat(Boot boot);
  string ConnectionString();
}