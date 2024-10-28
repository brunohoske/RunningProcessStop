using System.Diagnostics;
using System.Net.Mail;
using System.Net;

public class EmailService
{
    public static void Send(MailMessage message)
    {
        string password = "Paraben#1";
        string smtpServer = "smtp.umbler.com";
        int smtpPort = 587;
         bool useSsl = false;
        try
        {
            using (var client = new SmtpClient(smtpServer))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(message.From.Address, password);
                client.EnableSsl = useSsl;
                using (var msg = message)
                {

                    client.Send(message);
                    Debug.Print("Email sent successfully!");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Print($"Erro ao enviar email para ${message?.To} :" + ex.Message);
        }
    }

    public static void SendWithAttachment(MailMessage message, string attachmentFilePath)
    {
        if (!string.IsNullOrEmpty(attachmentFilePath))
        {
            Attachment attachment = new Attachment(attachmentFilePath);
            message.Attachments.Add(attachment);
        }
        Send(message);
    }
}