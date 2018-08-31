using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScreenM
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public string ScreenType { get; set; }

        public string Resolution { get; set; }

        public bool Touch { get; set; }

        public ScreenM()
        {

        }
    }
}
