using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Models;

namespace SilikatLabConsole.Data
{
    /// <summary> Лабораторная база данных </summary>
    class SPLaboratoryDb : DbContext
    {
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Laboratorian> Laboratorians { get; set; }
        public DbSet<ResearchObject> ResearchObjects { get; set; }
        public DbSet<TypeResearch> TypeResearches { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<Research> Researches { get; set; }

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


        public static void RemoveDataFromDb(SPLaboratoryDb db)
        {
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
            db.Database.Migrate();
            if (!db.Laboratorians.Any())
            {
                var labors = Enumerable.Range(1, power/3)
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
                            AgainInMinutes = 0,
                            TypeResearch = types[rnd.Next(types.Length)],
                            ResearchObject = objects[rnd.Next(objects.Length)],
                        }).ToList();
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(10),
                        Name = $"Периодическое задание каждые 10 минут",
                        AgainInMinutes = 10,
                        TypeResearch = types[rnd.Next(types.Length)],
                        ResearchObject = objects[rnd.Next(objects.Length)],
                    });
                    tasks.Add(new WorkTask
                    {
                        DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                        TaskDateTime = DateTime.Now.AddMinutes(60),
                        Name = $"Периодическое задание каждый час",
                        AgainInMinutes = 60,
                        TypeResearch = types[rnd.Next(types.Length)],
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
                            Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                            WorkShift = workshifts[rnd.Next(workshifts.Length)],
                        });
                    }
                    db.Researches.AddRange(researches);
                    db.SaveChanges();
                }
            }
        }
    }
}
