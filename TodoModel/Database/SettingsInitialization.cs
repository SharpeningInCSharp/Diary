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
        public static void ParamsSetting()
        {
            var realm = Realm.GetInstance();
            var starts = realm.All<Settings>().Where(p => p.Param == "Starts").FirstOrDefault();
            if(starts == null)
                realm.Write(() =>
                {
                    var newSet = new Settings
                    {
                       Param = "Starts",
                       //value = 1
                    };
                    realm.Add(newSet);
                });
            else
                realm.Write(() =>
                {
                    //starts.value++;
                });
        }
    }
}
