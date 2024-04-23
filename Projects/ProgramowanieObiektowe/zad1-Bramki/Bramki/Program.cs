using System.IO;

namespace Bramki
{
    class Program
    {
        static void Main(string[] args)
        {
            int nrZadania = 0;
            int przypadek = 0;
            int nrBramki = 0;
            using (StreamReader sr = new StreamReader("../../../plik.txt"))
            {
                while (!sr.EndOfStream) // sprawdzenie końca pliku
                {
                    nrZadania++;
                    Zadanie zadanie = new Zadanie();
                    bool czyrozwiazac = zadanie.Wczytaj(sr);
                    if (czyrozwiazac == true)
                    {
                        (nrBramki, przypadek) = zadanie.Rozwiązywanie();
                        switch (przypadek)
                        {
                            case -2:
                                Console.WriteLine($"Case {nrZadania}: Unable to totally classify the failure");
                                break;
                            case -1:
                                Console.WriteLine($"Case {nrZadania}: No faults detected ");
                                break;
                            case 0:
                                Console.WriteLine($"Case {nrZadania}: Gate {nrBramki+1} is failing; output stuck at 1");
                                break;
                            case 1:
                                Console.WriteLine($"Case {nrZadania}: Gate {nrBramki+1} is failing; output stuck at 0");
                                break;
                            case 2:
                                Console.WriteLine($"Case {nrZadania}: Gate {nrBramki+1} is failing; output inverted");
                                break;
                        }
                    }
                }
            }
        }
    }
}
