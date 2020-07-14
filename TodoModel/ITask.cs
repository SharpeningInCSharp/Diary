using System;

namespace Model
{
	public interface ITask : IEquatable<ITask>, IComparable<ITask>
	{
		string Header { get; set; }

		string Note { get; set; }

		IPriority Priority { get; set; }

		void Complete();

		void Delete();

		void SetAside();
	}
}
