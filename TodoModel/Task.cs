using System;
using System.Collections;
using System.Collections.Generic;

namespace TodoModel
{
	public partial class Task : TaskBase
	{
		public bool HasInners => innerTasks.Count != 0;

		private List<Task> innerTasks = new List<Task>();

		public DateTime? InitialDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? FinalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task() : base()
		{ }

		public Task(TaskBase taskBase) : base(taskBase)
		{ }

		public void AddInner(Task task)
		{
			innerTasks.Add(task ?? throw new ArgumentNullException(nameof(task)));
		}
	}

	public partial class Task : IEnumerable<TaskBase>, IDatesRange
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
