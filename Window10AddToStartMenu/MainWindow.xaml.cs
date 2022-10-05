using System;
using System.IO;
using System.Reflection;
using System.Windows;
using CommonWpf;
using CommonWpf.Classes.UI;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace Window10AddToStartMenu
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string shortcutAddress;

		public MainWindow()
		{
			this.InitializeComponent();

			this.CheckRegister();
		}

		private void CheckRegister()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
			this.shortcutAddress = Path.Combine(path, "Send to Start Menu.lnk");

			if (File.Exists(this.shortcutAddress))
			{
				this.PanelRegister.Visibility = Visibility.Collapsed;
				this.PanelRegistered.Visibility = Visibility.Visible;
			}
			else
			{
				this.PanelRegister.Visibility = Visibility.Visible;
				this.PanelRegistered.Visibility = Visibility.Collapsed;
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
        }

		private void RegButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string folder = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);

				string appPath = Assembly.GetExecutingAssembly().Location;
				CreateShortcut(appPath, this.shortcutAddress, "Send to \"Start Menu\"");

				this.CheckRegister();
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
		}

		public static void CreateShortcut(string appPath, string shortcutPath, string descr)
		{
			WshShell shell = new WshShell();

			IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
			shortcut.Description = descr;
			shortcut.TargetPath = appPath;
			shortcut.Save();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				File.Delete(this.shortcutAddress);
				this.CheckRegister();
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
		}
	}
}
