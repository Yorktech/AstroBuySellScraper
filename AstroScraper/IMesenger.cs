using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroScraper
{
    public interface IMessenger
    {
        void SendMessage(string message, string receiver, string server, string password, string serverUser);
    }
}
