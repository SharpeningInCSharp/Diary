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

		public TaskListEntity()
		{ }

		public TaskListEntity(TaskList taskList)
		{
			Name = taskList.Title;

			notes = new List<TodoNote>();
			foreach (var item in taskList.Tasks)
			{
				
			}
		}
	}
}
