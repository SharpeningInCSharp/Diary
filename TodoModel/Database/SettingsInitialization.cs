using Android.Util;
using Realms;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TodoModel.Database
{
    public class SettingsInitialization
    {
        public static void ParamsSetting()
        {
            //var realmm = Realm.GetInstance();
            //realmm.Write(() =>
            //{
            //    var newSet = new TaskListEntity
            //    {
            //        Name = "Main"
            //    };
            //    realmm.Add(newSet);
            //});

            //var config = new RealmConfiguration //пример миграции
            //{
            //    SchemaVersion = 3,
            //    MigrationCallback = (migration, oldSchemaVersion) =>
            //    {
            //        var newTasks = migration.NewRealm.All<TodoNote>();

            //        // Use the dynamic api for oldPeople so we can access
            //        // .FirstName and .LastName even though they no longer
            //        // exist in the class definition.

            //        for (var i = 0; i < newTasks.Count(); i++)
            //        {
            //            newTasks.ElementAt(i).taskList = null;
            //        }
            //    }
            //};

            var config = new RealmConfiguration() { SchemaVersion = 3 };

            var realm = Realm.GetInstance(config);

            var starts = realm.All<Settings>().Where(p => p.Param == "Starts").FirstOrDefault();
            if (starts == null)
            {
                realm.Write(() =>
                {
                    var newSet = new Settings
                    {
                        Param = "Starts",
                        value = 1
                    };
                    realm.Add(newSet);
                });
                BaseContentInitialization();
            }
            else
			{
				realm.Write(() =>
                {
                    starts.value += 1;
                });
			}
		}

        public static void BaseContentInitialization()
        {

            var config = new RealmConfiguration() { SchemaVersion = 3 };
            var realm = Realm.GetInstance(config);

            realm.Write(() =>
            {
                var newList = new TaskListEntity()
                {
                    Name = "Лист заданий"
                };
                realm.Add(newList);
                var newtask1 = new TodoNote()
                {
                    Id = 0,
                    header = "Задание без подзадач",
                    Priority = realm.All<PriorityEntity>().FirstOrDefault(),
                    taskList = realm.All<TaskListEntity>().FirstOrDefault(),
                    HasInners = false,
                    IsCompleted = false
                };
                realm.Add(newtask1);
                var subtask1 = new TodoNote()
                {
                    Id = 1,
                    header = "Подзадача 1",
                    Priority = realm.All<PriorityEntity>().FirstOrDefault(),
                    taskList = realm.All<TaskListEntity>().FirstOrDefault(),
                    HasInners = false,
                    IsCompleted = false
                };
                var subtask2 = new TodoNote()
                {
                    Id = 2,
                    header = "Подзадача 2",
                    Priority = realm.All<PriorityEntity>().FirstOrDefault(),
                    taskList = realm.All<TaskListEntity>().FirstOrDefault(),
                    HasInners = false,
                    IsCompleted = false
                };
                realm.Add(subtask1);
                realm.Add(subtask2);
                var newtask2 = new TodoNote()
                {
                    Id = 3,
                    header = "Задача с подзадачами",
                    Priority = realm.All<PriorityEntity>().FirstOrDefault(),
                    taskList = realm.All<TaskListEntity>().FirstOrDefault(),
                    HasInners = true,
                    IsCompleted = false
                };
                newtask2.InnerNotes.Add(subtask1);
                newtask2.InnerNotes.Add(subtask2);
                realm.Add(newtask2);
            });

        }
    }
}
