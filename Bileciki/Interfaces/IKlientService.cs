public interface IKlientService
{
    void AddKlient(Klient klient);
    Klient GetKlient(int id);
    void UpdateKlient(Klient klient);
    void DeleteKlient(int id);
}
