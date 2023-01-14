
using System.Collections.Generic;

namespace AppAtm
{
    public class Atm
    {
        public static List<User> users = new List<User>(){
                new User(){ ID = 1,  Name="Kaan",password="kaan",Budget=200510.30},
                new User(){ ID = 2, Name="Berkay",password="berkay",Budget=68500.00},
                new User(){ ID = 3,  Name="Ezgi",password="ezgi",Budget=13500.65},
                new User(){ ID = 4,  Name="Mustafa",password="mustafa",Budget=5200.34}
            };
        public static User currentUser;

        public static void AtmApp()
        {
            Logger logger = new Logger();
            while (true)
            {
                int total = 0;
                try
                {
                    Console.Write("[1]- Giriş\n[2]- Kayıt Ol\n[3] Gün Sonu\n[4]- Çıkış\nseciminiz: ");
                    char input = Convert.ToChar(Console.ReadLine());
                    Console.Clear();
                    switch (input)
                    {
                        case '1':
                            currentUser = Auth.Login(users, logger);
                            AtmTransAction.TransAction(currentUser, users, logger);
                            break;
                        case '2':
                            users.Add(Auth.SignUp(users.Count(),logger));
                            break;
                        case '3':
                        logger.EndOfDay();
                            break;
                        case '4':
                            return;
                        default:
                            Console.WriteLine("Geçersiz Seçim");
                            break;

                    }
                }
                catch (Exception ex)
                {
                   logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {ex.Message} hatası alındı.");

                    Console.WriteLine(ex.Message + " Hatası alındı.");
                }
            }
        }



    }
}