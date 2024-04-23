using System;
using System.IO;

namespace Bramki
{
    public class Zadanie
    {
        private Układ układ;
        private Test[] testy;
        public bool Wczytaj(TextReader tr)
        {
            układ = new Układ();
            układ.Wczytaj(tr);
            if (układ.IleWe()==0 &&  układ.IleBr()== 0 && układ.IleWy() == 0)  //sprawdzenie lini 0 0 0 w układzie
            {
                return false; // nie rozwiazuj zadania
            }
            
            int ileT = int.Parse(tr.ReadLine());
            testy = new Test[ileT];
            for (int i = 0; i < ileT; i++)
            {
                testy[i].Wczytaj(tr, układ.IleWe(), układ.IleWy()); // rekurencyjnie wczytuje każdy test
            }
            return true; // rozwiazuj zadanie
        }
        
        public bool SąRówne(bool[] wyjściep, bool[] wyjścietestów)
        {
            for (int i = 0; i < wyjściep.Length; i++)
            {
                if (wyjściep[i] != wyjścietestów[i])
                {
                    return false;
                }
            }
            return true;
        }
        public (int, int) Rozwiązywanie()
         {
            for (int i = 0; i < układ.IleBr(); i++)
            {
                układ.Uszkodzenie(i, -1);
            }
                bool wynikTestow = PoprawnośćTestów();
                int wynikiTestow = 0; int i2 = 0;int j2 = 0;
            if (wynikTestow)
            {
                return (-1, -1);
            }
            else
            {
                for (int i = 0; i < układ.IleBr(); i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        układ.Uszkodzenie(i, j);
                        wynikTestow = PoprawnośćTestów();
                        if (wynikTestow)
                        {
                            wynikiTestow++;
                            i2 = i; j2 = j; // zapamiętanie wartości
                            
                        }
                        układ.Uszkodzenie(i, -1); // -1 ma symbolizować że wyłączamy uszkodzenie
                    }
                }
                if (wynikiTestow==1)
                {
                    return (i2, j2); // returnowanie zapamiętanych wartości
                }
                return (-2, -2); //Nie wiadomo co nie działa, nie da się stwierdzić
            }
        }
        public bool PoprawnośćTestów()
        {
            bool[] wyjsciab = new bool[układ.IleWy()];
            bool CzyDziała = true;
            for (int i = 0; i < testy.Length; i++)
            {
                wyjsciab = układ.Process(testy[i].wejscia);
                bool Zgodność = SąRówne(wyjsciab, testy[i].wyjscia);
                if (Zgodność == false)
                {
                    return false;
                }
            }
                return true;
        }
    }
}