using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIbmMQ.CrossCutting.Extensions;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Infraestructure.Services;
using TesteIbmMQ.WinFormApp.Forms;

namespace TesteIbmMQ.WinFormApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
           
            ApplicationConfiguration.Initialize();

            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
    
}