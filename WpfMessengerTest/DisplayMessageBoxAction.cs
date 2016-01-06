using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Reflection;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Interactivity;

namespace WpfMessengerTest
{
	public class DisplayMessageBoxAction : TriggerAction<DependencyObject>
	{
		// ------------------------------------------------------------------------------------------------------------
		#region TriggerActionクラス 抽象メソッドの実装

		protected override void Invoke(object parameter)
		{
			var m = parameter as WarningMessage;
			if (m != null)
			{
				MessageBox.Show(m.Message);
			}
		}

		#endregion // TriggerActionクラス 抽象メソッドの実装
		// ------------------------------------------------------------------------------------------------------------
	}
}
