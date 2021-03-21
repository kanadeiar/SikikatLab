using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Researches;

namespace SilikatLabConsole.Data
{
    /// <summary> Лабораторная база данных Силикат Плюс </summary>
    class SPLaboratoryDb : DbContext
    {
        /// <summary> Авторизация пользователей </summary>
        public DbSet<UserLogin> UserLogins { get; set; }
        /// <summary> Лаборанты </summary>
        public DbSet<Laboratorian> Laboratorians { get; set; }
        /// <summary> Объекты исследования </summary>
        public DbSet<ResearchObject> ResearchObjects { get; set; }
        /// <summary> Вид исследования </summary>
        public DbSet<TypeResearch> TypeResearches { get; set; }
        /// <summary> Рабочие смены </summary>
        public DbSet<WorkShift> WorkShifts { get; set; }
        /// <summary> Задания </summary>
        public DbSet<WorkTask> WorkTasks { get; set; }
        /// <summary> Результаты исследования </summary>
        public DbSet<Research> Researches { get; set; }
        /// <summary> Результаты исследования качества блоков </summary>
        public DbSet<BlockQualityResearch> BlockQualityResearches { get; set; }
        /// <summary> Результаты исследования шлама </summary>
        public DbSet<SludgeResearch> SludgeResearches { get; set; }
        /// <summary> Результаты исследования цемента </summary>
        public DbSet<CementResearch> CementResearches { get; set; }
        /// <summary> Результаты исследования молото-вяжущего </summary>
        public DbSet<HammerBinderResearch> HammerBinderResearches { get; set; }

        public SPLaboratoryDb() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SPLaboratory.DB");
        }

        #region Тестовые данные

