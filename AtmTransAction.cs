namespace AppAtm
{

    class AtmTransAction
    {
        public static void TransAction(User currentUser, List<User> users, Logger logger)
        {
            while (true)
            {
                int total = 0;
                try
                {
                    Console.Write("[1]- Hesap Bilgileri\n[2]- Para Çek\n[3]- Para Yatır\n[4]- Para Gönder\n[5]- Çıkış\nseciminiz: ");
                    char input = Convert.ToChar(Console.ReadLine());
                    Console.Clear();
                    switch (input)
                    {
                        case '1':
                            Console.WriteLine($"{currentUser.ID}-{currentUser.Name}\t Bakiye: {currentUser.Budget}");
                            break;
                        case '2':
                            withdrawal(currentUser, logger);
                            break;
                        case '3':
                            Deposit(currentUser, logger);
                            break;
                        case '4':
                            TransferMoney(currentUser, users, logger);
                            break;
                        case '5':
                            return;
                        default:
                            Console.WriteLine("Geçersiz Seçim");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Hatası alındı.");
                    logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {ex.Message} hatası alındı.");

                }
            }
        }


        public static void withdrawal(User currentUser, Logger logger)
        {
            Console.Write("Çekmek istediğiniz miktar: ");
            double input = Convert.ToDouble(Console.ReadLine());
            if (currentUser.Budget - input < 0)
            {
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının hesabından {input} miktarında para yetersiz bakiye sebebiyle çekilemedi.");
                Console.WriteLine("Hesap bakiyesi yetersiz.");
                return;
            }
            currentUser.Budget -= input;
            Console.WriteLine($"{input} başarıyla hesabınızdan çekildi.");
            logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının hesabından {input} miktarında para çekildi.");


        }
        public static void Deposit(User currentUser, Logger logger)
        {
            Console.Write("Yüklemek istediğiniz miktar: ");
            double input = Convert.ToDouble(Console.ReadLine());
            currentUser.Budget += input;
            Console.WriteLine($"{input} başarıyla hesabınıza yüklendi.");
            logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının hesabına {input} miktarında para yatırıldı.");

        }

        public static void TransferMoney(User currentUser, List<User> users, Logger logger)
        {
            Console.Write("Para göndermek istediğiniz hesap id: ");
            int receiverId = Convert.ToInt32(Console.ReadLine());

            User receiver = users.FirstOrDefault(x => x.ID == receiverId);
            if (receiver is null)
            {
                Console.WriteLine($"Alıcıya ait hesap bulunamadı.");
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının para gönderme işlemi alıcı hesabı bulunamadığından iptal edildi.");

                return;
            }

            Console.Write("Göndermek istediğiniz miktar: ");
            double input = Convert.ToDouble(Console.ReadLine());
            if (currentUser.Budget - input < 0)
            {
                logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının hesabından {receiver.ID} id'li kullanıcının hesabına {input} miktarında para yetersiz bakiye sebebiyle gönderilemedi.");
                Console.WriteLine("Hesap bakiyesi yetersiz.");
                return;
            }
            currentUser.Budget -= input;
            receiver.Budget += input;

            Console.WriteLine($"{input} başarıyla {receiver.ID} hesabına gönderildi.");
            logger.addlog($"{DateTime.Now.ToString("dd/MM/yyyy - hh.mm")} => {currentUser.ID} id'li kullanıcının hesabından {receiver.ID} id'li kullanıcının hesabına {input} miktarında para gönderildi.");

        }
    }

}