using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Autorization()); //вернуть форму авторизации
           //Application.Run(new General_Form()); //вернуть форму авторизации
            //Application.Run(new Main_Form()); //вернуть форму авторизации
        }
    }
}
