using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel.Database
{
    class TodoNote : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string header { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset? InitialDate { get; set; }
        public DateTimeOffset? FinalDate { get; set; }
        public bool HasInners { get; set; }
        public IList<TodoNote> InnerNotes { get;  }
        public PriorityEntity Priority { get; set; }
        
    }
}
