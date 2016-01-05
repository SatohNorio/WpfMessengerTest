using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMessengerTest
{
	/// <summary>
	/// ViewModel から View に送信するメッセージの基底クラスを定義します。
	/// </summary>
	public class ViewModelMessage
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// WpfMessengerTest.ViewModelMessage クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="sender">メッセージの送信元オブジェクトを指定します。</param>
		public ViewModelMessage(object sender)
		{
			this.Sender = sender;
		}

		#endregion // コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region Sender プロパティ

		/// <summary>
		/// 送信元オブジェクト を取得または設定します。
		/// </summary>
		public object Sender { get; protected set; }

		#endregion // Sender プロパティ
		// ------------------------------------------------------------------------------------------------------------
	}
}
