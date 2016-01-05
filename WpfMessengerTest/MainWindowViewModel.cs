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

namespace WpfMessengerTest
{
	class MainWindowViewModel : ViewModel
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// WpfMessengerTest.MainWindowViewModel クラスの新しいインスタンスを作成します。
		/// </summary>
		public MainWindowViewModel()
		{
			this.Messenger = new Messenger();
			this.OnPropertyChanged("Messenger");
		}

		#endregion // コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region Messenger プロパティ

		/// <summary>
		/// メッセージを管理するオブジェクト を取得または設定します。
		/// </summary>
		public Messenger Messenger { get; private set; }

		#endregion // Messenger プロパティ
		// ------------------------------------------------------------------------------------------------------------
		public void Send()
		{
			var m = new WarningMessage(this);
			m.Message = "あけましておめでとう！";
			this.Messenger.Send(this, m);
		}
	}
}
