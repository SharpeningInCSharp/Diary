using Android.Util;
using Realms;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoModel.Database
{
    public class SettingsInitialization
    {
        public static int ParamsSetting()
        {
            var realm = Realm.GetInstance();
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
                    //Log.Error("1111111111111111111111111", "22222222222222222222222222222222222222222");
                    //Console.WriteLine("555555555555555555555555555555555555555555");
                    realm.Add(newSet);
                });
                return 12;
            }
            else
            {
                realm.Write(() =>
                {
                    //Log.Error("222222222222222222222222222222222222", "33333333333333333333333333333333333333333333333");
                    //Console.WriteLine("444444444444444444444444444444444444444444");
                    starts.value = starts.value + 1;
                });
                return 13;
            }
        }
    }
}
