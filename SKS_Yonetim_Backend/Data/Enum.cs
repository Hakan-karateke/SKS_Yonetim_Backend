namespace SKS_Yonetim_Backend.Data
{
          public enum RolTip
          {
                    Ogrenci,
                    Personel,
                    Ogretmen,
                    Admin,
          }
          public enum MailTip
          {
                    OnBasvuru,
                    Onay,
                    Red
          }
          public enum IslemTip
          {
                    Beklemede,
                    Onaylandi,
                    Reddedildi,
          }
          public enum DilKodu
          {
                    tr,
                    en
          }
          public enum RandevuTip
          {
                    Toplanti,
                    Egitim,
                    Sunum,
                    Diger,
                    Berber,
                    Kuaför,
                    DişHekimi,
                    Doktor,
          }
          public enum TekrarDurum
          {
                    TekrarYok,
                    Haftalik,
                    Aylik,
                    Yillik,
          }
}