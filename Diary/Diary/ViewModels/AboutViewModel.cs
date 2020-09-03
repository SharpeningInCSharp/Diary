using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Diary.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.dvgups.ru/"));
		}

		public ICommand OpenWebCommand { get; }
	}
}