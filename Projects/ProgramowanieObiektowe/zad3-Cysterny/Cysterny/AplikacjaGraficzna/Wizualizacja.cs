using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaGraficzna
{
    public class WizualizacjaAttribute : Attribute
    {
        public string Nazwa { get; private set; }

        public WizualizacjaAttribute(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
    public abstract class Wizualizacja
    {
        public abstract void Print(Graphics g);
    }
    [Wizualizacja("Kulawiz")]
    public class Kulawiz : Wizualizacja
    {
        public override void Print(Graphics g)
        {

        }
    }
    [Wizualizacja("ProstopadłościanWiz")]
    public class ProstopadłościanWiz : Wizualizacja
    {
        public override void Print(Graphics g)
        {

        }
    }
    [Wizualizacja("Walecwiz")]
    public class Walecwiz : Wizualizacja
    {
        public override void Print(Graphics g)
        {

        }
    }

    [Wizualizacja("StożekWiz")]
    public class StożekWiz : Wizualizacja
    {
        public override void Print(Graphics g)
        {

        }
    }
}
