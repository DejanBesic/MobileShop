using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShopM
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactMobilePhone { get; set; }

        public string ContactAddress { get; set; }

        public bool HirePayment { get; set; }

        public string OpenTime { get; set; }


        public ShopM()
        {

        }
    }
}
