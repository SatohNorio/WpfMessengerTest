using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;

namespace WpfMessengerTest
{
	/// <summary>
	/// ViewModel と View の間のメッセージを仲介します。
	/// </summary>
	public class Messenger
	{
		/// <summary>
		/// メッセージに対応する処理のリスト を管理します。
		/// </summary>
		private List<ActionInfo> FActionList = new List<ActionInfo>();

		/// <summary>
		/// メッセージに対応する処理を登録します。
		/// </summary>
		/// <typeparam name="TMessage">メッセージの型を指定します。</typeparam>
		/// <param name="recipient">メッセージの受け取り先オブジェクトを指定します。</param>
		/// <param name="action">メッセージを受け取った時に実行する処理を指定します。</param>
		public void Register<TMessage>(FrameworkElement recipient, Action<TMessage> action) where TMessage : ViewModelMessage
		{
			this.FActionList.Add(new ActionInfo()
			{
				Type = typeof(TMessage),
				sender = recipient.DataContext as INotifyPropertyChanged,
				action = action
			});
		}

		/// <summary>
		/// メッセージを送信します。
		/// </summary>
		/// <typeparam name="TMessage">メッセージの型を指定します。</typeparam>
		/// <param name="sender">メッセージの送信元オブジェクトを指定します。</param>
		/// <param name="message">送信するメッセージを指定します。</param>
		public void Send<TMessage>(INotifyPropertyChanged sender, TMessage message) where TMessage:ViewModelMessage
		{
			var q = this.FActionList.Where(o => o.sender == sender && o.Type == message.GetType())
				.Select(o => o.action as Action<TMessage>);
			foreach (var action in q)
			{
				action(message);
			}
		}

		/// <summary>
		/// メッセージと処理を関連付けるクラスを定義します。
		/// </summary>
		private class ActionInfo
		{
			/// <summary>
			/// メッセージの種類 を取得または設定します。
			/// </summary>
			public Type Type { get; set; }

			/// <summary>
			/// メッセージの送信元オブジェクト を取得または設定します。
			/// </summary>
			public INotifyPropertyChanged sender { get; set; }

			/// <summary>
			/// メッセージに対応する処理 を取得または設定します。
			/// </summary>
			public Delegate action { get; set; }
		}
	}
}
