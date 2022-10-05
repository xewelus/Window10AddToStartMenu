using System;
using System.IO;
using System.Windows;
using CommonWpf;
using CommonWpf.Classes;
using CommonWpf.Classes.UI;

namespace Window10AddToStartMenu
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		public App()
		{
			AppInitializer.Initialize();
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			try
			{
				if (e.Args.Length > 0)
				{
					string appPath = e.Args[0];

					string startFolder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
					string fileName = Path.GetFileName(appPath);
					string shortcutPath = Path.Combine(startFolder, fileName + ".lnk");

					if (File.Exists(shortcutPath))
					{
						UIHelper.ShowMessage($"Shortcut '{shortcutPath}' already exists.");
						return;
					}

					Window10AddToStartMenu.MainWindow.CreateShortcut(appPath, shortcutPath, "TEST");

					UIHelper.ShowMessage(shortcutPath);
					Environment.Exit(0);
					return;
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
		}
	}
}
