using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// ドリンクストックを作成するクラスのインターフェース
	/// </summary>
	public interface IDrinkStockerFactory
	{
		/// <summary>
		/// ストックを作成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		DrinkStocker<IDrink> Create<T>(int count, int price)
			where T : IDrink, new();
	}
}