        public static void RemoveDataFromDb(SPLaboratoryDb db)
        {
            if (db.HammerBinderResearches.Any())
            {
                db.HammerBinderResearches.RemoveRange(db.HammerBinderResearches);
                db.SaveChanges();
            }
            if (db.CementResearches.Any())
            {
                db.CementResearches.RemoveRange(db.CementResearches);
                db.SaveChanges();
            }
            if (db.SludgeResearches.Any())
            {
                db.SludgeResearches.RemoveRange(db.SludgeResearches);
                db.SaveChanges();
            }
            if (db.BlockQualityResearches.Any())
            {
                db.BlockQualityResearches.RemoveRange(db.BlockQualityResearches);
                db.SaveChanges();
            }
            if (db.Researches.Any())
            {
                db.Researches.RemoveRange(db.Researches);
                db.SaveChanges();
            }
            if (db.WorkTasks.Any())
            {
                db.WorkTasks.RemoveRange(db.WorkTasks);
                db.SaveChanges();
            }
            if (db.ResearchObjects.Any())
            {
                db.ResearchObjects.RemoveRange(db.ResearchObjects);
                db.SaveChanges();
            }
            if (db.TypeResearches.Any())
            {
                db.TypeResearches.RemoveRange(db.TypeResearches);
                db.SaveChanges();
            }
            if (db.WorkShifts.Any())
            {
                db.WorkShifts.RemoveRange(db.WorkShifts);
                db.SaveChanges();
            }
            if (db.UserLogins.Any())
            {
                db.UserLogins.RemoveRange(db.UserLogins);
                db.SaveChanges();
            }
            if (db.Laboratorians.Any())
            {
                db.Laboratorians.RemoveRange(db.Laboratorians);
                db.SaveChanges();
            }
        }
        public static void AddTestDataToDB(SPLaboratoryDb db, int power = 10)
        {
            Random rnd = new Random();
            //await db.Database.EnsureDeletedAsync();
            //if (await db.Database.EnsureCreatedAsync())
            //    Console.WriteLine("База данных создана заново");
            //db.Database.Migrate();

            if (!db.Laboratorians.Any())
            {
                var labors = Enumerable.Range(1, power / 3)
                    .Select(i => new Laboratorian
                    {
                        SurName = $"Иванова{i}",
                        Name = $"Галина{i}",
                        Patronymic = $"Ивановна{i}",
                    });
                db.Laboratorians.AddRange(labors);
                db.SaveChanges();
                if (!db.UserLogins.Any())
                {
                    var logins = new List<UserLogin>()
                    {
                        new()
                        {
                            Login = "operator",
                            Password = string.Empty,
                            Access = UserLogin.AccessLevel.None,
                        },
                        new()
                        {
                            Login = "user",
                            Password = "1",
                            Access = UserLogin.AccessLevel.Edit,
                            Laboratorian = db.Laboratorians.Find(1),
                        },
                        new ()
                        {
                            Login = "tech",
                            Password = "1",
                            Access = UserLogin.AccessLevel.Control,
                        },
                    };
                    db.UserLogins.AddRange(logins);
                    db.SaveChanges();
                }
                if (!db.WorkShifts.Any())
                {
                    var shifts = Enumerable.Range(1, power / 3)
                        .Select(i => new WorkShift
                        {
                            Name = $"Смена № {i}"
                        });
                    db.WorkShifts.AddRange(shifts);
                    db.SaveChanges();
                }
                if (!db.TypeResearches.Any())
                {
                    var types = Enumerable.Range(1, power / 3)
                        .Select(i => new TypeResearch
                        {
                            Name = $"Вид исследования № {i}",
                            TypeResult = TypeResearch.IsTypeResult.Simple,
                        }).ToList();
                    types.Add(new TypeResearch
                    {
                        Name = "Исследование прочности блока",
                        TypeResult = TypeResearch.IsTypeResult.BlockQualityResearch,
                    });
                    types.Add(new TypeResearch
                    {
                        Name = "Исследование шлама",
                        TypeResult = TypeResearch.IsTypeResult.SludgeResearch,
                    });
                    types.Add(new TypeResearch
                    {
                        Name = "Исследование цемента",
                        TypeResult = TypeResearch.IsTypeResult.CementReseatch,
                    });
                    types.Add(new TypeResearch
                    {
                        Name = "Исследование молото-вяжущего",
                        TypeResult = TypeResearch.IsTypeResult.HammerBinderResearch,
                    });
                    db.TypeResearches.AddRange(types);
                    db.SaveChanges();
                }
                if (!db.ResearchObjects.Any())
                {
                    var objects = Enumerable.Range(1, power)
                        .Select(i => new ResearchObject
                        {
                            Name = $"Массив № {i}",
                        });
                    db.ResearchObjects.AddRange(objects);
                    db.SaveChanges();
                }

                if (!db.WorkTasks.Any())
                {
                    var types = db.TypeResearches.ToArray();
                    var objects = db.ResearchObjects.ToArray();
                    var tasks = Enumerable.Range(1, power)
                        .Select(i => new WorkTask
                        {
                            DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                            TaskDateTime = DateTime.Now.AddHours(rnd.Next(-12, 12)),
                            Name = $"Задание № {i}",
                            Completed = true,
                            TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                            ResearchObject = objects[rnd.Next(objects.Length)],
                        }).ToList();
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(10),
                        Name = $"Периодическое задание каждые 10 минут",
                        AgainInMinutes = 10,
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(60),
                        Name = $"Периодическое задание каждый час",
                        AgainInMinutes = 60,
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(60),
                        Name = $"Задание исследования прочности",
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(80),
                        Name = $"Задание исследования шлама",
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.SludgeResearch),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(120),
                        Name = $"Задание исследования цемента",
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.CementReseatch),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(160),
                        Name = $"Задание исследования молото-вяжущего",
                        TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.HammerBinderResearch),
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    db.WorkTasks.AddRange(tasks);
                    db.SaveChanges();
                }


                if (!db.Researches.Any())
                {
                    var researches = new List<Research>();
                    var tasks = db.WorkTasks.ToArray();
                    var labolatorians = db.Laboratorians.ToArray();
                    var workshifts = db.WorkShifts.ToArray();
                    for (int i = 0; i < power * 10; i++)
                    {
                        var task = tasks[rnd.Next(tasks.Length)];
                        researches.Add(new Research
                        {
                            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                            Name = $"Результат исследования № {i}",
                            Value = rnd.NextDouble() * 100.0,
                            Text = $"Результат № {i} удовлетворителен.",
                            Description = $"Описание результата исследования № {i}",
                            WorkTask = task,
                            TypeResearch = task.TypeResearch,
                            ResearchObject = task.ResearchObject,
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                        });
                    }
                    db.Researches.AddRange(researches);
                    db.SaveChanges();
                }

                if (!db.BlockQualityResearches.Any())
                {
                    var researches = new List<BlockQualityResearch>();
                    var tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch).ToArray();
                    var labolatorians = db.Laboratorians.ToArray();
                    var workshifts = db.WorkShifts.ToArray();
                    for (int i = 0; i < power; i++)
                    {
                        var task = tasks[rnd.Next(tasks.Length)];
                        researches.Add(new BlockQualityResearch
                        {
                            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                            Name = $"Результат исследования прочности № {i}",
                            Value = rnd.NextDouble() * 100.0,
                            Text = $"Результат № {i} удовлетворителен.",
                            Description = $"Описание результата исследования пр-ти № {i}",
                            WorkTask = task,
                            TypeResearch = task.TypeResearch,
                            ResearchObject = task.ResearchObject,
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                            Format = "600*300*200",
                            Trademark = "D500",
                            Weight = (float)rnd.NextDouble() * 30.0f + 600.0f,
                            SizeX = (float)rnd.NextDouble() + 10.0f,
                            SizeY = (float)rnd.NextDouble() + 10.0f,
                            SizeZ = (float)rnd.NextDouble() + 10.0f,
                            BeforeDensity = (float)rnd.NextDouble() * 70.0f + 600.0f,
                            Coefficient = 1.15f,
                            BeforeWeight = (float)rnd.NextDouble() * 50.0f + 600.0f,
                            AfterWeight = (float)rnd.NextDouble() * 50.0f + 500.0f,
                            Humidity = (float)rnd.NextDouble() + 30.0f,
                            Load = (float)rnd.NextDouble() + 30.0f,
                            Strength = (float)rnd.NextDouble() + 3.0f,
                            AfterDensity = (float)rnd.NextDouble() * 50.0f + 500.0f,
                        });
                    }
                    db.BlockQualityResearches.AddRange(researches);
                    db.SaveChanges();
                }

                if (!db.SludgeResearches.Any())
                {
                    var researches = new List<SludgeResearch>();
                    var tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.SludgeResearch).ToArray();
                    var labolatorians = db.Laboratorians.ToArray();
                    var workshifts = db.WorkShifts.ToArray();
                    for (int i = 0; i < power; i++)
                    {
                        var task = tasks[rnd.Next(tasks.Length)];
                        researches.Add(new SludgeResearch()
                        {
                            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                            Name = $"Результат исследования шлама № {i}",
                            Value = rnd.NextDouble() * 100.0,
                            Text = $"Результат № {i} удовлетворителен.",
                            Description = $"Описание результата исследования шлама № {i}",
                            //WorkTask = task,
                            TypeResearch = task.TypeResearch,
                            ResearchObject = task.ResearchObject,
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                            Density = rnd.Next(1500, 1600),
                            Surface = rnd.Next(2500, 3000),
                            Sieve0_8 = (float)rnd.NextDouble() + 30.0f,
                            Sieve0_09 = (float)rnd.NextDouble() + 30.0f,
                            Sieve0_045 = (float)rnd.NextDouble() + 30.0f,
                            Gypsum = (float)rnd.NextDouble() + 300.0f,
                            Humidity = (float)rnd.NextDouble() + 30.0f,
                        });
                    }
                    db.SludgeResearches.AddRange(researches);
                    db.SaveChanges();
                }

                if (!db.CementResearches.Any())
                {
                    var researches = new List<CementResearch>();
                    var tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.CementReseatch).ToArray();
                    var labolatorians = db.Laboratorians.ToArray();
                    var workshifts = db.WorkShifts.ToArray();
                    for (int i = 0; i < power; i++)
                    {
                        var task = tasks[rnd.Next(tasks.Length)];
                        researches.Add(new CementResearch()
                        {
                            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                            Name = $"Результат исследования цемента № {i}",
                            Value = rnd.NextDouble() * 100.0,
                            Text = $"Результат № {i} удовлетворителен.",
                            Description = $"Описание результата исследования цемента № {i}",
                            WorkTask = task,
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                            Party = rnd.Next(1000,9000).ToString(),
                            PassportVc = (float)rnd.NextDouble() + 30.0f,
                            PassportNsh = (float)rnd.NextDouble() + 180.0f,
                            PassportKsh = (float)rnd.NextDouble() + 250.0f,
                            ActualVc = (float)rnd.NextDouble() + 30.0f,
                            ActualNsh = (float)rnd.NextDouble() + 180.0f,
                            ActualKsh = (float)rnd.NextDouble() + 250.0f,
                            FromName = $"г.Вольск ЦЕМ 1 {(rnd.NextDouble() * 50.0f):F1} Н",
                        });
                    }
                    db.CementResearches.AddRange(researches);
                    db.SaveChanges();
                }

                if (!db.HammerBinderResearches.Any())
                {
                    var researches = new List<HammerBinderResearch>();
                    var tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.HammerBinderResearch).ToArray();
                    var labolatorians = db.Laboratorians.ToArray();
                    var workshifts = db.WorkShifts.ToArray();
                    for (int i = 0; i < power; i++)
                    {
                        var task = tasks[rnd.Next(tasks.Length)];
                        researches.Add(new HammerBinderResearch()
                        {
                            DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                            Name = $"Результат исследования молото-вяжущего № {i}",
                            Value = rnd.NextDouble() * 100.0,
                            Text = $"Результат № {i} удовлетворителен.",
                            Description = $"Описание результата исследования молото-вяжущего № {i}",
                            WorkTask = task,
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                            Sieve0_2 = (float)rnd.NextDouble() + 30.0f,
                            Surface = (float)rnd.NextDouble() * 10.0f + 10.0f,
                            Perfomance = (float)rnd.NextDouble() * 10.0f + 10.0f,
                            Activity = (float)rnd.NextDouble() * 10.0f + 50.0f,
                        });
                    }
                    db.HammerBinderResearches.AddRange(researches);
                    db.SaveChanges();
                }


            }
        }

        #endregion
    }
}
