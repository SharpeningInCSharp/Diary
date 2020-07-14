using System;
using System.Drawing;

namespace Model
{
	public interface IPriority : IComparable<IPriority>, IEquatable<IPriority>
	{
		string Name { get; }

		double Value { get; set; }

		Color Color { get; set; }
	}
}
