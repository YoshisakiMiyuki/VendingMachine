using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 複数のドリンクストックを持つクラスのインターフェース
	/// </summary>
	public interface IDrinkStockerContainer
	{
		/// <summary>
		/// ストックからドリンクを出す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		IDrink Put<T>()
			where T : IDrink, new();

		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <returns></returns>
		bool IsOutOfStock<T>()
			where T : IDrink, new();

		/// <summary>
		/// ストックしているドリンク一覧を取得する
		/// </summary>
		List<Type> GetStockDrinkLsit();

		/// <summary>
		/// 在庫切れのドリンク一覧を取得する
		/// </summary>
		/// <returns></returns>
		List<Type> GetOutOfDrinkList();
	}
}
