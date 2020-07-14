using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public abstract partial class DailyTask
	{
		public void Call()
		{

		}
	}

	public abstract partial class DailyTask : TaskBase
	{
	}
}
