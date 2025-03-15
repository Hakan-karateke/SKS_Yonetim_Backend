using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IServices;

namespace SKS_Yonetim_Backend.Services
{
          public class EmailService : IEmailService
          {
                    public async Task<bool> MailGonder(string from, string fromSifre, MailAddress to, string subject, string sablonDetay, FileContentResult fileResult)
                    {
                              try
                              {
                                        Attachment? data = null;

                                        // Dosya eklenmişse
                                        if (fileResult != null)
                                        {
                                                  using var memoryStream = new MemoryStream(fileResult.FileContents);
                                                  data = new Attachment(memoryStream, fileResult.FileDownloadName, fileResult.ContentType);
                                        }

                                        string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
                                        NetworkCredential credentials;
                                        MailAddress recipient = to;

                                        // Development ortamında farklı bir ayar kullan
                                        if (string.Equals(env, "Development", StringComparison.OrdinalIgnoreCase))
                                        {
                                                  credentials = new NetworkCredential("sksyonetim@gmail.com", "test");
                                                  subject = "!!Yazılım TEST Mailidir!! " + subject + " (Original To: " + to.Address + ") From: " + from;
                                                  recipient = new MailAddress("teamskstest@gmail.com");
                                        }
                                        else
                                        {
                                                  credentials = new NetworkCredential(from, fromSifre);
                                        }

                                        // SMTP client ayarları
                                        using var smtp = new SmtpClient
                                        {
                                                  Host = "smtp.gmail.com",
                                                  Port = 587,
                                                  DeliveryMethod = SmtpDeliveryMethod.Network,
                                                  UseDefaultCredentials = false, // Doğru ayarlandı
                                                  EnableSsl = true,
                                                  Credentials = credentials,
                                        };

                                        // MailMessage oluşturma
                                        using var message = new MailMessage(new MailAddress(from), recipient)
                                        {
                                                  Subject = subject,
                                                  Body = sablonDetay,
                                                  IsBodyHtml = true
                                        };

                                        // Dosya ekleme
                                        if (data != null)
                                        {
                                                  message.Attachments.Add(data);
                                        }

                                        // E-posta gönderme
                                        await smtp.SendMailAsync(message);

                                        return true;
                              }
                              catch
                              {
                                        return false;
                              }
                    }
          }
}