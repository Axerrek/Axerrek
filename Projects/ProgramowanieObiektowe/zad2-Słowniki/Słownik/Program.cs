using System;
using System.Collections.Generic;

namespace EksperymentSłownikowy
{
    public interface IWartośćKlucza
    {
        int Wartość { get; set; }
    }

    class KlasaZłyHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        // Niepoprawna implementacja GetHashCode()
        public override int GetHashCode()
        {
            return 0; // Stała wartość - najgorszy możliwy kod haszujący
        }

        // Przesłonięcie metody Equals() wraz z GetHashCode() jest zalecane
        // W tym przykładzie porównujemy wartości pól Wartość
        public override bool Equals(object obj)
        {
            if (obj is KlasaZłyHashCode innyklucz)
            {
                return Wartość == innyklucz.Wartość;
            }
            return false;
        }
    }

    class KlasaDobryHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        public override int GetHashCode()
        {
            return Wartość.GetHashCode();
        }

        // Przesłonięcie metody Equals() wraz z GetHashCode() jest zalecane
        // W tym przykładzie porównujemy wartości pól Wartość
        public override bool Equals(object obj)
        {
            if (obj is KlasaDobryHashCode innyklucz)
            {
                return Wartość == innyklucz.Wartość;
            }
            return false;
        }
    }

    class KlasaBezHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        // Przesłonięcie metody Equals(), ale brak implementacji GetHashCode()
        /*
        public override bool Equals(object obj)
        {
            if (obj is KlasaBezHashCode innyklucz)
            {
                return Wartość == innyklucz.Wartość;
            }
            return false;
        }
        */
    }


    struct StrukturaZłyHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        // Niepoprawna implementacja GetHashCode()
        public override int GetHashCode()
        {
            return 0; // Stała wartość - najgorszy możliwy kod haszujący
        }
    }

    struct StrukturaDobryHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        public override int GetHashCode()
        {
            return Wartość.GetHashCode();
        }
    }

    struct StrukturaBezHashCode : IWartośćKlucza
    {
        public int Wartość { get; set; }

        // Przesłonięcie metody Equals(), ale brak implementacji GetHashCode()
        public override bool Equals(object obj)
        {
            if (obj is StrukturaBezHashCode innyklucz)
            {
                return Wartość == innyklucz.Wartość;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int RozmiarSłownika = 10000; // Rozmiar słownika

            // Testowanie różnych kombinacji kluczy w słowniku
            Console.WriteLine("Testowanie klasy z niewłaściwym GetHashCode():");
            TestDictionary<KlasaZłyHashCode>(RozmiarSłownika);

            Console.WriteLine("\nTestowanie klasy z poprawnym GetHashCode():");
            TestDictionary<KlasaDobryHashCode>(RozmiarSłownika);

            Console.WriteLine("\nTestowanie klasy bez GetHashCode():");
            TestDictionary<KlasaBezHashCode>(RozmiarSłownika);

            Console.WriteLine("\nTestowanie struktury z niewłaściwym GetHashCode():");
            TestDictionary<StrukturaZłyHashCode>(RozmiarSłownika);

            Console.WriteLine("\nTestowanie struktury z poprawnym GetHashCode():");
            TestDictionary<StrukturaDobryHashCode>(RozmiarSłownika);

            Console.WriteLine("\nTestowanie struktury bez GetHashCode():");
            TestDictionary<StrukturaBezHashCode>(RozmiarSłownika);

            Console.WriteLine("Koniec");
        }

        static void TestDictionary<TKlucz>(int RozmiarSłownika)
            where TKlucz : IWartośćKlucza, new()
        {
            Dictionary<TKlucz, int> dictionary = new Dictionary<TKlucz, int>();
            DateTime start = DateTime.Now;

            Random random = new Random(13);
            // Dodawanie elementów do słownika
            for (int i = 0; i < RozmiarSłownika; i++)
            {
                TKlucz klucz = new TKlucz() { Wartość = i };
                dictionary[klucz] = i + 1;
            }

            TimeSpan koniec = DateTime.Now - start;
            Console.WriteLine("Czas dodawania elementów do słownika: " + koniec.ToString());

            // Pobieranie wartości z słownika
            int temp_int, counter = 0;
            start = DateTime.Now;
            TKlucz y = new TKlucz();
            for (int i = 0; i < RozmiarSłownika; i++)
            {
                y.Wartość = random.Next(0, RozmiarSłownika); // Ustawienie wartości za pomocą właściwości set
                if (!dictionary.TryGetValue(y, out temp_int))
                {
                    counter++;
                }
            }
            koniec = DateTime.Now - start;

            // Wyświetlanie wyników
            Console.WriteLine("Czas szuaknia elementów w słowniku: " + koniec.ToString());
            Console.WriteLine("Ilosć nie znalezionych elementów mimo istniejących obiektów o szukanych polach: " + counter);

            TKlucz z = new TKlucz();
            z.Wartość = 500; // Ustawienie wartości za pomocą właściwości set
            y.Wartość = 500; // Ustawienie wartości za pomocą właściwości set
            Console.WriteLine("Czy dwa obiekty o takiej samej wartości pól są sobie równe? " + y.Equals(z));
            Console.WriteLine("Czy dwa obiekty o takiej samej referencji są sobie równe? " + y.Equals(y));

        }
        
    }
    /*
Opis wniosków:

Implementacja GetHashCode() jest istotna: Metoda GetHashCode() jest kluczowa dla wydajnego działania słownika. 
    Poprawna implementacja tej metody pozwala na szybkie wyszukiwanie i porównywanie kluczy w słowniku. Niepoprawna 
    lub brak implementacji GetHashCode() może prowadzić do wolniejszych operacji i błędów, takich jak KeyNotFoundException.

Klasa a struktura: Implementacja GetHashCode() ma różne skutki dla klas i struktur. Dla klas, domyślna implementacja GetHashCode() 
    porównuje referencje, co oznacza, że dwa różne obiekty klasy o takich samych wartościach pól mogą mieć różne hashe. Dlatego ważne 
    jest ręczne przesłonięcie tej metody w klasach, aby zapewnić poprawne porównywanie obiektów. Dla struktur, domyślna implementacja 
    GetHashCode() porównuje pola, więc dwa różne obiekty struktury o takich samych wartościach pól będą miały takie same hashe.

Rola metody Equals(): Implementacja GetHashCode() często idzie w parze z przesłonięciem metody Equals(). To dlatego, że Equals() 
    jest ostatecznym decydentem w porównywaniu kluczy w słowniku. Implementacja Equals() powinna porównywać wszystkie pola klucza, 
    podobnie jak metoda GetHashCode().

 */

}
