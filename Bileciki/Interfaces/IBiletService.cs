public interface IBiletService
{
    void AddBilet(Bilet bilet);
    Bilet GetBilet(int id);
    void UpdateBilet(Bilet bilet);
    void DeleteBilet(int id);
}
