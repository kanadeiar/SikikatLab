using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Models;
using SilikatLabConsole.Data;

namespace SilikatLabConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleToRussian();
            Random rnd = new Random();

            using (var db = new SPLaboratoryDb()) db.Database.Migrate();

            using (var db = new SPLaboratoryDb())
            {
                var tasks = db.WorkTasks
                    .Include(t => t.TypeResearch)
                    .Include(t => t.ResearchObject)
                    .Include(t => t.ResearchResults);
                var str = tasks.ToQueryString();
                Console.WriteLine("Задания:");
                foreach (var t in tasks)
                {
                    Console.WriteLine($"Дата: {t.DateTime:f} Вып-е: {t.TaskDateTime:f} Наз-е: {t.Name} Исс-е: {t.TypeResearch.Name} К-во: {t.ResearchResults.Count()}");
                }
                Console.WriteLine($"Запрос:\n{str}");
            }

            using (var db = new SPLaboratoryDb())
            {
                var researches = db.Researches
                    .Include(r => r.Laboratorian)
                    .Include(r => r.WorkTask)
                    .Include(r => r.WorkShift);
                var str = researches.ToQueryString();
                Console.WriteLine("Исследования:");
                foreach (var r in researches)
                {
                    Console.WriteLine($"{r.DateTime} {r.Name} зн: {r.Value} т: {r.Text} л-т: {r.Laboratorian.SurName} {r.Laboratorian.Name} {r.Laboratorian.Patronymic} задание: {r.WorkTask.Name} смена: {r.WorkShift.Name}");
                }
                Console.WriteLine($"Количество исследований: {db.Researches.Count()}");
                Console.WriteLine($"Запрос:\n{str}");
            }
            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
        }

        private static void ConsoleToRussian()
        {
            [DllImport("kernel32.dll")] static extern bool SetConsoleCP(uint pagenum);
            [DllImport("kernel32.dll")] static extern bool SetConsoleOutputCP(uint pagenum);
            SetConsoleCP(65001);        //установка кодовой страницы utf-8 (Unicode) для вводного потока
            SetConsoleOutputCP(65001);  //установка кодовой страницы utf-8 (Unicode) для выводного потока
            Console.WriteLine("*** База данных лаборатории ***");
        }
    }
}
