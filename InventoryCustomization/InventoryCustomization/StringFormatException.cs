using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCustomization
{
    internal class StringFormatException : Exception
    {
        public StringFormatException(string productName) : base(productName) { }
    }
}
