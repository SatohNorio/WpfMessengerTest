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
	/// <summary>
	/// メッセージに対応する処理を管理するクラスを格納するコレクションを定義します。
	/// </summary>
	public class MessageActionCollection : Freezable
	{
		// ------------------------------------------------------------------------------------------------------------
		#region Collection プロパティ

		/// <summary>
		/// メッセージに対応する処理を管理するクラスを格納するコレクション を管理します。
		/// </summary>
		private Collection<IMessageAction> FCollection = new Collection<IMessageAction>();

		/// <summary>
		/// メッセージに対応する処理を管理するクラスを格納するコレクション を取得します。
		/// </summary>
		public Collection<IMessageAction> Collection
		{
			get
			{
				return this.FCollection;
			}
		}

		#endregion // Collection プロパティ
		// ------------------------------------------------------------------------------------------------------------
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
			DependencyProperty.Register("SourceObject", typeof(Messenger), typeof(MessageActionCollection), new PropertyMetadata(null));

		#endregion // SourceObject プロパティ
		// ------------------------------------------------------------------------------------------------------------

		public void RegisterAll(FrameworkElement recipient)
		{
			Messenger m = this.SourceObject;
			if (m != null)
			{
				foreach (var action in this.Collection)
				{
					action.Register(recipient, m);
				}
			}
		}

		// ------------------------------------------------------------------------------------------------------------
		#region Freezableクラス 抽象メソッドの実装

		/// <summary>
		/// 基底クラスのインスタンスを作成します。
		/// </summary>
		/// <returns>作成したインスタンスを返します。</returns>
		protected override Freezable CreateInstanceCore()
		{
			return (Freezable)Activator.CreateInstance(base.GetType());
		}

		#endregion // Freezableクラス 抽象メソッドの実装
		// ------------------------------------------------------------------------------------------------------------
	}
}
