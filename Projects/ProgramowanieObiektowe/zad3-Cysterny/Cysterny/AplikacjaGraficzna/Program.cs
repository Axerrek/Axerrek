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
            Application.Run(new Schemat());//zrobi� gui z przyciskami, kt�re b�dzie wczytywa� na przycisk
        }
    }
    
}
