using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.CustomException;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 釣銭をストックするクラス
	/// </summary>
	public class ChangeStocker<T> :StockerBase<T>
		where T : IMoney
	{
		/// <summary>
		/// 最大貨幣
		/// </summary>
		private const int MAX_MONEY = 1000;

		/// <summary>
		/// 釣銭切れかどうか
		/// </summary>
		/// <returns></returns>
		public override bool IsOutOfStock()
		{
			//1枚もない場合、釣銭切れ
			if(this.Count == 0)
			{
				return false;
			}

			//最大貨幣の金額をおつりで返すのに必要な枚数を計算
			var money = this.Peek();
			decimal needCount = MAX_MONEY / money.GetPrice();

			//必要枚数より実枚数が少ない場合、釣銭切れ
			return needCount > this.Count();
		}
	}
}
