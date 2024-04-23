
namespace Bramki
{
    class BramkaWUkładzie
    {
        public enum Uszkodzenie
        {
            brakUszkodzenia,
            sameJedynki,
            sameZera,
            Odwrócenie
            
        }
        internal Bramka bramka;
        internal BramkaWUkładzie[] polaczenia;
        internal bool? wyjscie;
        internal Uszkodzenie uszkodzenie;

        public void Ustaw(Bramka b)
        {
            bramka = b;
        }
        public void UstawPołączenia(BramkaWUkładzie[] połączenia)
        {
            polaczenia = połączenia;
        }

        internal bool Process()
        {
            if (wyjscie != null)
            {
                return (bool)wyjscie;
            }
            bool[] wejsciabramki = new bool[polaczenia.Length];
            for (int i = 0; i < polaczenia.Length; i++)
            {
                wejsciabramki[i] = polaczenia[i].Process();
            }
            
            if (uszkodzenie == Uszkodzenie.sameJedynki)
            {
                wyjscie = true;
            }
            else if (uszkodzenie == Uszkodzenie.sameZera)
            {
                wyjscie = false;
            }
            else if (uszkodzenie == Uszkodzenie.Odwrócenie)
            {
                wyjscie = !bramka.MapujBramke(wejsciabramki);
            }
            else if (uszkodzenie == Uszkodzenie.brakUszkodzenia)
            {
                wyjscie = bramka.MapujBramke(wejsciabramki);
            }
            
            return (bool)wyjscie;
        }
    }
}