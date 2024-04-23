using System;


namespace Cysterny

{
        [Cysterna("s")]
        public class Stożek : Cysterna // A
    {
            public double promień;

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
            public double promień;

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
            public double promień;

            public Kula(double poziom, string[] wymiary) : base(poziom,
            double.Parse(wymiary[0]) * 2)
            {
                this.poziom = poziom;
                this.promień = double.Parse(wymiary[0]);
            }

            public Kula(object[] constructorArgs) : base((double)constructorArgs[0], (double)constructorArgs[2] * 2)
            {
                this.promień = (double)constructorArgs[1];
                this.wysokość = (double)constructorArgs[2];
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
}
