
using System.Collections.Generic;

namespace AppAtm
{
    public class Auth
    {


        public static User Login(List<User> users, Logger logger)
        {
            Console.Write("Id giriniz: ");
            int Id =Convert.ToInt32(Console.ReadLine());
            Console.Write("Şifre giriniz: ");
            string password = Console.ReadLine();
            User currentUser = users.FirstOrDefault(x => x.ID == Id&&x.password==password);
            Console.Clear();
            if (currentUser is null)
            {
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => Hatalı Id veya Şifre girildi. ID: {Id}");
                throw new InvalidOperationException("Id veya şifre hatalı");
            }
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {Id} id'li hesaba giriş yapıldı.");

            return currentUser;

        }


        public static User SignUp(int newId, Logger logger)
        {

            Console.Write("Kayıt olmak için adınızı giriniz: ");
            string name = Console.ReadLine();
            
            Console.Write("Şifrenizi giriniz: ");
            string password = Console.ReadLine();

            User newUser = new User();
            newUser.ID = ++newId;
            newUser.Name = name;
            newUser.Budget=0.0;
            newUser.password=password;
            Console.Clear();
            Console.WriteLine($"Id'niz: {newUser.ID}");
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {newId} id'li hesap oluşturuldu.");

            return newUser;

        }


    }
}