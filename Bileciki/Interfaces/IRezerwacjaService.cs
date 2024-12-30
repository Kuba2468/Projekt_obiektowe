using System;

public interface IRezerwacjaService
{
    void AddRezerwacja(Rezerwacja rezerwacja);
    Rezerwacja GetRezerwacja(int id);
    void UpdateRezerwacja(Rezerwacja rezerwacja);
    void DeleteRezerwacja(int id);
}
