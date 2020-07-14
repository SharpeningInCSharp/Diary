using System;
using System.Drawing;

namespace Model
{
	public abstract partial class PriorityBase
	{
		public string Name { get; }

		public double Value { get; }

		public Color Color { get; set; }

		public PriorityBase(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}

	public abstract partial class PriorityBase : IComparable<PriorityBase>, IEquatable<PriorityBase>
	{
		/// <summary>
		/// Comparsion for ordering
		/// </summary>
		/// <param name="other">Compared object of <see cref="PriorityBase"/></param>
		/// <returns> this before other -> -1 this==other -> 0 this after other -> 1</returns>
		public int CompareTo(PriorityBase other)
		{
			return Value.CompareTo(other.Value);
		}

		/// <summary>
		/// Equality comparison
		/// </summary>
		/// <param name="other">Compared object of <see cref="PriorityBase"/></param>
		/// <returns>true - objects are equal, otherwise - false</returns>
		public bool Equals(PriorityBase other)
		{
			return Name.Equals(other.Name) && Value.Equals(other.Value);
		}
	}
}
