using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoModel
{
	public partial class OuterTask : TaskBase
	{
		private readonly List<Task> innerTasks = new List<Task>();

		/// <summary>
		/// This prop return only values, DON'T use it to change object!
		/// </summary>
		public IEnumerable<Task> InnerTasks => new List<Task>(innerTasks);

		public DateTime? InitialDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? FinalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public OuterTask() : base()
		{ }

		public void Add(Task task)
		{
			innerTasks.Add(task ?? throw new ArgumentNullException(nameof(task)));

			OnPropertyChanged("InnerTasks");
		}
	}

	public partial class OuterTask : IEnumerable<TaskBase>, IDatesRange
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
