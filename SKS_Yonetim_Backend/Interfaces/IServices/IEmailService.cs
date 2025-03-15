using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace SKS_Yonetim_Backend.Interfaces.IServices
{
    public interface IEmailService
    {
        Task<bool> MailGonder(string from, string fromSifre, MailAddress to, string subject, string sablonDetay, FileContentResult fileResult);
    }
}