using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GosFormsApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// А ХУЛИ ВЫ ВООБЩЕ СЮДА ЗАШЛИ? СТАНДАРТНАЯ ХУЙНЯ КОТОРАЯ АВТОМАТОМ ДЕЛАЕТСЯ
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
