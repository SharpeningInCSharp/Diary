using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
	public enum MenuItemType
	{
		Account,
		Tasks,
		About
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
