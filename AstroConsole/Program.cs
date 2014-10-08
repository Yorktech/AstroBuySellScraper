using AstroScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AstroConsole
{
    class Program
    {
        private static int start = 0;
        private static int last = 0;
        private static Timer tick;

        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to the Astro Buy/Sell Watcher*****");
            Console.WriteLine("This program will watch for new posts on Astro Buy Sell and send an email to you whenever a new posting is found");
            Console.WriteLine("Edit the settings in the .config file to configure your email address");
            Console.WriteLine("THe default setting is check every 5 minutes");
            Console.WriteLine("Enter the current last advert number i.e : 75830 ?");
            start = Convert.ToInt32(Console.ReadLine());
            last = start;
            Console.WriteLine("Type quit to exit..");
            Console.WriteLine("Watching......");
           
            tick = new Timer(1000 * 60 * AstroConsole.Properties.Settings.Default.UpdateTimerMins);
            tick.Enabled = true;
            tick.Elapsed += timer_Elapsed;  
            while (true)
            {
                string keys = Console.ReadLine();

                if (keys.ToUpper() == "QUIT")
                {
                    Environment.Exit(0);
                }  
            }
           

        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var scraper = new Scraper();
            tick.Enabled = false;
            start = last;
            last = scraper.FindLatestItem(start);
            if (last!=start)

            {
                Console.WriteLine("New item found.  Go to http://www.astrobuysell.com/uk/propview.php?view=" + last);
                var emailer = new EmailHelper();
                emailer.SendMessage("New item found.  Go to http://www.astrobuysell.com/uk/propview.php?view=" + last,
                    AstroConsole.Properties.Settings.Default.EmailAddress,
                    AstroConsole.Properties.Settings.Default.EmailServer,
                    AstroConsole.Properties.Settings.Default.ServerPassword,
                    AstroConsole.Properties.Settings.Default.ServerUser);
            }
            tick.Enabled = true;
        }


    }
}
