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
	public class WarningMessageTrigger:TriggerBase<FrameworkElement>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			var m = this.SourceObject;
			if (m!=null)
			{
				m.Register<WarningMessage>(this.AssociatedObject, (msg) => this.InvokeActions(msg));
			}
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
		}

		// ------------------------------------------------------------------------------------------------------------
		#region SourceObject プロパティ（依存関係プロパティ）

		/// <summary>
		/// メッセージを管理するオブジェクト を取得または設定します。
		/// </summary>
		public Messenger SourceObject
		{
			get { return (Messenger)GetValue(SourceObjectProperty); }
			set { SetValue(SourceObjectProperty, value); }
		}

		/// <summary>
		/// メッセージを管理するオブジェクト を管理する依存関係プロパティ
		/// </summary>
		public static readonly DependencyProperty SourceObjectProperty =
			DependencyProperty.Register("SourceObject", typeof(Messenger), typeof(WarningMessageTrigger), new PropertyMetadata(null));

		#endregion // SourceObject プロパティ
		// ------------------------------------------------------------------------------------------------------------
	}
}
