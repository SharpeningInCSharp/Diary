using TodoModel;
using System;
using System.Collections.Generic;
using System.Text;
using TodoModel;

namespace Diary.ViewModels
{
	public class TaskItemsViewModel : TasksBaseViewModel
	{
		public TaskList Tasks { get; set; }

		public TaskItemsViewModel(string title)
		{
			Title = title;

			Tasks = new TaskList("Today")
			{
				new Task
				{
					Header = "Мыть попу",
					Note = "с мылом",
				},

				new Task
				{
					Header = "RUN",
				},

				new Task
				{
					Header = "WALK",
					Note = "Alone",
				}
			};
		}
	}
}
