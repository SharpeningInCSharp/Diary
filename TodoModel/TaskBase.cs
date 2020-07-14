using System;

namespace Model
{
	public abstract class TaskBase : IEquatable<TaskBase>
	{
		public string Header { get; set; }

		public string Note { get; set; }

		public IPriority Priority { get; set; }

		public abstract void Complete();

		public abstract void Delete();

		public abstract void SetAside();

		public bool Equals(TaskBase other)
		{
			throw new NotImplementedException();
		}
	}
}
