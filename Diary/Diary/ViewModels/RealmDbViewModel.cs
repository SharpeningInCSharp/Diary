using Realms;

namespace Diary.ViewModels
{
	/// <summary>
	/// Class to work with Db
	/// </summary>
	public class RealmDbViewModel
	{
		private static readonly uint SchemaVersion = 3;

		public Realm GetDbInstance()
		{
			return Realm.GetInstance(new RealmConfiguration() { SchemaVersion = SchemaVersion });
		}
	}
}
