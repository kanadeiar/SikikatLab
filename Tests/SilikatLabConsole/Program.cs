using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models.Researches;


namespace SilikatLabConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleToRussian();
            //Random rnd = new Random();
            var options = new DbContextOptionsBuilder<SPLaboratoryEntities>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SPLaboratoryDev.DB").Options;

            using (var db = new SPLaboratoryEntities(options))
            {
                db.Database.Migrate();
            }

            using (var db = new SPLaboratoryEntities(options)) db.Database.Migrate();

            using (var db = new SPLaboratoryEntities(options))
            {
                //SPLaboratoryEntities.ClearData(db);
                //SPLaboratoryEntities.AddTestData(db);
            }

            using (var db = new SPLaboratoryEntities(options))
            {
                var tasks = db.WorkTasks
                    .Include(t => t.TypeResearch)
                    .Include(t => t.ResearchObject)
                    .Include(t => t.ResearchResults);
                Console.WriteLine("Задания:");
                foreach (var t in tasks)
                {
                    Console.WriteLine($"Дата: {t.DateTime:f} Вып-е: {t.TaskDateTime:f} Наз-е: {t.Name} Исс-е: {t.TypeResearch.Name} К-во: {t.ResearchResults.Count()}");
                }
            }



            using (var db = new SPLaboratoryEntities(options))
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
                        BlockQualityResearch r => $"{r.DateTime}\t {r.Name}, зн: {r.Value} т: {r.Text} - {((r.Normal) ? "Отлично" : "Плохо")} л-т: {r.Laboratorian.SurName} задание: {r.WorkTask?.Name ?? "отсутствует"} {((r.WorkTask?.Completed ?? false) ? "Выполнено" : "Не выполнено")} смена: {r.WorkShift.Name} прочность: Марка: {r.Trademark} Формат: {r.Format} Масса: {r.Weight} Размеры: {r.SizeX} {r.SizeY} {r.SizeZ} Плотность: {r.BeforeDensity} Коэффициент: {r.Coefficient} Масса сырая: {r.BeforeWeight} Масса сушеная: {r.AfterWeight} Влажность: {r.Humidity} Нагрузка: {r.Load} Прочность: {r.Strength}",
                        SludgeResearch r => $"{r.DateTime}\t {r.Name}, зн: {r.Value} т: {r.Text} - {((r.Normal) ? "Отлично" : "Плохо")} л-т: {r.Laboratorian.SurName} задание: {r.WorkTask?.Name ?? "отсутствует"} {((r.WorkTask?.Completed ?? false) ? "Выполнено" : "Не выполнено")} смена: {r.WorkShift.Name} шлам: плотность: {r.Density} сито: {r.Sieve0_8}",
                        CementResearch r => $"{r.DateTime}\t {r.Name}, зн: {r.Value} т: {r.Text} - {((r.Normal) ? "Отлично" : "Плохо")} л-т: {r.Laboratorian.SurName} задание: {r.WorkTask?.Name ?? "отсутствует"} {((r.WorkTask?.Completed ?? false) ? "Выполнено" : "Не выполнено")} смена: {r.WorkShift.Name} цемент: Паспортное в/ц: {r.PassportVc} фактическое в/ц: {r.ActualVc} откуда: {r.FromName}",
                        HammerBinderResearch r => $"{r.DateTime}\t {r.Name}, зн: {r.Value} т: {r.Text} - {((r.Normal) ? "Отлично" : "Плохо")} л-т: {r.Laboratorian.SurName} задание: {r.WorkTask?.Name ?? "отсутствует"} {((r.WorkTask?.Completed ?? false) ? "Выполнено" : "Не выполнено")} смена: {r.WorkShift.Name} молото-вяжущее: поверхность: {r.Surface} активность: {r.Activity}",
                        { } r => $"{r.DateTime}\t {r.Name}, зн: {r.Value} т: {r.Text} - {((r.Normal) ? "Отлично" : "Плохо")} л-т: {r.Laboratorian.SurName} задание: {r.WorkTask?.Name ?? "отсутствует"} {((r.WorkTask?.Completed ?? false) ? "Выполнено" : "Не выполнено")} смена: {r.WorkShift.Name}",
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
