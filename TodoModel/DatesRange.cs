using System;

namespace TodoModel
{
	public interface IDatesRange
	{
		DateTime? InitialDate { get; set; }
		DateTime? FinalDate { get; set; }
	}
}
