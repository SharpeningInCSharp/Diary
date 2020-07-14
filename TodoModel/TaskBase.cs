using System;

namespace Model
{
	public abstract partial class TaskBase : IEquatable<TaskBase>, IComparable<TaskBase>
	{
		/// <summary>
		/// Indicates is current Task completed or not
		/// </summary>
		public bool IsCompleted { get; private set; } = false;

		public string Header { get; set; }

		public string Note { get; set; }

		public PriorityBase Priority { get; set; }

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
	}

	public abstract partial class TaskBase : IEquatable<TaskBase>, IComparable<TaskBase>
	{
		/// <summary>
		/// Equality comparison
		/// </summary>
		/// <param name="other">Compared object of <see cref="TaskBase"/></param>
		/// <returns>true - objects are equal, otherwise - false</returns>
		public bool Equals(TaskBase other)
		{
			if (other is null)
				return false;

			return Header.Equals(other.Header);
		}

		/// <summary>
		/// Comparsion for ordering
		/// </summary>
		/// <param name="other">Compared object of <see cref="TaskBase"/></param>
		/// <returns> this before other -> -1 this==other -> 0 this after other -> 1</returns>
		public int CompareTo(TaskBase other)
		{
			if (other is null)
				new ArgumentNullException(nameof(other));

			return Priority.CompareTo(other.Priority);
		}
	}
}
