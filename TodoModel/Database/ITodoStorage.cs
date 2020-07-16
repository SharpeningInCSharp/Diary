using System.Collections.Generic;

namespace TodoModel.Database
{
	/// <summary>
	/// Applies to DB's buffer
	/// </summary>
	public interface ITodoStorage
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns>Enumeration of all available priorities</returns>
		IEnumerable<IPriority> GetPriorities();

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
