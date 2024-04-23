using System.IO;

namespace Cysterny
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie.Załaduj();
            int nrZadania = 0;
            //int overflow = 0;
            int ilośćZadań;
            double wynik;
            using StreamReader sr = new("../../../plik.txt");
            ilośćZadań = int.Parse(sr.ReadLine().ToString());
            while (!sr.EndOfStream) // sprawdzenie końca pliku
            {
                nrZadania++;
                Zadanie zadanie = new();

                zadanie.Wczytaj(sr);
                zadanie.WczytajWodę(sr);
                wynik = zadanie.Rozwiąż();
                zadanie.WypiszWynik(wynik);
            }

        }
    }
}