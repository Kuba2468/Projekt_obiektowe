using System;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var klientService = new KlientService(db);
        var biletService = new BiletService(db);
        var rezerwacjaService = new RezerwacjaService(db);

        Console.WriteLine("Podaj imię klienta:");
        string imie = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko klienta:");
        string nazwisko = Console.ReadLine();

        var klient = new Klient { Id = db.Klienci.Count + 1, Imie = imie, Nazwisko = nazwisko };
        klientService.AddKlient(klient);
        Console.WriteLine($"Dodano klienta: {imie} {nazwisko}");

        Console.WriteLine("\nWybierz film:");
        Console.WriteLine("1. Avatar 2");
        Console.WriteLine("2. Oppenheimer");
        Console.WriteLine("3. Spider-Man: Daleko od domu");
        Console.WriteLine("4. The Marvels");
        Console.WriteLine("5. Hunters");

        int filmWybór = int.Parse(Console.ReadLine());

        string film = filmWybór switch
        {
            1 => "Avatar 2",
            2 => "Oppenheimer",
            3 => "Spider-Man: Daleko od domu",
            4 => "The Marvels",
            5 => "Hunters",
            _ => "Avatar 2"
        };

        Console.WriteLine("\nWybierz datę:");
        Console.WriteLine("1. 2025-12-20");
        Console.WriteLine("2. 2025-12-21");
        Console.WriteLine("3. 2025-12-22");
        int dataWybór = int.Parse(Console.ReadLine());

        DateTime data = dataWybór switch
        {
            1 => new DateTime(2025, 12, 20),
            2 => new DateTime(2025, 12, 21),
            3 => new DateTime(2025, 12, 22),
            _ => new DateTime(2025, 12, 20)
        };

        Console.WriteLine("\nWybierz godzinę seansu:");
        Console.WriteLine("1. 12:00");
        Console.WriteLine("2. 15:00");
        Console.WriteLine("3. 18:00");
        Console.WriteLine("4. 21:00");
        int godzinaWybór = int.Parse(Console.ReadLine());

        TimeSpan godzina = godzinaWybór switch
        {
            1 => new TimeSpan(12, 0, 0),
            2 => new TimeSpan(15, 0, 0),
            3 => new TimeSpan(18, 0, 0),
            4 => new TimeSpan(21, 0, 0),
            _ => new TimeSpan(12, 0, 0)
        };

        data = data.Add(godzina);

        Console.WriteLine("\nWybierz typ biletu:");
        Console.WriteLine("1. Normalny - 30 zł");
        Console.WriteLine("2. Ulgowy - 20 zł");
        Console.WriteLine("3. Premium - 50 zł");
        int biletWybór = int.Parse(Console.ReadLine());

        var bilet = new Bilet
        {
            Id = db.Bilety.Count + 1,
            Typ = biletWybór switch
            {
                1 => "Normalny",
                2 => "Ulgowy",
                3 => "Premium",
                _ => "Normalny"
            },
            Cena = biletWybór switch
            {
                1 => 30.00,
                2 => 20.00,
                3 => 50.00,
                _ => 30.00
            }
        };
        biletService.AddBilet(bilet);

        var rezerwacja = new Rezerwacja
        {
            Id = db.Rezerwacje.Count + 1,
            Klient = klient,
            Film = film,
            DataRezerwacji = data,
            Bilet = bilet
        };
        rezerwacjaService.AddRezerwacja(rezerwacja);

        Console.WriteLine("\nRezerwacja została dodana!");
        Console.WriteLine($"Film: {film}");
        Console.WriteLine($"Data i godzina: {data:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Bilet: {bilet.Typ} - {bilet.Cena} zł");
    }
}
