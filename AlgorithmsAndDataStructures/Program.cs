using AlgorithmsAndDataStructures.InputOutput;
using AlgorithmsAndDataStructures.LessonTask;
using AlgorithmsAndDataStructures.PetShop;
using AlgorithmsAndDataStructures.Tree;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

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
            { new Lesson1TaskPrimeNumber() },
            { new Lesson8Sorting() }
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

            //var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AlgorithmsAndDataStructures.dll"));
            //var myType = myAssembly.GetType("AlgorithmsAndDataStructures.LessonTask.Lesson1TaskPrimeNumber");
            //var myInstance = Activator.CreateInstance(myType);
            //ILessonTask dynamicLessonTask = (ILessonTask)myInstance;
            //_lessonTasks.Add(dynamicLessonTask);
            //var methodInfo = myType.GetMethod("RunTest");
            //methodInfo.Invoke(myInstance, null);

            Lesson8Sorting lesson8Sorting = new Lesson8Sorting();
            lesson8Sorting.RunTest();

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
                    task.RunInteractive();
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

    public class Benchmark
    {
        long maxValueToCheck = 5000;

        [Benchmark]
        public void MeasureVar1()
        {
            Stopwatch sw = new Stopwatch();
            int simpleNumbersCount;
            sw.Start();
            simpleNumbersCount = 0;
            for (long i = 2; i <= maxValueToCheck; i++)
            {
                if (Lesson1TaskPrimeNumber.IsNumberPrime(i))
                {
                    //Console.Write($"{i} ");
                    simpleNumbersCount++;
                }
            }
            sw.Stop();
            Console.WriteLine($"Var 1. Time: {sw.Elapsed}. Primes: {simpleNumbersCount}/{maxValueToCheck}");
        }

        [Benchmark]
        public void MeasureVar2()
        {
            Stopwatch sw = new Stopwatch();
            int simpleNumbersCount;
            sw.Reset();
            sw.Start();
            simpleNumbersCount = 0;
            for (long i = 2; i <= maxValueToCheck; i++)
            {
                if (Lesson1TaskPrimeNumber.IsNumberPrimeV2(i))
                {
                    //Console.Write($"{i} ");
                    simpleNumbersCount++;
                }
            }
            sw.Stop();
            Console.WriteLine($"Var 2. Time: {sw.Elapsed}. Primes: {simpleNumbersCount}/{maxValueToCheck}");
        }

        //[Benchmark]
        //public void MeasureVar3()
        //{
        //    Stopwatch sw = new Stopwatch();
        //    int simpleNumbersCount;
        //    sw.Reset();
        //    sw.Start();
        //    simpleNumbersCount = 0;
        //    for (long i = 2; i <= maxValueToCheck; i++)
        //    {
        //        if (SimpleNumberChecker.IsNumberSimpleByAmmoraite(i))
        //        {
        //            //Console.Write($"{i} ");
        //            simpleNumbersCount++;
        //        }
        //    }
        //    sw.Stop();
        //    Console.WriteLine($"Var 3. Time: {sw.Elapsed}. Primes: {simpleNumbersCount}/{maxValueToCheck}");
        //}
    }
}
