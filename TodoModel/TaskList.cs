using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TodoModel
{
	public partial class TaskList
	{
		/// <summary>
		/// true - в прямом направление, в обратном - false
		/// </summary>
		public bool Ascending { get; private set; } = true;

		public string Title { get; }

		public event Action CollectionChanged;

		private readonly List<TaskBase> tasks = new List<TaskBase>();

		public IEnumerable<TaskBase> Tasks => new List<TaskBase>(tasks);

		private readonly List<TaskBase> completedTasks = new List<TaskBase>();

		public IEnumerable<TaskBase> CompletedTasks => new List<TaskBase>(completedTasks);

		public TaskList(string name)
		{
			Title = name;
		}

		public void Add(TaskBase task)
		{
			task.TaskCompleted += Task_TaskCompleted;
			task.TaskDeleted += Task_TaskDeleted;
			task.TaskMovedOut += Task_TaskDeleted;

			tasks.Add(task);

			CollectionChanged?.Invoke();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tasks"));
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			tasks.Remove(task);
			completedTasks.Remove(task);

			CollectionChanged?.Invoke();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tasks"));
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			tasks.Remove(task);
			completedTasks.Add(task);

			CollectionChanged?.Invoke();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tasks"));
		}

		public void OrderByPriority()
		{
			if (Ascending)
			{
				tasks.Sort();
			}
			else
			{
				tasks.Sort();
				tasks.Reverse();
			}

			Ascending = !Ascending;

			CollectionChanged?.Invoke();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tasks"));
		}
	}

	public partial class TaskList : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
