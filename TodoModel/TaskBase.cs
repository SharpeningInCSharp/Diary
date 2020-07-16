using System;

namespace TodoModel
{
	public abstract partial class TaskBase
	{
		/// <summary>
		/// Indicates is current Task completed or not
		/// </summary>
		public bool IsCompleted { get; private set; } = false;

		private string header;

		/// <summary>
		/// Header of the Task
		/// </summary>
		public string Header
		{
			get => header;
			set
			{
				SetField(ref header, value, "Header");
			}
		}

		private string note;

		/// <summary>
		/// Some note to the Task
		/// </summary>
		public string Note
		{
			get => note;
			set
			{
				SetField(ref note, value, "Note");
			}
		}

		private Priority priority = Priority.Normal;

		/// <summary>
		/// Task Priority
		/// </summary>
		public Priority Priority
		{
			get => priority;
			set
			{
				SetField(ref priority, value, "Priority");
			}
		}

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
			TaskCompleted?.Invoke(this);
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

	public abstract partial class TaskBase : ModelNotifier, IEquatable<TaskBase>, IComparable<TaskBase>
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
