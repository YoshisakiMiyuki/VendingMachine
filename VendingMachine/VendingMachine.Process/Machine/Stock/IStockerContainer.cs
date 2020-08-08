using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 複数のストックを持つクラスのインターフェース
	/// </summary>
	public interface IStockerContainer<T>
	{
		/// <summary>
		/// ストックから要素を出す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T Put(Type type);

		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <returns></returns>
		bool IsOutOfStock(Type type);
	}
}
