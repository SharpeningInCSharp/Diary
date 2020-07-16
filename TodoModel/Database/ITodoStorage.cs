using System.Collections.Generic;

namespace TodoModel.Database
{
	/// <summary>
	/// Applies to DB's buffer
	/// Buffer stores:
	/// Priorities (IPriority) and
	/// TaskLists
	/// </summary>
	public interface ITodoStorage
	{
		/// <summary>
		/// Gives access to storing sets of:
		/// Priorities (IPriority) and
		/// TaskLists
		/// </summary>
		/// <typeparam name="TData">Required data type</typeparam>
		/// <returns>Set of <typeparamref name="TData"/></returns>
		IEnumerable<TData> Get<TData>();

		/// <summary>
		/// Add data to DB
		/// </summary>
		/// <typeparam name="TData"></typeparam>
		/// <param name="priority"></param>
		void Add<TData>(TData priority);

		/// <summary>
		/// Get data from DB
		/// </summary>
		void Refresh();

		/// <summary>
		/// Save data to DB
		/// </summary>
		void Save();
	}
}
