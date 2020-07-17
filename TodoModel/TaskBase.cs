using System;

namespace TodoModel
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
		public string Header
		{
			get => headerData;
			set
			{
				SetField(ref headerData, value, "Header");
			}
		}

		/// <summary>
		/// Some note to the Task
		/// </summary>
		public string Note
		{
			get => noteData;
			set
			{
				SetField(ref noteData, value, "Note");
			}
		}

		private Priority priority = Priority.Normal;
		private string noteData = "";
		private string headerData = "";

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
		public event TaskHandler TaskMovedOut;

		public TaskBase()
		{ }

		public TaskBase(TaskBase taskBase)
		{
			headerData = taskBase.headerData;
			noteData = taskBase.noteData;
			priority = taskBase.priority;
			IsCompleted = taskBase.IsCompleted;
		}

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

		/// <summary>
		/// Move out from current tasks list
		/// </summary>
		public void MoveOut()
		{
			TaskMovedOut?.Invoke(this);
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

			return headerData.Equals(other.headerData);
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
