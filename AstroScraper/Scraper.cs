using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AstroScraper
{
    public class Scraper
    {
        public int ItemNumber { get; set; }
        public string Error = "update error";


        public Scraper()
        {
        }

        public Scraper(int startID)
        {
            ItemNumber = startID;
        }


        /// <summary>
        /// Scape the Ads
        /// </summary>
        /// <returns></returns>
        public List<Advert> ScrapeAds()
        {
            return new List<Advert>();
        }




        /// <summary>
        /// Find the latest item
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public int FindLatestItem(int seed)
        {
            string URI = "http://www.astrobuysell.com/uk/propview.php?view=" + seed;
            string data ="";
            
            WebResponse resp = null;
            while (!data.Contains(Error))
            {
                URI = "http://www.astrobuysell.com/uk/propview.php?view=" + seed;
                WebRequest req = WebRequest.Create(URI);
                resp = req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                data = sr.ReadToEnd().Trim();
                resp.Close();
                sr.Close();
                seed++;
            }
            return seed-2;
        }

        /// <summary>
        /// Has a new item been listed
        /// </summary>
        /// <returns></returns>
        public bool NewItemFound()
        {
            string URI = "http://www.astrobuysell.com/uk/propview.php?view=" + ItemNumber;
            WebRequest req = WebRequest.Create(URI);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string data = sr.ReadToEnd().Trim();
            sr.Close();
            resp.Close();
            resp.Dispose();
            if (data.Contains(Error))
                return false;
            else
            return true;
        }



    }
}
