﻿using System.Drawing;

namespace TodoModel
{
	public partial class Priority
	{
		public static int MaxValue = 10;
		public static int MinValue = 0;

		public string Name { get; }

		public int Value { get; }

		private Color color;
		public Color Color
		{
			get => color;
			set
			{
				SetField(ref color, value, "Color");
			}
		}

		public Priority(string name, int value)
		{
			Name = name;
			Value = value;
		}
	}

	public partial class Priority
	{
		public static Priority Low => new Priority("Default", 0);
		public static Priority Normal => new Priority("Normal", 4);
		public static Priority Hight => new Priority("Hight", 8);
	}

	public partial class Priority : ModelNotifier, IPriority
	{
		/// <summary>
		/// Comparsion for ordering
		/// </summary>
		/// <param name="other">Compared object of <see cref="Priority"/></param>
		/// <returns> this before other -> -1 this==other -> 0 this after other -> 1</returns>
		public int CompareTo(IPriority other)
		{
			return Value.CompareTo(other.Value);
		}

		/// <summary>
		/// Equality comparison
		/// </summary>
		/// <param name="other">Compared object of <see cref="Priority"/></param>
		/// <returns>true - objects are equal, otherwise - false</returns>
		public bool Equals(IPriority other)
		{
			return Name.Equals(other.Name) && Value.Equals(other.Value);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
