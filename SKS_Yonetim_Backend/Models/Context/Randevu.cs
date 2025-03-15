namespace SKS_Yonetim_Backend.Models.Context
{
          public class Randevu
          {
                    public int Id { get; set; }
                    public int KullaniciId { get; set; }
                    public required string RandevuAdi { get; set; }
                    public required string RandevuAciklama { get; set; }
                    public int RandevuYeriId { get; set; }
                    public bool Aktif { get; set; }
                    public int BasvuruSayisi { get; set; }
                    public int RandevuTip { get; set; }
                    public DateTime BaslangicTarihi { get; set; }
                    public DateTime BitisTarihi { get; set; }
                    public DateTime OlusturulmaTarihi { get; set; }
                    public DateTime GuncellenmeTarihi { get; set; }
                    public int OnaylayanId { get; set; }
                    public int OnayDurumu { get; set; }
                    public int Kota { get; set; }
                    public int AyniAndaKatilimSayisi { get; set; }
                    public bool AyniAndaKatilim { get; set; }

          }
}