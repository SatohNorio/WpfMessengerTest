﻿using System;
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
	/// <summary>
	/// メッセージに対応する処理を管理するクラスを定義します。
	/// </summary>
	public class MessageAction : IMessageAction
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// WpfMessengerTest.MessageAction クラスの新しいインスタンスを作成します。
		/// </summary>
		public MessageAction()
		{
		}

		#endregion // コンストラクタ
		// ------------------------------------------------------------------------------------------------------------

		public void ShowMessage(WarningMessage message)
		{
			MessageBox.Show(message.Message);
		}

		/// <summary>
		/// Messenger にアクションを登録します。
		/// </summary>
		/// <param name="recipient">メッセージを受け取るオブジェクト を指定します。</param>
		/// <param name="messenger">メッセージを管理するメッセンジャーオブジェクト を指定します。</param>
		public void Register(FrameworkElement recipient, Messenger messenger)
		{
			messenger.Register<WarningMessage>(recipient, ShowMessage);
		}
	}
}
