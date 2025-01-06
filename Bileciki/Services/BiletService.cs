using System.Linq;

public class BiletService : IBiletService
{
    private Database db;

    public BiletService(Database database)
    {
        db = database;
    }

    public void AddBilet(Bilet bilet)
    {
        db.Bilety.Add(bilet);
    }

    public Bilet GetBilet(int id)
    {
        return db.Bilety.FirstOrDefault(b => b.Id == id);
    }

    public void UpdateBilet(Bilet bilet)
    {
        var item = GetBilet(bilet.Id);
        if (item != null)
        {
            item.Typ = bilet.Typ;
            item.Cena = bilet.Cena;
        }
    }

    public void DeleteBilet(int id)
    {
        var item = GetBilet(id);
        if (item != null)
        {
            db.Bilety.Remove(item);
        }
    }
}
