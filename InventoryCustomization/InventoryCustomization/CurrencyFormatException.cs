using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCustomization
{
    internal class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string sellPrice) : base (sellPrice) { }
    }
}
