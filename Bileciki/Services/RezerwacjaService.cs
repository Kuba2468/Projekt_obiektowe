using System;
using System.Linq;

public class RezerwacjaService : IRezerwacjaService
{
    private Database db;

    public RezerwacjaService(Database database)
    {
        db = database;
    }

    public void AddRezerwacja(Rezerwacja rezerwacja)
    {
        if (rezerwacja.DataRezerwacji <= DateTime.Now)
        {
            throw new Exception("Data musi być w przyszłości.");
        }
        db.Rezerwacje.Add(rezerwacja);
    }

    public Rezerwacja GetRezerwacja(int id)
    {
        return db.Rezerwacje.FirstOrDefault(r => r.Id == id);
    }

    public void UpdateRezerwacja(Rezerwacja rezerwacja)
    {
        var item = GetRezerwacja(rezerwacja.Id);
        if (item != null)
        {
            item.Film = rezerwacja.Film;
            item.DataRezerwacji = rezerwacja.DataRezerwacji;
            item.Bilet = rezerwacja.Bilet;
        }
    }

    public void DeleteRezerwacja(int id)
    {
        var item = GetRezerwacja(id);
        if (item != null)
        {
            db.Rezerwacje.Remove(item);
        }
    }
}
