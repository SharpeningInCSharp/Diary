using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.ViewModels
{
	public class MenuViewModel
	{
		private static List<HomeMenuItem> menuItems = new List<HomeMenuItem>();

		public List<HomeMenuItem> GetInstance()
		{
			return menuItems;
		}

		public void Add(HomeMenuItem menuItem)
		{
			if (menuItem != null)
				menuItems.Add(menuItem);
		}

		public void Add(IEnumerable<HomeMenuItem> menuItems)
		{
			foreach(var item in menuItems)
			{
				MenuViewModel.menuItems.Add(item);
			}
		}
	}
}
