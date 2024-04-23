using System;

//
namespace Cysterny
{

        [Cysterna("p")]
        public class Prostopadłościan : Cysterna
    {
            public double szerokość;
            public double długość;

            public Prostopadłościan(double poziom, string[] wymiary)
            : base(poziom, double.Parse(wymiary[1]))
            {
                this.szerokość = double.Parse(wymiary[0]);
                this.długość = double.Parse(wymiary[2]);
            }

            public Prostopadłościan(double poziom, double wysokość, double szerokość, double długość)
                : base(poziom, wysokość) 
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
            public double promień;

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
}
