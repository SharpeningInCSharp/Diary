using Realms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TodoModel.Database
{
    class PriorityEntity : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }
        public int Value { get; set; }
        public int Color { get; set; }
        public IList<TodoNote> TodoNotes { get; }
    }
}
