using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalData.Model
{
    public partial class Vendor
    {
        public override string ToString()
        {
            return "Name: " + Name + ", ID: " + BusinessEntityID;
        }
        public string Info
        {
            get => ToString();
        }
    }
}
