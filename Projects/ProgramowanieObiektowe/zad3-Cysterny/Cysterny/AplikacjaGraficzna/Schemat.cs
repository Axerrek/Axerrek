using Cysterny;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Cysterny
{
    public partial class Schemat : Form
    {
        Dictionary<Type, Type> SłownikWizualizacji; // słownik do wizualizacji typów kula itd.

        List<Zadanie> Zadania;
        List<double?> Rozwiązania;
        public Schemat()
        {
            InitializeComponent();
        }
        public void WczytajZadania()
        {
            Zadanie.Załaduj();
            int nrZadania = 0;
            int ilośćZadań;

            InitializeComponent();
            Zadania = new List<Zadanie>();

            using StreamReader sr = new("plik.txt");
            ilośćZadań = int.Parse(sr.ReadLine().ToString());
            while (!sr.EndOfStream) // sprawdzenie końca pliku
            {
                nrZadania++;
                Zadanie zadanie = new();

                zadanie.Wczytaj(sr);
                zadanie.WczytajWodę(sr);
                
                Zadania.Add(zadanie);
            }
        }


        public static void PozbierajKlasy(Assembly assembly)
        {

            Type[] types = assembly.GetTypes();
            // Przeszukaj wszystkie klasy w poszukiwaniu atrybutu CysternaAttribute
            foreach (Type t in types)
            {
                var attr = (CysternaAttribute)Attribute.GetCustomAttribute(t, typeof(CysternaAttribute)); // popraw pod wizualizacje
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

        public void RozwiążZadanie(int indeks)
        {
            Rozwiązania[indeks] = Zadania[indeks].Rozwiąż();
            indeks++;
        }

        private void Schemat_Load(object sender, EventArgs e)
        {

        }

        private void Wczytaj_Click(object sender, EventArgs e)
        {
            
            WczytajZadania();
            Wczytaj.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
