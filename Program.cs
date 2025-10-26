using System;
using System.Windows.Forms;
using project.Forms;

namespace project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormBicycles());
        }
    }
}
