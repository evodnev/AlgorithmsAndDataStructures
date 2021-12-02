using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            IConfiguration configuration = BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .CreateLogger();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Log.Logger.Verbose("Приложение запущено");
            Log.Logger.Debug("Приложение запущено");
            Log.Logger.Information("Приложение запущено");
            Log.Logger.Warning("Приложение запущено");
            Log.Logger.Error("Приложение запущено");

            // Выбросить необработанное исключение - пример, как бывает.
            //throw new NotSupportedException("необработанное исключение");

            Console.WriteLine("Нажмите 'Enter' для завершения работы");
            Console.ReadLine();
            Log.Logger.Information("Работа приложения завершена");
        }

        /// <summary>
        /// Записывает необработанное исключение.
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception unhandledException = (Exception)e.ExceptionObject;
            Log.Error(unhandledException, "Необработанное исключение");
        }

        /// <summary>
        /// Подключает файл конфигурации из каталога с приложением и возвращает конфигурацию.
        /// </summary>
        /// 
        static IConfiguration BuildConfig(IConfigurationBuilder builder)
        {
            return
                builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
