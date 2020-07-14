using TodoModel;
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
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			Tasks.Remove(task);
			completedTasks.Remove(task);
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

	public partial class TaskList //: IList<TaskBase>
	{
		/*public TaskBase this[int index] 
		{ 
			get => throw new NotImplementedException(); 
			set => throw new NotImplementedException(); 
		}

		public int Count => throw new NotImplementedException();

		public bool IsReadOnly => throw new NotImplementedException();

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(TaskBase item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(TaskBase[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<TaskBase> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(TaskBase item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, TaskBase item)
		{
			throw new NotImplementedException();
		}

		public bool Remove(TaskBase item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}*/
	}
}
