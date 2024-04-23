using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cysterny
{
    public class Zadanie
    {
        public Cysterna[] zbiorniki;
        int woda;
        

        public void WczytajWodę(TextReader tr)
        {
            woda = int.Parse(tr.ReadLine());
        }
        public void Wczytaj(TextReader tr)
        {
            int ilośćCystern = int.Parse(tr.ReadLine());
            zbiorniki = new Cysterna[ilośćCystern];

            for (int j = 0; j < ilośćCystern; j++)
            {
                string[] input = tr.ReadLine().Split(' ');
                int poziom = int.Parse(input[0]);
                string typZbiornika = input[1].Trim();
                string[] wymiary = input.Skip(2).ToArray();

                if (CysternaAttribute.Mapowanie.ContainsKey(typZbiornika))
                {
                    Type typKlasy = CysternaAttribute.Mapowanie[typZbiornika];
                    object[] constructorArgs = new object[] { (double)poziom, wymiary};
                    object obj = Activator.CreateInstance(typKlasy, constructorArgs);
                    zbiorniki[j] = (Cysterna)obj;
                }
            }
        }

        public bool CzyOverflow(double woda)
        {
            for (int i = 0; i < zbiorniki.Length; i++)
            {
                woda -= (double)zbiorniki[i].Pojemność();
            }
            if (woda >= 0) // jeśli została woda pomimo zapełnienia zbiorników, mamy OVERFLOW
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double ObliczMaxWodę()
        {
            double MaxWoda = 0;
            for (int i = 0; i < zbiorniki.Length; i++) // pętla na ustalenie maximum zbiorników
            {
                if (MaxWoda < (int)zbiorniki[i].poziom + (int)zbiorniki[i].wysokość)
                {
                    MaxWoda = (int)zbiorniki[i].poziom + (int)zbiorniki[i].wysokość;
                }
            }
            return MaxWoda;
        }

        public double UsuwanieStrefyBezZbiornikowej(double liniaBisekcji)
        {
            double nowaLiniaBisekcji = 0;
            for (int i = 0; i < zbiorniki.Length; i++)
            {
                if (liniaBisekcji >= zbiorniki[i].poziom && liniaBisekcji <= (zbiorniki[i].poziom + zbiorniki[i].wysokość))
                {
                    return liniaBisekcji;
                }
                if ((zbiorniki[i].poziom + zbiorniki[i].wysokość) <= liniaBisekcji && nowaLiniaBisekcji < (zbiorniki[i].poziom + zbiorniki[i].wysokość))
                {
                    nowaLiniaBisekcji = (zbiorniki[i].poziom + zbiorniki[i].wysokość);
                }
            }
            if (nowaLiniaBisekcji > 0)
            {
                return nowaLiniaBisekcji;
            }
            return liniaBisekcji;
        }

        public double Rozwiąż()
        {
            bool overflow = CzyOverflow(woda); // parametr, czy jest overflow czy nie

            double sufitBisekcji = ObliczMaxWodę(); // maksymalna wysokość - poziom zbiornika+wysokość najwyższa
            double podłogaBisekcji = 0;
            double liniaBisekcji = sufitBisekcji / 2;

            double wodaSprawdzenie;
            while (overflow == false)
            {
                wodaSprawdzenie = woda;
                for (int i = 0; i < zbiorniki.Length; i++)
                {
                    wodaSprawdzenie -= zbiorniki[i].ObliczObjętośćDlaPoziomu(liniaBisekcji);
                }
                if (wodaSprawdzenie < 0.01 && wodaSprawdzenie > -0.01)
                {
                    liniaBisekcji = UsuwanieStrefyBezZbiornikowej(liniaBisekcji); //sprawdzenie od której wysokości zaczyna się zbiornik
                    return Math.Round(liniaBisekcji, 2);
                }
                if (wodaSprawdzenie > 0)
                {
                    podłogaBisekcji = liniaBisekcji;
                    liniaBisekcji = (sufitBisekcji + podłogaBisekcji) / 2;
                }
                else
                {
                    sufitBisekcji = liniaBisekcji;
                    liniaBisekcji = (sufitBisekcji + podłogaBisekcji) / 2;
                }
            }
            return 0;
        }

        public void WypiszWynik(double wynik)
        {
            if (wynik == 0)
            {
                Console.WriteLine("OVERWFLOW");
            }
            else
            {
                Console.WriteLine(Math.Round(wynik, 2));
            }
        }
        internal static Dictionary<string, Type> Mapowanie { get; } = new Dictionary<string, Type>(); // musi być poza klasą
        public static void PozbierajKlasy(Assembly assembly)
        {
            
            Type[] types = assembly.GetTypes();
            // Przeszukaj wszystkie klasy w poszukiwaniu atrybutu CysternaAttribute
            foreach (Type t in types)
            {
                var attr = (CysternaAttribute)Attribute.GetCustomAttribute(t, typeof(CysternaAttribute));
                if (attr != null)
                {
                    CysternaAttribute.Mapowanie[attr.Symbol] = t; // dodanie atrybutu do słownika mapowania
                }
            }
        }
        public static void Załaduj()
        {
            string filename = "rozszerzenia.cfg";

            string[] dllNames = File.ReadAllLines(filename);

            // Iterowanie przez nazwy DLL i wczytywanie assembly
            foreach (string dllName in dllNames)
            {
                Assembly dllassembly = Assembly.LoadFrom(dllName);
                PozbierajKlasy(dllassembly);
            }


        }
    }
}