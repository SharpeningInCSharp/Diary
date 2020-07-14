using System;

namespace Model
{
	public abstract class TaskBase : IEquatable<TaskBase>, IComparable<TaskBase>
	{
		public bool IsCompleted { get; private set; } = false;

		public string Header { get; set; }

		public string Note { get; set; }

		public IPriority Priority { get; set; }

		/// <summary>
		/// Completes task
		/// </summary>
		public void Complete()
		{
			IsCompleted = true;
		}

		public void Undo()
		{
			IsCompleted = false;
		}

		/// <summary>
		/// Deletes task
		/// </summary>
		public abstract void Delete();

		/// <summary>
		/// Delays task
		/// </summary>
		public abstract void SetAside();

		public bool Equals(TaskBase other)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(TaskBase other)
		{
			throw new NotImplementedException();
		}
	}
}
