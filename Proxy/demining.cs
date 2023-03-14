using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface demining
    {
        public string demine();
    }
    public class deminer : demining
    {
        public deminer() { }
        public string demine()
        {
            Random random = new Random();
            if (random.Next(1, 5) == 1)
            {
                return "Все розірвало в щент";
            }
            return "Міна знешкоджена";
        }
    }
    public class ProxyDeminer : demining
    {
        deminer Old_Boiii = new deminer();
        public ProxyDeminer() { }
        public string demine()
        {
            if (Old_Boiii == null)
            {
                Old_Boiii = new deminer();
            }
            return Old_Boiii.demine() ;
        }
    }

}
