using System;
using System.Drawing;

namespace TodoModel
{
	public interface IPriority : IComparable<IPriority>, IEquatable<IPriority>
	{
		string Name { get; }

		int Value { get; }

		Color Color { get; set; }
	}
}
