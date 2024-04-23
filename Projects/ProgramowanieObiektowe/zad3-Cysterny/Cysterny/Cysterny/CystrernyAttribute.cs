using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cysterny
{
    public class CysternaAttribute : Attribute
    {
        public string Symbol { get; }

        public CysternaAttribute(string symbol)
        {
            Symbol = symbol;
            CysternaAttribute.Mapowanie[symbol] = this.GetType();
        }

        public static Dictionary<string, Type> Mapowanie { get; } = new Dictionary<string, Type>();
    }
}
