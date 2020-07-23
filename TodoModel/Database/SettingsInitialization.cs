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

            //var config = new RealmConfiguration
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

            //var realm = Realm.GetInstance(config);

            var config = new RealmConfiguration() { SchemaVersion = 3 };

            var realm = Realm.GetInstance(config);

            var starts = realm.All<Settings>().Where(p => p.Param == "Starts").FirstOrDefault();
            if (starts == null)
                realm.Write(() =>
                {
                    var newSet = new Settings
                    {
                        Param = "Starts",
                        value = 1
                    };
                    realm.Add(newSet);
                });
            else
                realm.Write(() =>
                {
                    starts.value += 1;
                });
        }
    }
}
