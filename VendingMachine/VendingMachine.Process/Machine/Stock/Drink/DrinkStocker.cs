using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.CustomException;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// ドリンクをストックするクラス
	/// </summary>
	public class DrinkStocker<T> : StockerBase<T>
		where T : IDrink
	{
		//ストックレーンの商品の値段
		private int _price;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="price"></param>
		public DrinkStocker(int price)
		{
			this._price = price;
		}

		/// <summary>
		/// 先頭のドリンク名を取得
		/// </summary>
		/// <returns></returns>
		public string GetDrinkName()
		{
			return this.First().GetName();
		}

		/// <summary>
		/// 商品の値段
		/// </summary>
		/// <returns></returns>
		public int GetPrice()
		{
			return _price;
		}
	}
}
