using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel.Database
{
    public class Settings : RealmObject
    {
        [PrimaryKey]
        public string Param { get; set; }
        public int value { get; set; }
    }
}
