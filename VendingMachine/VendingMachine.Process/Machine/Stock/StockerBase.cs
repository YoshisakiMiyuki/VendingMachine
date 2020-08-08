using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// ストッククラスの親クラス
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class StockerBase<T> : Queue<T> ,IStocker
	{
		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <returns></returns>
		public virtual bool IsOutOfStock()
		{
			return this.Count == 0;
		}

		/// <summary>
		/// ストックから要素を出す
		/// </summary>
		/// <returns></returns>
		public object Put()
		{
			//古い要素から出す
			return this.Dequeue();
		}

		/// <summary>
		/// ストックに要素を加える
		/// </summary>
		/// <param name="element"></param>
		public void Supplement(object element)
		{
			this.Enqueue((T)element);
		}
	}
}
