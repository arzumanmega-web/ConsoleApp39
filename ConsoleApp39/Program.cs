using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp39
{
    internal class Program
    {
        static string fromMail = "arzuman.mega@gmail.com"; 
        static string appPassword = "awkc eauh nziv xkbk"; 

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Adinizi daxil edin: ");
            var name = Console.ReadLine();
            Console.Write("Email adresinizi daxil edin: ");
            var email = Console.ReadLine();
            Console.Write("paswordunuzu daxil edin: ");
            var password = Console.ReadLine();

            int number = Random.Shared.Next(100000, 1000000);
            string number2 = number.ToString();

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(fromMail);
                mail.To.Add(email);
                mail.Subject = "verify";
                mail.Body = $"Tesdiq kodu: {number2}";

                var smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromMail, appPassword);

                smtp.Send(mail);
                Console.WriteLine("Mail send succesfuly...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
                return; 
            }

            bool isSuccess = false;

            bool isError = false;
            var minute = new Task(() =>

            {

                for (int i = 0; i < 180; i++)

                {
                    if (i == 0)
                    {
                        isError = true;
                    }
                    Thread.Sleep(1000);

                   

                }

                isError = false;

            });

            minute.Start();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Tesdiq kodunuzu daxil edin: ");
                var verification = Console.ReadLine();

                if (number2 == verification)
                {
                    Console.WriteLine("qeydiyyat ugurla basa catdi...");
                    isSuccess = true;
                    break;
                }
                if (isError)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("sehv kod...");
                }
            }

            if (!isSuccess)
            {
                Console.WriteLine("tesdiq kodu vaxti bitdi...");
            }

            
        }
    }
}