using System;
using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Researches;

namespace SilikatLab.lib.Data.Base
{
    public partial class SPLaboratoryDb
    {
        private static Random rnd = new Random();
        /// <summary> Добавление тестовых данных в таблицы </summary>
        public static void AddTestData(SPLaboratoryDb db, int power = 10)
        {
            AddLaboratorians(db, power);
            AddLogins(db);
            AddWorkShifts(db, power);
            AddTypeResearches(db, power);
            AddObjects(db, power);
            AddWorkTasks(db, power);
            AddResearches(db, power);
        }

        private static void AddResearches(SPLaboratoryDb db, int power)
        {
            var tasks = db.WorkTasks.ToArray();
            var researches = new List<Research>();
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
                    Normal = true,
                    Text = $"Результат № {i} удовлетворителен.",
                    Description = $"Описание результата исследования № {i}",
                    WorkTask = task,
                    Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                    WorkShift = workshifts[rnd.Next(workshifts.Length)],
                });
            }

            researches.Add(new Research
            {
                DateTime = DateTime.Now.AddMinutes(rnd.Next(5, 60)),
                Name = $"Результат исследования № 99",
                Value = rnd.NextDouble() * 100.0,
                Text = $"Результат № 99 удовлетворителен.",
                WorkTask = null,
                Description = $"Описание результата исследования № 99",
                Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                WorkShift = workshifts[rnd.Next(workshifts.Length)],
            });
            researches.Add(new Research
            {
                DateTime = DateTime.Now.AddMinutes(rnd.Next(15, 160)),
                Name = $"Результат исследования № 999",
                Value = rnd.NextDouble() * 100.0,
                Text = $"Результат № 999 удовлетворителен.",
                WorkTask = null,
                Description = $"Описание результата исследования № 999",
                Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                WorkShift = workshifts[rnd.Next(workshifts.Length)],
            });
            db.Researches.AddRange(researches);
            db.SaveChanges();
            var researchesQ = new List<BlockQualityResearch>();
            tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch)
                .ToArray();
            labolatorians = db.Laboratorians.ToArray();
            for (int i = 0; i < power; i++)
            {
                var task = tasks[rnd.Next(tasks.Length)];
                researchesQ.Add(new BlockQualityResearch
                {
                    DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                    Name = $"Результат исследования прочности № {i}",
                    Value = rnd.NextDouble() * 100.0,
                    Normal = true,
                    Text = $"Результат № {i} удовлетворителен.",
                    Description = $"Описание результата исследования пр-ти № {i}",
                    WorkTask = task,
                    Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                    WorkShift = workshifts[rnd.Next(workshifts.Length)],
                    Format = "600*300*200",
                    Trademark = "D500",
                    Weight = (float) rnd.NextDouble() * 30.0f + 600.0f,
                    SizeX = (float) rnd.NextDouble() + 10.0f,
                    SizeY = (float) rnd.NextDouble() + 10.0f,
                    SizeZ = (float) rnd.NextDouble() + 10.0f,
                    BeforeDensity = (float) rnd.NextDouble() * 70.0f + 600.0f,
                    Coefficient = 1.15f,
                    BeforeWeight = (float) rnd.NextDouble() * 50.0f + 600.0f,
                    AfterWeight = (float) rnd.NextDouble() * 50.0f + 500.0f,
                    Humidity = (float) rnd.NextDouble() + 30.0f,
                    Load = (float) rnd.NextDouble() + 30.0f,
                    Strength = (float) rnd.NextDouble() + 3.0f,
                    AfterDensity = (float) rnd.NextDouble() * 50.0f + 500.0f,
                });
            }

            db.BlockQualityResearches.AddRange(researchesQ);
            db.SaveChanges();
            var researchesS = new List<SludgeResearch>();
            tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.SludgeResearch).ToArray();
            for (int i = 0; i < power; i++)
            {
                var task = tasks[rnd.Next(tasks.Length)];
                researchesS.Add(new SludgeResearch()
                {
                    DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                    Name = $"Результат исследования шлама № {i}",
                    Value = rnd.NextDouble() * 100.0,
                    Text = $"Результат № {i} удовлетворителен.",
                    Description = $"Описание результата исследования шлама № {i}",
                    WorkTask = task,
                    Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                    WorkShift = workshifts[rnd.Next(workshifts.Length)],
                    Density = rnd.Next(1500, 1600),
                    Surface = rnd.Next(2500, 3000),
                    Sieve0_8 = (float) rnd.NextDouble() + 30.0f,
                    Sieve0_09 = (float) rnd.NextDouble() + 30.0f,
                    Sieve0_045 = (float) rnd.NextDouble() + 30.0f,
                    Gypsum = (float) rnd.NextDouble() + 300.0f,
                    Humidity = (float) rnd.NextDouble() + 30.0f,
                });
            }

            db.SludgeResearches.AddRange(researchesS);
            db.SaveChanges();
            var researchesC = new List<CementResearch>();
            tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.CementReseatch).ToArray();
            for (int i = 0; i < power; i++)
            {
                var task = tasks[rnd.Next(tasks.Length)];
                researchesC.Add(new CementResearch()
                {
                    DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                    Name = $"Результат исследования цемента № {i}",
                    Value = rnd.NextDouble() * 100.0,
                    Text = $"Результат № {i} удовлетворителен.",
                    Description = $"Описание результата исследования цемента № {i}",
                    WorkTask = task,
                    Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                    WorkShift = workshifts[rnd.Next(workshifts.Length)],
                    Party = rnd.Next(1000, 9000).ToString(),
                    PassportVc = (float) rnd.NextDouble() + 30.0f,
                    PassportNsh = (float) rnd.NextDouble() + 180.0f,
                    PassportKsh = (float) rnd.NextDouble() + 250.0f,
                    ActualVc = (float) rnd.NextDouble() + 30.0f,
                    ActualNsh = (float) rnd.NextDouble() + 180.0f,
                    ActualKsh = (float) rnd.NextDouble() + 250.0f,
                    FromName = $"г.Вольск ЦЕМ 1 {(rnd.NextDouble() * 50.0f):F1} Н",
                });
            }

            db.CementResearches.AddRange(researchesC);
            db.SaveChanges();
            var researchesHB = new List<HammerBinderResearch>();
            tasks = db.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.HammerBinderResearch)
                .ToArray();
            for (int i = 0; i < power; i++)
            {
                var task = tasks[rnd.Next(tasks.Length)];
                researchesHB.Add(new HammerBinderResearch()
                {
                    DateTime = task.TaskDateTime.AddMinutes(rnd.Next(5, 60)),
                    Name = $"Результат исследования молото-вяжущего № {i}",
                    Value = rnd.NextDouble() * 100.0,
                    Text = $"Результат № {i} удовлетворителен.",
                    Description = $"Описание результата исследования молото-вяжущего № {i}",
                    WorkTask = task,
                    Laboratorian = labolatorians[rnd.Next(labolatorians.Length)],
                    WorkShift = workshifts[rnd.Next(workshifts.Length)],
                    Sieve0_2 = (float) rnd.NextDouble() + 30.0f,
                    Surface = (float) rnd.NextDouble() * 10.0f + 10.0f,
                    Perfomance = (float) rnd.NextDouble() * 10.0f + 10.0f,
                    Activity = (float) rnd.NextDouble() * 10.0f + 50.0f,
                });
            }

            db.HammerBinderResearches.AddRange(researchesHB);
            db.SaveChanges();
        }

        private static void AddWorkTasks(SPLaboratoryDb db, int power)
        {
            var types = db.TypeResearches;
            var objects = db.ResearchObjects.ToArray();
            var tasks = Enumerable.Range(1, power)
                .Select(i => new WorkTask
                {
                    DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                    TaskDateTime = DateTime.Now.AddHours(rnd.Next(-12, 12)),
                    Name = $"Задание № {i}",
                    TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                    ResearchObject = objects[rnd.Next(objects.Length)],
                }).ToList();
            tasks.Add(new WorkTask
            {
                DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                TaskDateTime = DateTime.Now.AddMinutes(10),
                Name = $"Периодическое задание(10 минут)",
                AgainInMinutes = 10,
                TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                ResearchObject = objects[rnd.Next(objects.Length)],
            });
            tasks.Add(new WorkTask
            {
                DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                TaskDateTime = DateTime.Now.AddMinutes(60),
                Name = $"Периодическое задание(1 час)",
                AgainInMinutes = 60,
                TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.Simple),
                ResearchObject = objects[rnd.Next(objects.Length)],
            });
            tasks.Add(new WorkTask
            {
                DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                TaskDateTime = DateTime.Now.AddMinutes(60),
                Name = $"Задание исследования прочности",
                Completed = true,
                TypeResearch = types.First(t => t.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch),
                ResearchObject = objects[rnd.Next(objects.Length)],
            });
            tasks.Add(new WorkTask
            {
                DateTime = DateTime.Now.AddHours(-rnd.Next(12, 48)),
                TaskDateTime = DateTime.Now.AddMinutes(80),
                Name = $"Задание исследования шлама",
                Completed = true,
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

        private static void AddObjects(SPLaboratoryDb db, int power)
        {
            var objects = Enumerable.Range(1, power)
                .Select(i => new ResearchObject
                {
                    Name = $"Массив № {i}",
                }).ToArray();
            db.ResearchObjects.AddRange(objects);
            db.SaveChanges();
        }

        private static void AddTypeResearches(SPLaboratoryDb db, int power)
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

        private static void AddWorkShifts(SPLaboratoryDb db, int power)
        {
            var shifts = Enumerable.Range(1, power / 3)
                .Select(i => new WorkShift
                {
                    Name = $"Смена № {i}"
                });
            db.WorkShifts.AddRange(shifts);
            db.SaveChanges();
        }

        private static void AddLogins(SPLaboratoryDb db)
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
                new()
                {
                    Login = "tech",
                    Password = "1",
                    Access = UserLogin.AccessLevel.Control,
                },
            };
            db.UserLogins.AddRange(logins);
            db.SaveChanges();
        }

        private static void AddLaboratorians(SPLaboratoryDb db, int power)
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
        }

        /// <summary> Очистка таблиц базы данных </summary>
        public static void ClearData(SPLaboratoryDb db)
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
    }
}
