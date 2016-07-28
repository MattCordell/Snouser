using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snouser
{
    public class globalArguments
    {
        public static string client_id { get; set; }
        public static string client_secret { get; set; }
    }

    static class Program
    {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
        static void Main(string[] args)
        {
            globalArguments.client_id = args[0];
            globalArguments.client_secret = args[1];            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            




        }
    }
}
