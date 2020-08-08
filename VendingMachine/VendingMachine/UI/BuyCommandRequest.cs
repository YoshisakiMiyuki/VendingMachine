using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendingMachine.UI.BuyCommandRequest;

namespace VendingMachine.UI
{
	/// <summary>
	/// 購入処理の行動選択を要求するクラス
	/// </summary>
	public class BuyCommandRequest : RequestBase<BuyCommandType>
	{
		/// <summary>
		/// 行動タイプ
		/// </summary>
		public enum BuyCommandType
		{
			None,
			Pay,
			SelectDrink,
			ReturnChange,
			Cancel,
		}

		/// <summary>
		/// 行動選択を要求
		/// </summary>
		protected override string InputRequest()
		{
			Console.WriteLine("行動を選んでください。");
			Console.Write("1.お金を支払う  2.飲み物を選ぶ  3.おつりを受け取る  4.やめる:");
			return Console.ReadLine();
		}

		/// <summary>
		/// 文字列を行動タイプに変換
		/// </summary>
		/// <param name="str"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		protected override bool InputConvert(string str, out BuyCommandType input)
		{
			//変換できない、タイプなしの場合、失敗
			bool isSuccess = Enum.TryParse(str, out input);
			if (!isSuccess || !Enum.IsDefined(typeof(BuyCommandType), input) || input == BuyCommandType.None)
			{
				Console.WriteLine("その行動は選択できません。");
				return false;
			}

			return true;
		}

		
	}
}
