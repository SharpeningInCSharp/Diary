﻿using TodoModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodoModel
{
	public partial class TaskList
	{
		/// <summary>
		/// true - в прямом направление, в обратном - false
		/// </summary>
		private bool ascending = true;

		public string Title { get; }

		public event Action CollectionChanged;

		public List<TaskBase> Tasks { get; set; } = new List<TaskBase>();
		private List<TaskBase> completedTasks = new List<TaskBase>();

		public TaskList(string name)
		{
			Title = name;
		}

		public void Add(TaskBase task)
		{
			task.TaskCompleted += Task_TaskCompleted;
			task.TaskDeleted += Task_TaskDeleted;

			Tasks.Add(task);

			CollectionChanged?.Invoke();
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			Tasks.Remove(task);
			completedTasks.Remove(task);

			CollectionChanged?.Invoke();
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			Tasks.Remove(task);
			completedTasks.Add(task);
		}

		public void OrderByPriority()
		{
			if (ascending)
			{
				Tasks.Sort();
			}
			else
			{
				Tasks.Sort();
				Tasks.Reverse();
			}

			ascending = !ascending;
		}
	}

	public partial class TaskList
	{

	}
}
