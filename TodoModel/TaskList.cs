using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel
{
	public class TaskList
	{
		public string Name { get; }

		private List<TaskBase> tasks = new List<TaskBase>();
		private List<TaskBase> completedTasks = new List<TaskBase>();

		public TaskList(string name)
		{
			Name = name;
		}

		public void Add(TaskBase task)
		{
			tasks.Add(task);
		}

		public void OrderByPriority()
		{
			tasks.Sort();
		}
	}
}
