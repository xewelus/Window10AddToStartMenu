using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonWpf.Classes.UI;

namespace Window10AddToStartMenu
{
	/// <summary>
	/// Dialog for enter name.
	/// </summary>
	public partial class NameDlg : Window
	{
		public NameDlg()
		{
			this.InitializeComponent();
		}

		public string EnteredName
		{
			get
			{
				return this.NameTextBox.Text;
			}
			set
			{
				this.NameTextBox.Text = value;
			}
		}

		private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				this.OkButton.IsEnabled = !string.IsNullOrWhiteSpace(this.NameTextBox.Text);
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
        }

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.DialogResult = true;
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.DialogResult = false;
			}
			catch (Exception ex)
			{
				ExceptionHandler.Catch(ex);
			}
		}
	}
}
