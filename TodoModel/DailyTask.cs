using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public abstract partial class DailyTask
	{
		public void Call()
		{

		}
	}

	public abstract partial class DailyTask : TaskBase
	{
		public string Header { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Note { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IPriority Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool Equals(TaskBase other)
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
	}
}
