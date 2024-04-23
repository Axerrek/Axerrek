using System;


namespace Cysterny
{

    public abstract class Cysterna
    {
        public double poziom;
        public double wysokość;

        public Cysterna(double poziom, double wysokość)
        {
            this.poziom = poziom;
            this.wysokość = wysokość;
        }

        public abstract double ObliczObjętośćDlaPoziomu(double poziomWody);

        public abstract double Pojemność();

    }
    /*
    [Cysterna("p")]
    public class Prostopadłościan : Cysterna
    {
        protected double szerokość;
        protected double długość;


        public Prostopadłościan(double poziom, string[] wymiary)
            : base(poziom, double.Parse(wymiary[1]))
        {
            this.szerokość = double.Parse(wymiary[0]);
            this.długość = double.Parse(wymiary[2]);
        }

        public Prostopadłościan(double poziom, double wysokość, double szerokość, double długość)
            : base(poziom, wysokość) // wyrzucić z klas objętość
        {
            this.szerokość = szerokość;
            this.długość = długość;
        }

        public override double Pojemność()
        {
            return wysokość * długość * szerokość;
        }

        public override double ObliczObjętośćDlaPoziomu(double poziomWody)
        {
            if (poziomWody >= poziom + wysokość)
            {
                return Pojemność();
            }
            else if (poziomWody <= poziom)
            {
                return 0;
            }
            else
            {
                double wysokoscWody = poziomWody - poziom;
                double objetoscWody = wysokoscWody * szerokość * długość;
                return objetoscWody;
            }
        }

    }

    [Cysterna("w")]
    public class Walec : Cysterna
    {
        protected double promień;

        public Walec(double poziom, string[] wymiary)
            : base(poziom, double.Parse(wymiary[1]))
        {
            this.promień = double.Parse(wymiary[0]);
        }

        public Walec(double poziom, double wysokość, double promień)
            : base(poziom, wysokość)
        {
            this.promień = promień;
        }

        public override double Pojemność()
        {
            return Math.PI * promień * promień * wysokość;
        }

        public override double ObliczObjętośćDlaPoziomu(double poziomWody)
        {
            if (poziomWody >= poziom + wysokość)
            {
                return Pojemność();
            }
            else if (poziomWody <= poziom)
            {
                return 0;
            }
            else
            {
                double wysokoscWody = poziomWody - poziom;
                double objetoscWody = wysokoscWody * promień * promień * Math.PI;
                return objetoscWody;
            }
        }
    }

    [Cysterna("s")]
    public class Stożek : Cysterna // A
    {
        protected double promień;

        public Stożek(double poziom, string[] wymiary)
            : base(poziom, double.Parse(wymiary[1]))
        {
            this.promień = double.Parse(wymiary[0]);
        }

        public Stożek(double poziom, double wysokość, double promień)
            : base(poziom, wysokość)
        {
            this.promień = promień;
        }

        public override double Pojemność()
        {
            return Math.PI * promień * promień * (wysokość / 3);
        }

        public override double ObliczObjętośćDlaPoziomu(double poziomWody)
        {
            if (poziomWody >= poziom + wysokość)
            {
                return Pojemność();
            }
            else if (poziomWody <= poziom)
            {
                return 0;
            }
            else
            {
                double wysokoscPustegoStożka = wysokość - (poziomWody - poziom);
                double promiennaWysokosciWody = promień * wysokoscPustegoStożka * wysokość;
                double objetoscWody = Math.PI * promiennaWysokosciWody * promiennaWysokosciWody * (wysokoscPustegoStożka / 3);
                return objetoscWody;
            }
        }
    }

    [Cysterna("so")]
    public class Lejek : Cysterna // V
    {
        protected double promień;

        public Lejek(double poziom, string[] wymiary)
            : base(poziom, double.Parse(wymiary[1]))
        {
            this.promień = double.Parse(wymiary[0]);
        }

        public Lejek(double poziom, double wysokość, double promień)
            : base(poziom, wysokość)
        {
            this.promień = promień;
        }

        public override double Pojemność()
        {
            return Math.PI * promień * promień * (wysokość / 3 + wysokość - poziom);
        }

        public override double ObliczObjętośćDlaPoziomu(double poziomWody)
        {
            if (poziomWody >= poziom + wysokość)
            {
                return Pojemność();
            }
            else if (poziomWody <= poziom)
            {
                return 0;
            }
            else
            {

                double wysokoscWody = poziomWody - poziom;
                double promiennaWysokosciWody = promień * wysokoscWody * wysokość;
                double objetoscWody = Math.PI * promiennaWysokosciWody * (wysokość / 3 + wysokoscWody - poziom);
                return objetoscWody;
            }
        }
    }

    [Cysterna("k")]
    public class Kula : Cysterna
    {
        protected double promień;


        public Kula(double poziom, string[] wymiary) : base(poziom,
            double.Parse(wymiary[0]) * 2)
        {
            this.poziom = poziom;
            this.promień = double.Parse(wymiary[0]);
        }

        public Kula(double poziom, double wysokość, double promień) : base(poziom, promień * 2)
        {
            this.promień = promień;
        }

        public override double Pojemność()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(promień, 3);
        }

        public override double ObliczObjętośćDlaPoziomu(double poziomWody)
        {
            if (poziomWody >= poziom + wysokość)
            {
                return Pojemność();
            }
            else if (poziomWody <= poziom)
            {
                return 0;
            }
            else
            {

                double pustaWysokość = poziom + wysokość - poziomWody;
                return (Math.PI * pustaWysokość * pustaWysokość / 3) * (3 * promień - pustaWysokość);
            }
        }
    }

    */

}