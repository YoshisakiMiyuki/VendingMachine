using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;
using VendingMachine.Process.Machine;
using VendingMachine.Process.Machine.Stock.Change;
using VendingMachine.Process.Machine.Stock.Drink;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 自販機の初期ストックを作成するクラス
	/// </summary>
	public class DefaultVendingStockFactory
	{
		/// <summary>
		/// 初期ストックを作成
		/// </summary>
		/// <returns></returns>
		public Vending Create()
		{
			//貨幣のストックを作成
			var changeFactory = new DefaultChangeStockFactory(new ChangeStockerFactory());
			var changeStock = changeFactory.Create();

			//ドリンクのストックを作成
			var drinkFactory = new DefaultDrinkStockFactory(new DrinkStockerFactory());
			var drinkStock = drinkFactory.Create();

			return new Vending(drinkStock,changeStock);
		}
	}
}
