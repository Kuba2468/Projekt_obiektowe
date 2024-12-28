using System;

public class Rezerwacja
{
    public int Id { get; set; }
    public Klient Klient { get; set; }
    public string Film { get; set; }
    public DateTime DataRezerwacji { get; set; }
    public Bilet Bilet { get; set; }
}
