using System;
using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Researches;

namespace SilikatLab.lib.Data.Base
{
    public partial class SPLaboratoryEntities
    {
        private static Random rnd = new Random();
        /// <summary> Добавление тестовых данных в таблицы </summary>
        public static void AddTestData(SPLaboratoryEntities entities, int power = 10)
        {
            AddLaboratorians(entities, power);
            AddLogins(entities);
            AddWorkShifts(entities, power);
            AddTypeResearches(entities, power);
            AddObjects(entities, power);
            AddWorkTasks(entities, power);
            AddResearches(entities, power);
        }

        private static void AddResearches(SPLaboratoryEntities entities, int power)
        {
            var types = entities.TypeResearches.ToArray();
            var tasks = entities.WorkTasks.ToArray();
            var researches = new List<Research>();
            var labolatorians = entities.Laboratorians.ToArray();
            var objects = entities.ResearchObjects.ToArray();
            var workshifts = entities.WorkShifts.ToArray();
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
                    ResearchObject = task.ResearchObject,
                    TypeResearch = task.TypeResearch,
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
                ResearchObject = objects[rnd.Next(objects.Length)],
                TypeResearch = types[rnd.Next(types.Length)],
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
                ResearchObject = objects[rnd.Next(objects.Length)],
                TypeResearch = types[rnd.Next(types.Length)],
            });
            entities.Researches.AddRange(researches);
            entities.SaveChanges();
            var researchesQ = new List<BlockQualityResearch>();
            tasks = entities.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.BlockQualityResearch)
                .ToArray();
            labolatorians = entities.Laboratorians.ToArray();
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
                    ResearchObject = objects[rnd.Next(objects.Length)],
                    TypeResearch = types[rnd.Next(types.Length)],
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

            entities.BlockQualityResearches.AddRange(researchesQ);
            entities.SaveChanges();
            var researchesS = new List<SludgeResearch>();
            tasks = entities.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.SludgeResearch).ToArray();
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
                    ResearchObject = objects[rnd.Next(objects.Length)],
                    TypeResearch = types[rnd.Next(types.Length)],
                    Density = rnd.Next(1500, 1600),
                    Surface = rnd.Next(2500, 3000),
                    Sieve0_8 = (float) rnd.NextDouble() + 30.0f,
                    Sieve0_09 = (float) rnd.NextDouble() + 30.0f,
                    Sieve0_045 = (float) rnd.NextDouble() + 30.0f,
                    Gypsum = (float) rnd.NextDouble() + 300.0f,
                    Humidity = (float) rnd.NextDouble() + 30.0f,
                });
            }

            entities.SludgeResearches.AddRange(researchesS);
            entities.SaveChanges();
            var researchesC = new List<CementResearch>();
            tasks = entities.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.CementReseatch).ToArray();
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
                    ResearchObject = objects[rnd.Next(objects.Length)],
                    TypeResearch = types[rnd.Next(types.Length)],
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

            entities.CementResearches.AddRange(researchesC);
            entities.SaveChanges();
            var researchesHB = new List<HammerBinderResearch>();
            tasks = entities.WorkTasks.Where(t => t.TypeResearch.TypeResult == TypeResearch.IsTypeResult.HammerBinderResearch)
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
                    ResearchObject = objects[rnd.Next(objects.Length)],
                    TypeResearch = types[rnd.Next(types.Length)],
                    Sieve0_2 = (float) rnd.NextDouble() + 30.0f,
                    Surface = (float) rnd.NextDouble() * 10.0f + 10.0f,
                    Perfomance = (float) rnd.NextDouble() * 10.0f + 10.0f,
                    Activity = (float) rnd.NextDouble() * 10.0f + 50.0f,
                });
            }

            entities.HammerBinderResearches.AddRange(researchesHB);
            entities.SaveChanges();
        }

        private static void AddWorkTasks(SPLaboratoryEntities entities, int power)
        {
            var types = entities.TypeResearches;
            var objects = entities.ResearchObjects.ToArray();
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
            entities.WorkTasks.AddRange(tasks);
            entities.SaveChanges();
        }

        private static void AddObjects(SPLaboratoryEntities entities, int power)
        {
            var objects = Enumerable.Range(1, power)
                .Select(i => new ResearchObject
                {
                    Name = $"Массив № {i}",
                }).ToArray();
            entities.ResearchObjects.AddRange(objects);
            entities.SaveChanges();
        }

        private static void AddTypeResearches(SPLaboratoryEntities entities, int power)
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
            entities.TypeResearches.AddRange(types);
            entities.SaveChanges();
        }

        private static void AddWorkShifts(SPLaboratoryEntities entities, int power)
        {
            var shifts = Enumerable.Range(1, power / 3)
                .Select(i => new WorkShift
                {
                    Name = $"Смена № {i}"
                });
            entities.WorkShifts.AddRange(shifts);
            entities.SaveChanges();
        }

        private static void AddLogins(SPLaboratoryEntities entities)
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
                    Laboratorian = entities.Laboratorians.Find(1),
                },
                new()
                {
                    Login = "tech",
                    Password = "1",
                    Access = UserLogin.AccessLevel.Control,
                },
            };
            entities.UserLogins.AddRange(logins);
            entities.SaveChanges();
        }

        private static void AddLaboratorians(SPLaboratoryEntities entities, int power)
        {
            var labors = Enumerable.Range(1, power / 3)
                .Select(i => new Laboratorian
                {
                    SurName = $"Иванова{i}",
                    Name = $"Галина{i}",
                    Patronymic = $"Ивановна{i}",
                });
            entities.Laboratorians.AddRange(labors);
            entities.SaveChanges();
        }

        /// <summary> Очистка таблиц базы данных </summary>
        public static void ClearData(SPLaboratoryEntities entities)
        {
            if (entities.HammerBinderResearches.Any())
            {
                entities.HammerBinderResearches.RemoveRange(entities.HammerBinderResearches);
                entities.SaveChanges();
            }
            if (entities.CementResearches.Any())
            {
                entities.CementResearches.RemoveRange(entities.CementResearches);
                entities.SaveChanges();
            }
            if (entities.SludgeResearches.Any())
            {
                entities.SludgeResearches.RemoveRange(entities.SludgeResearches);
                entities.SaveChanges();
            }
            if (entities.BlockQualityResearches.Any())
            {
                entities.BlockQualityResearches.RemoveRange(entities.BlockQualityResearches);
                entities.SaveChanges();
            }
            if (entities.Researches.Any())
            {
                entities.Researches.RemoveRange(entities.Researches);
                entities.SaveChanges();
            }
            if (entities.WorkTasks.Any())
            {
                entities.WorkTasks.RemoveRange(entities.WorkTasks);
                entities.SaveChanges();
            }
            if (entities.ResearchObjects.Any())
            {
                entities.ResearchObjects.RemoveRange(entities.ResearchObjects);
                entities.SaveChanges();
            }
            if (entities.TypeResearches.Any())
            {
                entities.TypeResearches.RemoveRange(entities.TypeResearches);
                entities.SaveChanges();
            }
            if (entities.WorkShifts.Any())
            {
                entities.WorkShifts.RemoveRange(entities.WorkShifts);
                entities.SaveChanges();
            }
            if (entities.UserLogins.Any())
            {
                entities.UserLogins.RemoveRange(entities.UserLogins);
                entities.SaveChanges();
            }
            if (entities.Laboratorians.Any())
            {
                entities.Laboratorians.RemoveRange(entities.Laboratorians);
                entities.SaveChanges();
            }
        }
    }
}
