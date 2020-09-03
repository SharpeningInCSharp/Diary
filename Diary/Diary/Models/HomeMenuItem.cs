namespace Diary.Models
{
    public enum MenuItemType
	{
		Account,
		TaskList,
		Tasks,
		About
	}
	public class HomeMenuItem
	{
		public string Id { get; set; }

		public string Title { get; set; }
	}
}
