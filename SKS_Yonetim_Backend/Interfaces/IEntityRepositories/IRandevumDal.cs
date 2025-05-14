using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
    public interface IRandevumDal : IEntityRepository<Randevum>
    {
        Task<List<Randevum>> GetAllRandevularByPageSize(int pageSize);
        Task<List<Randevum>> GetRandevularByDate(DateTime date);
        Task<List<Randevum>> GetRandevularByKullaniciIdAndPageSize(int kullaniciId, int pageSize);
        Task<List<Randevum>> GetRandevularByDateAndUserId(DateTime date, int userId);
        int GetRandevuCountByUserId(int userId);
        int GetAllRandevumCount();
        int GetRandevuCountByDate(DateTime date);
        int GetRandevuCountByOnaylandiMi(bool onaylandiMi);
    }
}