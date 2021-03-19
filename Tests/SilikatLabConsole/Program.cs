using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Researches;
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

            //using (var db = new SPLaboratoryDb())
            //{
            //    var types = new List<TypeResearch>();
            //    types.Add(new TypeResearch
            //    {
            //        Name = "Исследование прочности блока",
            //        TypeResult = TypeResearch.IsTypeResult.BlockQualityResearch,
            //    });
            //    db.TypeResearches.AddRange(types);
            //    db.SaveChanges();
            //}

            //using (var db = new SPLaboratoryDb())
            //{
            //    var tasks = new List<WorkTask>();
            //    var types = db.TypeResearches.ToArray();
            //    var objects = db.ResearchObjects.ToArray();
            //    tasks.Add(new WorkTask
            //    {
            //        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
            //        TaskDateTime = DateTime.Now.AddMinutes(60),
            //        Name = $"Задание исследования прочности",
            //        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch),
            //        ResearchObject = objects[rnd.Next(objects.Length)],
            //    });
            //    db.WorkTasks.AddRange(tasks);
            //    db.SaveChanges();
            //}

            //using (var db = new SPLaboratoryDb())
            //{
            //    var researches = new List<BlockQualityResearch>();
            //    var tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch).ToArray();
            //    var labolatorians = db.Laboratorians.ToArray();
            //    var workshifts = db.WorkShifts.ToArray();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        var task = tasks[rnd.Next(tasks.Length)];
            //        researches.Add(new BlockQualityResearch
            //        {
            //            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
            //            Name = $"Результат исследования прочности № {i}",
            //            Value = rnd.NextDouble() * 100.0,
            //            Text = $"Результат № {i} удовлетворителен.",
            //            Description = $"Описание результата исследования пр-ти № {i}",
            //            WorkTask = task,
            //            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
            //            WorkShift = workshifts[rnd.Next(workshifts.Length)],
            //            Format = "600*300*200",
            //            Trademark = "D500",
            //            Weight = (float)rnd.NextDouble() * 30.0f + 600.0f,
            //            SizeX = (float)rnd.NextDouble() + 10.0f,
            //            SizeY = (float)rnd.NextDouble() + 10.0f,
            //            SizeZ = (float)rnd.NextDouble() + 10.0f,
            //            BeforeDensity = (float)rnd.NextDouble() * 70.0f + 600.0f,
            //            Coefficient = 1.15f,
            //            BeforeWeight = (float)rnd.NextDouble() * 50.0f + 600.0f,
            //            AfterWeight = (float)rnd.NextDouble() * 50.0f + 500.0f,
            //            Humidity = (float)rnd.NextDouble() + 30.0f,
            //            Load = (float)rnd.NextDouble() + 30.0f,
            //            Strength = (float)rnd.NextDouble() + 3.0f,
            //            AfterDensity = (float)rnd.NextDouble() * 50.0f + 500.0f,
            //        });
            //    }
            //    db.BlockQualityResearches.AddRange(researches);
            //    db.SaveChanges();
            //}


            //using (var db = new SPLaboratoryDb())
            //{
            //    var tasks = db.WorkTasks
            //        .Include(t => t.TypeResearch)
            //        .Include(t => t.ResearchObject)
            //        .Include(t => t.ResearchResults);
            //    var str = tasks.ToQueryString();
            //    Console.WriteLine("Задания:");
            //    foreach (var t in tasks)
            //    {
            //        Console.WriteLine($"Дата: {t.DateTime:f} Вып-е: {t.TaskDateTime:f} Наз-е: {t.Name} Исс-е: {t.TypeResearch.Name} К-во: {t.ResearchResults.Count()}");
            //    }
            //    Console.WriteLine($"Запрос:\n{str}");
            //}


            using (var db = new SPLaboratoryDb())
            {
                var researches = db.Researches
                    .Include(r => r.Laboratorian)
                    .Include(r => r.WorkTask)
                    .Include(r => r.WorkShift)
                    .OrderBy(r => r.DateTime);
                var strQ = researches.ToQueryString();
                Console.WriteLine("Исследования:");
                foreach (var obj in researches)
                {
                    var label = obj switch
                    {
                        BlockQualityResearch r => $"Прочность: {r.DateTime}\t {r.Name} зн: {r.Value} т: {r.Text} л-т: {r.Laboratorian.SurName} {r.Laboratorian.Name} {r.Laboratorian.Patronymic} задание: {r.WorkTask.Name} смена: {r.WorkShift.Name}\n\tМарка: {r.Trademark} Формат: {r.Format} Масса: {r.Weight} Размеры: {r.SizeX} {r.SizeY} {r.SizeZ} Плотность сырая: {r.BeforeDensity} Коэфф.: {r.Coefficient} Масса сырая: {r.BeforeWeight} Масса сушеная: {r.AfterWeight} Влажность: {r.Humidity} Нагрузка: {r.Load}",
                        { } r => $"Простой: {r.DateTime}\t {r.Name} зн: {r.Value} т: {r.Text} л-т: {r.Laboratorian.SurName} {r.Laboratorian.Name} {r.Laboratorian.Patronymic} задание: {r.WorkTask.Name} смена: {r.WorkShift.Name}",
                        _ => "Неизвестный",
                    };
                    Console.WriteLine(label);
                }
                Console.WriteLine($"Количество исследований: {db.Researches.Count()}");
                Console.WriteLine($"Запрос:\n{strQ}");
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
