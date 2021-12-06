using AlgorithmsAndDataStructures.LessonTask;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsAndDataStructures
{
    internal class Program
    {
        /// <summary>
        /// Множество заданий курса.
        /// </summary>
        private static List<ILessonTask> _lessonTasks = new List<ILessonTask>()
        {
            { new LessonTaskEmptyExample() },
            { new Lesson1TaskPrimeNumber() }
        };

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            IConfiguration configuration = BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .CreateLogger();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Log.Logger.Information("Приложение запущено");

            DoCommandProcessCycle();

            Console.WriteLine("Нажмите 'Enter' для завершения работы");
            Console.ReadLine();
            Log.Logger.Information("Работа приложения завершена");
        }

        /// <summary>
        /// Запускает цикл обработки команд.
        /// </summary>
        private static void DoCommandProcessCycle()
        {
            bool continueProcess = true;
            while (continueProcess)
            {
                Console.WriteLine("Перечень доступных заданий. Введите название задания для его запуска. Для выхода наберите 'exit' или '0' и нажмите [Enter]");
                foreach (ILessonTask lessonTask in _lessonTasks)
                {
                    Console.WriteLine($"\t{lessonTask.TaskName} - {lessonTask.TaskDescription}");
                }
                string input = Console.ReadLine();
                ILessonTask task = _lessonTasks.SingleOrDefault(s => s.TaskName == input);
                if (task != null)
                {
                    Console.WriteLine($"Запуск задания {task.TaskName}");
                    task.RunTest();
                    task.Run();
                }
                // Условие для выхода из цикла обработки команд.
                if (input == "0" || input == "exit")
                    continueProcess = false;
            }
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
