using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Models.DtoViewModels
{
          public class DtoProfilModel
          {
                    public Kullanici Kullanici { get; set; }
                    public RolTip Rol { get; set; } // Kullanıcının rolünü belirtmek için

                    // Rol tipine göre ilgili nesneyi tutacak özellikler
                    public Ogrenci? Ogrenci { get; set; }
                    public Personel? Personel { get; set; }
                    public Ogretmen? Ogretmen { get; set; }

                    // Constructor (isteğe bağlı)
                    public DtoProfilModel(Kullanici kullanici, RolTip rol)
                    {
                              Kullanici = kullanici;
                              Rol = rol;

                              // Rol tipine göre ilgili nesneyi null olarak başlat
                              Ogrenci = null;
                              Personel = null;
                              Ogretmen = null;
                    }
          }
}