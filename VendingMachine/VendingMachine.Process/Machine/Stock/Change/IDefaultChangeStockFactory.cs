using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 貨幣の初期ストックを作成するクラスのインタフェース
	/// </summary>
	public interface IDefaultChangeStockFactory
	{
		/// <summary>
		/// 初期ストックを作成
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		ChangeStockerContainer Create();
	}
}
