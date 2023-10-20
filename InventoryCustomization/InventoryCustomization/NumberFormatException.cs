using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCustomization
{
    internal class NumberFormatException : Exception
    {
        public NumberFormatException(string quantity): base(quantity) { }
    }
}
