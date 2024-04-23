using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bramki
{
    abstract class Bramka
    {
        //protected int liczbaWejść;
        abstract public bool MapujBramke(params bool[] wejscia);
    }
    class And : Bramka
    {
        override public bool MapujBramke(params bool[] wejscia)
        {
            return wejscia[0] && wejscia[1];
        }
    }
    class Or : Bramka
    {
        override public bool MapujBramke(params bool[] wejscia)
        {
            return wejscia[0] || wejscia[1];
        }
    }
    class Xor : Bramka
    {
        override public bool MapujBramke(params bool[] wejscia)
        {
            return wejscia[0] ^ wejscia[1]; //operator XOR
        }
    }
    class Not : Bramka
    {
        override public bool MapujBramke(params bool[] wejscia)
        {
            return !wejscia[0];
        }
    }
}