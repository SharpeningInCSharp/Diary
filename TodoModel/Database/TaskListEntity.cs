using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel.Database
{
    public class TaskListEntity : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }
        public IList<TodoNote> notes { get; }
    }
}
