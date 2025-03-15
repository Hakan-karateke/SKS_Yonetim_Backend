using Microsoft.EntityFrameworkCore;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Data
{
          public class SKSDbContext(DbContextOptions<SKSDbContext> options) : DbContext(options)
          {
                    //Veri tabanı bağlantı ayarları
                    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    {
                              optionsBuilder.EnableSensitiveDataLogging();
                              if (!optionsBuilder.IsConfigured)
                              {
                                        if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
                                        {
                                                  optionsBuilder.UseSqlServer("server=localhost; database=SKSRandevuDB; User Id=SA; password=reallyStrongPwd123; TrustServerCertificate=True;");
                                        }
                                        else
                                        {
                                                  optionsBuilder.UseSqlServer("Server=.;Database=SKSRandevuDB;Trusted_Connection=SSPI;TrustServerCertificate=true;");
                                        }
                              }
                    }

                    public DbSet<Bolum> Bolum { get; set; }
                    public DbSet<Dil> Dil { get; set; }
                    public DbSet<Fakulte> Fakulte { get; set; }
                    public DbSet<HataLog> HataLog { get; set; }
                    public DbSet<Iletisim> Iletisim { get; set; }
                    public DbSet<Kullanici> Kullanici { get; set; }
                    public DbSet<MailTemplate> MailTemplate { get; set; }
                    public DbSet<Ogrenci> Ogrenci { get; set; }
                    public DbSet<Ogretmen> Ogretmen { get; set; }
                    public DbSet<Personel> Personel { get; set; }
                    public DbSet<Randevu> Randevu { get; set; }
                    public DbSet<RandevuAlinanSaat> RandevuAlinanSaat { get; set; }
                    public DbSet<RandevuAlinmayacakSaat> RandevuAlinmayacakSaat { get; set; }
                    public DbSet<RandevuGrup> RandevuGrup { get; set; }
                    public DbSet<Randevum> Randevum { get; set; }
                    public DbSet<RandevuTur> RandevuTur { get; set; }
                    public DbSet<RandevuYeri> RandevuYeri { get; set; }
                    public DbSet<RandevuYetkilendirme> RandevuYetkilendirme { get; set; }
                    public DbSet<Unvan> Unvan { get; set; }
          }
}