using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Interactivity;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace WpfMessengerTest
{
	/// <summary>
	/// メッセージに対応する処理を管理するインターフェースを定義します。
	/// </summary>
	public interface IMessageAction
	{
		/// <summary>
		/// Messenger にアクションを登録します。
		/// </summary>
		/// <param name="recipient">メッセージを受け取るオブジェクト を指定します。</param>
		/// <param name="messenger">メッセージを管理するメッセンジャーオブジェクト を指定します。</param>
		void Register(FrameworkElement recipient, Messenger messenger);
	}
}
