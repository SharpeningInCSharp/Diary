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
			task.TaskCompleted += Task_TaskCompleted;
			task.TaskDeleted += Task_TaskDeleted;

			tasks.Add(task);
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			tasks.Remove(task);
			completedTasks.Remove(task);
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			tasks.Remove(task);
			completedTasks.Add(task);
		}

		public void OrderByPriority()
		{
			tasks.Sort();
		}
	}
}
