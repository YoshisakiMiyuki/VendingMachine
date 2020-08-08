using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 貨幣ストックを作成するクラスのインターフェース
	/// </summary>
	public interface IChangeStockerFactory
	{
		/// <summary>
		/// ストックを作成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		ChangeStocker<IMoney> Create<T>(int count)
			where T : IMoney, new();
	}
}
