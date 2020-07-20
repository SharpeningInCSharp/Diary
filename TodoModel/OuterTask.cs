using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoModel
{
	public partial class OuterTask : TaskBase
	{
		public List<Task> InnerTasks { get; set; }

		public DateTime? InitialDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? FinalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public OuterTask() : base()
		{ }

		public OuterTask(TaskBase taskBase) : base(taskBase)
		{ }

		public void AddInner(Task task)
		{
			InnerTasks.Add(task ?? throw new ArgumentNullException(nameof(task)));

			OnPropertyChanged("InnerTasks");
		}
	}

	public partial class OuterTask : IEnumerable<TaskBase>, IDatesRange
	{
		public IEnumerator<TaskBase> GetEnumerator()
		{
			return InnerTasks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return InnerTasks.GetEnumerator();
		}
	}
}
