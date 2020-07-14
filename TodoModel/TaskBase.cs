using System;

namespace Model
{
	public abstract partial class TaskBase
	{
		/// <summary>
		/// Indicates is current Task completed or not
		/// </summary>
		public bool IsCompleted { get; private set; } = false;

		/// <summary>
		/// Header of the Task
		/// </summary>
		public string Header { get; set; }

		/// <summary>
		/// Some note to the Task
		/// </summary>
		public string Note { get; set; }

		public Priority Priority { get; set; }

		public delegate void TaskHandler(TaskBase task);

		public event TaskHandler TaskDeleted;
		public event TaskHandler TaskCompleted;
		public event TaskHandler TaskSetAside;

		public TaskBase()
		{ }

		/// <summary>
		/// Completes task
		/// </summary>
		public void Complete()
		{
			IsCompleted = true;
			TaskCompleted?.Invoke();
		}

		/// <summary>
		/// Deletes task
		/// </summary>
		public void Delete()
		{
			TaskDeleted?.Invoke(this);
		}

		/// <summary>
		/// Delays task
		/// </summary>
		public void SetAside()
		{
			TaskSetAside?.Invoke(this);
		}
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


		public override bool Equals(object obj)
		{
			if (obj is TaskBase task)
				return Equals(task);

			return false;
		}
	}
}
