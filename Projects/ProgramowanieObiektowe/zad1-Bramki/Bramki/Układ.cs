using System;
using System.IO;

namespace Bramki
{
    class Układ
    {
        internal BramkaWUkładzie[] bramki;
        internal BramkaWUkładzie[] wejscia;
        internal BramkaWUkładzie[] wyjscia;
        public void Wczytaj(TextReader tr)
        {
            string[] podzial = tr.ReadLine().ToString().Split(' ');
            wejscia = Zaalokuj(int.Parse(podzial[0]));
            bramki = Zaalokuj(int.Parse(podzial[1]));
            wyjscia = Zaalokuj(int.Parse(podzial[2]));

            if (wejscia.Length == 0)
            {
                return;
            }
            Bramka bramka = null;
            for (int i = 0; i < bramki.Length; i++)
            {
                podzial = tr.ReadLine().ToString().Split(' ');

                switch (podzial[0])
                {
                    case "a":
                        bramka = new And();
                        break;
                    case "o":
                        bramka = new Or();
                        break;
                    case "n":
                        bramka = new Not();
                        break;
                    case "x":
                        bramka = new Xor();
                        break;
                }
                bramki[i].Ustaw(bramka);
                BramkaWUkładzie[] inputy = new BramkaWUkładzie[podzial.Length - 1];
                for (int j = 1; j < podzial.Length; j++)
                {
                    int index = podzial[j][1] - '0';
                    if (podzial[j][0] == 'i')
                    {
                        inputy[j - 1] = wejscia[index - 1];
                    }
                    if (podzial[j][0] == 'g')
                    {
                        inputy[j - 1] = bramki[index - 1];
                    }
                }
                bramki[i].UstawPołączenia(inputy);
            }
            
            podzial = tr.ReadLine().ToString().Split(' ');
            for (int i = 0; i < podzial.Length; i++)
            {
                wyjscia[i] = bramki[int.Parse(podzial[i]) - 1];
            }
        }

        internal void Uszkodzenie(int i, int rodzajUszkodzenia)
        {
            switch (rodzajUszkodzenia)
            {
                case (-1):
                    bramki[i].uszkodzenie = BramkaWUkładzie.Uszkodzenie.brakUszkodzenia;
                    break;
                case (0):
                    bramki[i].uszkodzenie = BramkaWUkładzie.Uszkodzenie.sameJedynki;
                    break;
                case (1):
                    bramki[i].uszkodzenie = BramkaWUkładzie.Uszkodzenie.sameZera;
                    break;
                case (2):
                    bramki[i].uszkodzenie = BramkaWUkładzie.Uszkodzenie.Odwrócenie;
                    break;
            }
        }
        internal int IleWy()
        {
            return wyjscia.Length;
        }
        internal int IleWe()
        {
            return wejscia.Length;
        }
        internal int IleBr()
        {
            return bramki.Length;
        }
        private BramkaWUkładzie[] Zaalokuj(int ile)
        {
            var bramki = new BramkaWUkładzie[ile];

            for (int i = 0; i < bramki.Length; i++)
            {
                bramki[i] = new BramkaWUkładzie();
            }
            return bramki;
        }
        private void ResetBramek()
        {
            for (int i = 0; i < bramki.Length; i++)
            {
                bramki[i].wyjscie = null;
            }
        }
        private void UstawWejscia(bool[] wejsciab)
        {
            for (int i = 0; i < wejscia.Length; i++)
            {
                wejscia[i].wyjscie = wejsciab[i];
            }
        }
        public bool[] Process(bool[] wejsciab)
        {
            ResetBramek();//reset bramek - wartosci "bool"
            UstawWejscia(wejsciab);//ustawienie wartości wejść - "bool"
            bool[] wyjsciab;
            wyjsciab = new bool[IleWy()];
            for (int i = 0; i < wyjsciab.Length; i++)
            {
                wyjsciab[i] = wyjscia[i].Process();
            }
            return wyjsciab;
        }
    }
}