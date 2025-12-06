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
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK) { Application.Run(new BicyclesForm());}
            }
        }
    }
}

