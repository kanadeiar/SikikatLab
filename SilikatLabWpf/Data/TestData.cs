using System;
using System.Collections.Generic;
using System.Linq;
using SilikatLabWpf.Models;

namespace SilikatLabWpf.Data
{
    public static class TestData
    {
        public static string Title { get; } = "Лабораторная программа";
        private static Random rand = new Random();
        public static List<WorkShift> WorkShifts { get; } = Enumerable.Range(1, 4)
            .Select(i => new WorkShift
            {
                Name = $"Смена №{i}"
            }).ToList();
        public static List<ResearchObject> ResearchObjects { get; } = Enumerable.Range(1, 10).Select(i =>
            new ResearchObject
            {
                Name = $"Массив № {i}",
            }).ToList();
        public static List<Research> Researches { get; } = new()
        {
            new Research { Name = "Плотность" },
            new Research { Name = "Температура" },
            new Research { Name = "Прочность" },
            new Research { Name = "Давление" },
            new Research { Name = "Влажность" },
        };
        public static List<Laboratorian> Laboratorians { get; } = new()
        {
            new Laboratorian { SurName = "Иванов", Name = "Иван", Patronymic = "Иванович" },
            new Laboratorian { SurName = "Петров", Name = "Петр", Patronymic = "Петрович" },
            new Laboratorian { SurName = "Сидоров", Name = "Сидор", Patronymic = "Сидорович" },
        };
        public static List<WorkTask> WorkTasks { get; } = Enumerable.Range(1, 10).Select(i => new WorkTask
        {
            DateTime = new DateTime(2021, 1, 1, rand.Next(23), 0, 0),
            Name = $"Однокраное задание № {i}",
            Research = Researches[rand.Next(Researches.Count - 1)],
            ResearchObject = ResearchObjects[rand.Next(ResearchObjects.Count - 1)],
        }).ToList();

        public static List<WorkResult> WorkResults
        {
            get
            {
                var list = Enumerable.Range(1, 10).Select(i => new WorkResult
                {
                    DateTime = WorkTasks[i - 1].DateTime,
                    WorkTask = WorkTasks[i - 1],
                    WorkShift = WorkShifts[rand.Next(WorkShifts.Count - 1)],
                    Laboratorian = Laboratorians[rand.Next(Laboratorians.Count - 1)],
                    Name = $"Результаты исследования № {i}",
                    Value = rand.NextDouble() * 100.0,
                    Result = (rand.NextDouble() * 100.0).ToString("F") + " едениц",
                }).ToList();
                list[1] = new QualityBlockWorkResult
                {
                    DateTime = WorkTasks[1].DateTime,
                    WorkTask = WorkTasks[1],
                    WorkShift = WorkShifts[rand.Next(WorkShifts.Count - 1)],
                    Laboratorian = Laboratorians[rand.Next(Laboratorians.Count - 1)],
                    Name = $"Результаты исследования прочности № 1",
                    Value = rand.NextDouble() + 2.0,
                    Result = "Норма",
                    Format = "D500 600*300*200",
                    NumAutoclave = 2,
                    Weight = 663.44,
                    SizeX = 10.0,
                    SizeY = 9.9,
                    SizeZ = 9.8,
                    Density = 657.1,
                    Coefficient = 1.15,
                    BeforeWeight = 640.94,
                    AfterWeight = 506.6,
                    Humidity = 29.4,
                    Load = 28.25,
                    Strength = 32.25,
                    AfterDensity = 519.1,
                };
                return list;
            }
        } 
    }
}
