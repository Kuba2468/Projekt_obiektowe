using System.Linq;

public class KlientService : IKlientService
{
    private Database db;

    public KlientService(Database database)
    {
        db = database;
    }

    public void AddKlient(Klient klient)
    {
        db.Klienci.Add(klient);
    }

    public Klient GetKlient(int id)
    {
        return db.Klienci.FirstOrDefault(k => k.Id == id);
    }

    public void UpdateKlient(Klient klient)
    {
        var item = GetKlient(klient.Id);
        if (item != null)
        {
            item.Imie = klient.Imie;
            item.Nazwisko = klient.Nazwisko;
        }
    }

    public void DeleteKlient(int id)
    {
        var item = GetKlient(id);
        if (item != null)
        {
            db.Klienci.Remove(item);
        }
    }
}
