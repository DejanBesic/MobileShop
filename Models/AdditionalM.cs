using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdditionalM
    {
        public int Id { get; set;  }

        public string Description { get; set; }

        public AdditionalM()
        {

        }

        public AdditionalM(int id, string description)
        {
            Id = id;
            Description = description;
        }

    }
}
