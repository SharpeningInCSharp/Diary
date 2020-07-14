using System;

namespace Model
{
	public interface IDatesRange
	{
		DateTime? InitialDate { get; set; }
		DateTime? FinalDate { get; set; }
	}
}
