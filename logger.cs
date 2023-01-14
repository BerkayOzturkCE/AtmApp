namespace AppAtm
{

    public class Logger
    {
        public static List<string> logs = new List<string>();

        public void addlog(String message)
        {
            logs.Add(message);

        }
        public void EndOfDay()
        {
            try
            {
                FileStream fs = new FileStream(Environment.CurrentDirectory + @"\logfiles\" + DateTime.Now.ToString("ddMMyyyy") + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                StreamWriter sw = new StreamWriter(fs);
                foreach (var log in logs)
                {
                    sw.WriteLine(log);

                }

                sw.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex + " hatası alındı.");
            }

        }

    }
}