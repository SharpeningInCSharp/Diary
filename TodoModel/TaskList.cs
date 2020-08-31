using System;
using System.Collections.Generic;
using System.ComponentModel;
using TodoModel.Database;

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

		public TaskList(TaskListEntity listEntity)
		{
			Title = listEntity.Name;

			foreach (var item in listEntity.notes)
			{
				var tb = new OuterTask
				{
					Header = item.header,
					Note = item.Note,
					Priority = new Priority(item.Priority),
				};

				if (item.InnerNotes != null)
				{
					foreach (var inItem in item.InnerNotes)
					{
						tb.Add(new Task
						{
							Header = inItem.header,
							Note = inItem.Note,
							Priority = new Priority(inItem.Priority),
						});
					}
				}

			}
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

	public partial class TaskList : INotifyPropertyChanged, IEquatable<TaskList>, IComparable<TaskList>
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int CompareTo(TaskList other)
		{
			return Title.CompareTo(other.Title ?? throw new ArgumentNullException(nameof(other)));
		}

		public override bool Equals(object obj)
		{
			if (obj is TaskList taskList)
				return Equals(taskList);

			return false;
		}

		public bool Equals(TaskList other)
		{
			if (other is null)
				return false;

			return Title.Equals(other.Title);
		}
	}
}
