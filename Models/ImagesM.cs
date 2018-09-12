using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImagesM
    {
        public int Id { get; set; }

        public byte[] ImageBinary { get; set; } 

        public int MobileId { get; set; }

        public ImagesM()
        {

        }
    }
}
