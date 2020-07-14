using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public abstract partial class Task : IEnumerable<ITask>, IDatesRange
	{
		private List<Task> innerTasks = null;

		public DateTime? InitialDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? FinalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public IEnumerator<ITask> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
	public abstract partial class Task : ITask
	{
		public string Header { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Note { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IPriority Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Equals(ITask other)
		{
			throw new NotImplementedException();
		}

		public void Delete()
		{
			throw new NotImplementedException();
		}

		public void SetAside()
		{
			throw new NotImplementedException();
		}

		public void Complete()
		{
			throw new NotImplementedException();
		}

		public int CompareTo(ITask other)
		{
			throw new NotImplementedException();
		}
	}
}
