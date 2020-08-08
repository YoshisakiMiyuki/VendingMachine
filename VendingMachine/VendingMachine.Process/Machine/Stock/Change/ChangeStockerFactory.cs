using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 貨幣ストックを作成するクラス
	/// </summary>
	public class ChangeStockerFactory : IChangeStockerFactory
	{
		/// <summary>
		/// ストックを作成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="count"></param>
		/// <returns></returns>
		public ChangeStocker<IMoney> Create<T>(int count) 
			where T : IMoney, new()
		{
			//ストックを作成して個数分補充する
			var stocker = new ChangeStocker<IMoney>();
			for (int i = 0; i < count; i++)
			{
				stocker.Enqueue(new T());
			}

			return stocker;
		}
	}
}
