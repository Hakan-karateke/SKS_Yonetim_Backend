using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
    public interface IRandevuTurDal : IEntityRepository<RandevuTur>
    {
        int GetRandevuTurCount();
        int GetRandevuTurCountByAktif(bool aktif);
    }
}