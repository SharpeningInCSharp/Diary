using System;
using System.Collections;
using System.Collections.Generic;

namespace TodoModel
{
	public partial class OuterTask : TaskBase
	{
		private readonly List<TaskBase> innerTasks = new List<TaskBase>();

		/// <summary>
		/// This prop return only values, DON'T use it to change object!
		/// </summary>
		public IEnumerable<TaskBase> InnerTasks => new List<TaskBase>(innerTasks);

		public OuterTask() : base()
		{ }

		public void Add(Task task)
		{
			innerTasks.Add(task ?? throw new ArgumentNullException(nameof(task)));

			task.TaskCompleted += Task_TaskCompleted;
			task.TaskDeleted += Task_TaskDeleted;

			OnPropertyChanged("InnerTasks");
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			innerTasks.Remove(task);

			OnPropertyChanged("InnerTasks");
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			innerTasks.Remove(task);

			OnPropertyChanged("InnerTasks");
		}
	}

	public partial class OuterTask : IEnumerable<TaskBase>
	{
		public IEnumerator<TaskBase> GetEnumerator()
		{
			return innerTasks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerTasks.GetEnumerator();
		}
	}
}
