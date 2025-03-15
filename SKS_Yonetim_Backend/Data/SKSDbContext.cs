using Microsoft.EntityFrameworkCore;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Data
{
          public class SKSDbContext(DbContextOptions<SKSDbContext> options) : DbContext(options)
          {
                    public DbSet<Kullanici> Kullanicis { get; set; }
                    public DbSet<Unvan> Unvans { get; set; }
                    public DbSet<Fakulte> Fakultes { get; set; }
                    public DbSet<Bolum> Bolums { get; set; }
                    public DbSet<Ogretmen> Ogretmens { get; set; }
                    public DbSet<Ogrenci> Ogrencis { get; set; }
                    public DbSet<HataLog> HataLogs { get; set; }
                    public DbSet<Personel> Personels { get; set; }
                    public DbSet<Randevu> Randevus { get; set; }
                    public DbSet<MailTemplate> MailTemplates { get; set; }
                    public DbSet<Randevum> Randevums { get; set; }
                    public DbSet<RandevuYeri> RandevuYeris { get; set; }
                    public DbSet<RandevuAlinanSaat> RandevuAlinanSaats { get; set; }
                    public DbSet<RandevuAlinmayacakSaat> RandevuAlinmayacakSaats { get; set; }
                    public DbSet<RandevuTur> RandevuTurs { get; set; }
                    public DbSet<RandevuYetkilendirme> RandevuYetkilendirmes { get; set; }
          }
}