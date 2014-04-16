using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Repositories;

namespace CloudClassForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UsersRepository u = new UsersRepository();
            u.AddUser(null);
            var d = u.GetUsers(null);
            MessageBox.Show(d.Count().ToString());
        }
    }
}
