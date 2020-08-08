using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.UI
{
	/// <summary>
	/// ドリンクの選択を要求するクラス
	/// </summary>
	public class DrinkSelectRequest : RequestBase<Type>
	{
		/// <summary>
		/// 選択できるドリンクのリスト
		/// </summary>
		private List<Type> _drinkMenu = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="drinkMenu"></param>
		public DrinkSelectRequest(List<Type> drinkMenu)
		{
			this._drinkMenu = drinkMenu;
		}

		/// <summary>
		/// ドリンクの選択を要求する
		/// </summary>
		/// <returns></returns>
		protected override string InputRequest()
		{
			Console.WriteLine("購入するドリンクを選択してください。");
			for(int i = 0; i < _drinkMenu.Count; i++)
			{
				var sampleDrink = (IDrink)Activator.CreateInstance(_drinkMenu[i]);
				Console.Write(i + 1 + "." + sampleDrink.GetName() + "  ");
			}
			Console.Write(":");
			return Console.ReadLine();
		}

		/// <summary>
		/// 文字列をドリンクタイプに変換
		/// </summary>
		/// <param name="str"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		protected override bool InputConvert(string str, out Type input)
		{
			input = null;
			bool isSuccess = int.TryParse(str, out int num);
			
			//変換できない、メニューにない番号の場合、失敗
			if(!isSuccess || _drinkMenu.Count < num || num  < 1)
			{
				Console.WriteLine("そのドリンクは選択できません。");
				return false;
			}

			//変換成功の場合、メニューからドリンクを出す
			input = _drinkMenu[num-1];
			return true;
		}

	}
}
