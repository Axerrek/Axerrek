using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bramki
{
    struct Test
    {
        internal bool[] wejscia;
        internal bool[] wyjscia;
        internal void Wczytaj(TextReader tr, int liczbaWejść, int liczbaWyjść)
        {
            string[] podzial = tr.ReadLine().ToString().Split(' ');
            wejscia = new bool[liczbaWejść];
            wyjscia = new bool[liczbaWyjść];
            for (int i = 0; i < wejscia.Length; i++)
            {
                wejscia[i] = int.Parse(podzial[i]) == 1;
            }
            for (int i = 0; i < wyjscia.Length; i++)
            {
                wyjscia[i] = int.Parse(podzial[i + wejscia.Length]) == 1;
            }
        }
    }
}