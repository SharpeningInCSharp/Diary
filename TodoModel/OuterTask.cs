using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections;
using System.Collections.Generic;
using TodoModel.Database;

namespace TodoModel
{
	public partial class OuterTask : TaskBase
	{
		private readonly List<TaskBase> innerTasks = new List<TaskBase>();

		/// <summary>
		/// This prop return only values, DON'T use it to change object!
		/// </summary>
		public IEnumerable<TaskBase> InnerTasks => new List<TaskBase>(innerTasks);

		public OuterTask() : base()
		{ }

		//public OuterTask(int id) : base()
		//{
		//	Id = id;
		//}

		public void Add(Task task)
		{
			innerTasks.Add(task ?? throw new ArgumentNullException(nameof(task)));

			task.TaskCompleted += Task_TaskCompleted;
			task.TaskDeleted += Task_TaskDeleted;

			OnPropertyChanged("InnerTasks");
		}

		private void Task_TaskDeleted(TaskBase task)
		{
			innerTasks.Remove(task);

			OnPropertyChanged("InnerTasks");
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			innerTasks.Remove(task);

			OnPropertyChanged("InnerTasks");
		}

		public OuterTask(TodoNote task)
        {
			Header = task.header;
			Note = task.Note;
			Priority = new Priority(task.Priority);
			if(task.HasInners) 
			foreach(TodoNote inner in task.InnerNotes)
            {
					Add(new Task()
					{
						Header = inner.header,
						Note = inner.Note,
						Priority = new Priority(inner.Priority)
					});
            }
        }
	}

	public partial class OuterTask : IEnumerable<TaskBase>
	{
		public IEnumerator<TaskBase> GetEnumerator()
		{
			return innerTasks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerTasks.GetEnumerator();
		}
	}
}
