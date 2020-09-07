using Android.Graphics;
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
                realm.Write(() =>
                {
                    var newSet = new Settings
                    {
                        Param = "Notes",
                        value = 3
                    };
                    realm.Add(newSet);
                });
                BaseContentInitialization();
            }
            else
            {
                realm.Write(() =>
                {
                    var newSet = new Settings
                    {
                        Param = "Starts",
                        value = starts.value + 1
                    };
                    realm.Add(newSet, update: true);
                });
            }
        }

        public static void BaseContentInitialization()
        {
            var config = new RealmConfiguration() { SchemaVersion = 3 };
            var realm = Realm.GetInstance(config);
            realm.Write(() =>
            {
                PriorityEntity NormalPriority = new PriorityEntity()
                {
                    Name = "Normal",
                    Value = 5,
                    Color = Color.Gold.ToArgb()
                };

                PriorityEntity LowPriority = new PriorityEntity()
                {
                    Name = "Low",
                    Value = 2,
                    Color = Color.Chartreuse.ToArgb()
                };

                PriorityEntity HighPriority = new PriorityEntity()
                {
                    Name = "High",
                    Value = 8,
                    Color = Color.Red.ToArgb()
                };

                realm.Add(NormalPriority);
                realm.Add(LowPriority);
                realm.Add(HighPriority);

                var newList = new TaskListEntity()
                {
                    Name = "Список"
                };

                var emptyList = new TaskListEntity()
                {
                    Name = "Пустой список"
                };

                realm.Add(emptyList);

                var newTask = new TodoNote()
                {
                    Id = 0,
                    header = "Задача без подзадач",
                    Priority = NormalPriority,
                    taskList = newList,
                    HasInners = false,
                    IsCompleted = false
                };
                newList.notes.Add(newTask);

                var subtask1 = new TodoNote()
                {
                    Id = 1,
                    header = "Подзадача 1",
                    Priority = HighPriority,
                    taskList = newList,
                    HasInners = false,
                    IsCompleted = false
                };

                var subtask2 = new TodoNote()
                {
                    Id = 2,
                    header = "Подзадача 2",
                    Priority = HighPriority,
                    taskList = newList,
                    HasInners = false,
                    IsCompleted = false
                };

                var newtask2 = new TodoNote()
                {
                    Id = 3,
                    header = "Задача с подзадачами",
                    Priority = HighPriority,
                    taskList = newList,
                    HasInners = true,
                    IsCompleted = false
                };

                realm.Add(subtask1);
                realm.Add(subtask2);

                newtask2.InnerNotes.Add(subtask1);
                newtask2.InnerNotes.Add(subtask2);

                newList.notes.Add(newtask2);

                realm.Add(newTask);
                realm.Add(newtask2);
                realm.Add(newList);  
            });
        }
    }
}
