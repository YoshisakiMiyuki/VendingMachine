using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// ストッククラスのインターフェース
	/// </summary>
	public interface IStocker
	{
		/// <summary>
		/// ストックから出す
		/// </summary>
		/// <returns></returns>
		object Put();

		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <returns></returns>
		bool IsOutOfStock();

		/// <summary>
		/// ストックに加える
		/// </summary>
		void Supplement(object element);
	}
}
