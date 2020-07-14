using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel
{
	public class TaskList
	{
		public string Name { get; }

		private List<ITask> tasks = new List<ITask>();
		private List<ITask> completedTasks = new List<ITask>();

		public TaskList(string name)
		{
			Name = name;
		}

		public void Add(ITask task)
		{
			tasks.Add(task);
		}

		public void OrderByPriority()
		{
			tasks.Sort();
		}
	}
}
