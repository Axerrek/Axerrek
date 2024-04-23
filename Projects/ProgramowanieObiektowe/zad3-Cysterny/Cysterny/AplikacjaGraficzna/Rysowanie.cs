using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cysterny
{
    internal class Rysowanie
    {
        public void RysujCysterny(Graphics graphics, Cysterna[] zbiorniki, PictureBox pictureBox)
        {
            using Graphics g = pictureBox.CreateGraphics();
            foreach (Cysterna zbiornik in zbiorniki)
            {
                if (zbiornik is Prostopadłościan prostopadłościan)
                {
                    // Rysuj Prostopadłościan
                    float pozycjaX = (float)(pictureBox.ClientSize.Width - prostopadłościan.szerokość) / 2;
                    float pozycjaY = (float)prostopadłościan.poziom;
                    RectangleF rectangle = new(pozycjaX, pozycjaY, (float)prostopadłościan.szerokość, (float)prostopadłościan.wysokość);
                    g.FillRectangle(Brushes.Blue, rectangle);
                    pictureBox.Invalidate();
                }
                if (zbiornik is Walec)
                {
                    
                }
                if (zbiornik is Kula)
                {
                    
                }
                if (zbiornik is Lejek)
                {
                    
                }
                if (zbiornik is Stożek)
                {
                    
                }
            }


        }
    }
}
