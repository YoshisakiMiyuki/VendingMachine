using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;
using VendingMachine.Process.Machine.Stock;

namespace VendingMachine.Process.Machine
{
	/// <summary>
	/// 複数のストックを持つクラスの親
	/// </summary>
	public abstract class StockerContainerBase<T> : IStockerContainer<T>
	{
		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public abstract bool IsOutOfStock(Type type);

		/// <summary>
		/// ストックから要素を出す
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public abstract T Put(Type type);

		/// <summary>
		/// ストックしている要素の型と引数の方が一致しているかチェックする
		/// </summary>
		/// <param name="type"></param>
		protected void CheckArgumentType(Type type)
		{
			//ジェネリック型を継承していない場合、例外を発生させる
			if (typeof(T).IsAssignableFrom(type)== false)
			{
				throw new ArgumentException("ストックしている型と引数の型が異なります。");
			}
		}
	}
}
