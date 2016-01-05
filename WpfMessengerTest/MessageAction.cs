using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
