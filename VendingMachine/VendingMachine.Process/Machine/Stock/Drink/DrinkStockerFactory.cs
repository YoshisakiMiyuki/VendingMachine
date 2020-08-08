using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// ストックを作成するクラス
	/// </summary>
	public class DrinkStockerFactory : IDrinkStockerFactory
	{
		/// <summary>
		/// ストックを作成
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="count"></param>
		/// <returns></returns>
		public DrinkStocker<IDrink> Create<T>(int count, int price)
			where T : IDrink, new()
		{
			//ストックを作成して指定個数分補充する
			var stocker = new DrinkStocker<IDrink>(price);
			for (int i = 0; i < count; i++)
			{
				stocker.Enqueue(new T());
			}

			return stocker;
		}
	}
}
