using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DMobile
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Model { get; set; }

        public DMobile(int id, string name, string model)
        {
            Id = id;
            Name = name;
            Model = model;
        }
    }
}
