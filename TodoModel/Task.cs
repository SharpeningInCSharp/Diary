using System;
using System.Collections;
using System.Collections.Generic;

namespace TodoModel
{
	public partial class Task : TaskBase
	{
		private List<Task> innerTasks = null;

		public DateTime? InitialDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? FinalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task() : base()
		{
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
