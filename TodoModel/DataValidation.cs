using System;
using System.Collections.Generic;
using System.Text;

namespace TodoModel
{
	public static class DataValidation
	{
		public static bool IsNameValid(string input) => string.IsNullOrWhiteSpace(input) == false;
	}
}
