/*
 * ITSE 1430
 * Lab 4
 * Program
 * Spring 2020
 * Zachary Behn
 * 
 * This file is the entry point for the application
 */

using System;
using System.Windows.Forms;

namespace Nile.Windows
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
            Application.Run(new MainForm());
        }
    }
}
