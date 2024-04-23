using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cysterny;

namespace Cysterny
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Schemat());//zrobiæ gui z przyciskami, które bêdzie wczytywaæ na przycisk
        }
    }
    
}
