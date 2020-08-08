using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock.Drink
{
	/// <summary>
	/// ドリンクの初期ストックを作成するクラスのインタフェース
	/// </summary>
	public interface IDefaultDrinkStockFactory
	{
		/// <summary>
		/// 初期ストックを作成
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		DrinkStockerContainer Create();
	}
}
