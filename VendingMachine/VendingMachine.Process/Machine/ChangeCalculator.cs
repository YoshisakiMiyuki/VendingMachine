using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.CustomException;
using VendingMachine.Process.Machine.Stock;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine
{
	/// <summary>
	/// 釣銭の計算をするクラス
	/// </summary>
	public class ChangeCalculator
	{
		//釣銭をストックするクラス
		private ChangeStockerContainer _moneyStockerContainer = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="moneyStocker"></param>
		public ChangeCalculator(ChangeStockerContainer moneyStocker)
		{
			this._moneyStockerContainer = moneyStocker;
		}

		/// <summary>
		/// おつりを返す
		/// </summary>
		/// <returns></returns>
		public List<IMoney> ReturnChange(int payment)
		{
			List<IMoney> change = new List<IMoney>();

			//個数が最小限になるよう、金額が大きい貨幣から処理
			change.AddRange(PullMoney<Yen500>(ref payment));
			change.AddRange(PullMoney<Yen100>(ref payment));
			change.AddRange(PullMoney<Yen50>(ref payment));
			change.AddRange(PullMoney<Yen10>(ref payment));

			//おつりを返し切れていないなら、釣銭切れ
			if(payment > 0)
			{
				throw new OutOfChangeException();
			}

			return change;
		}

		/// <summary>
		/// ストックからおつりを出す
		/// </summary>
		/// <typeparam name="MoneyType"></typeparam>
		/// <param name="payment"></param>
		/// <returns></returns>
		private List<IMoney> PullMoney<MoneyType>(ref int payment)
			where MoneyType : IMoney, new()
		{
			//おつりをストックから出す
			int count = CalcMoneyCount<MoneyType>(payment);
			var moneies = _moneyStockerContainer.Put(typeof(MoneyType), count);

			//代金から出した分を差し引く
			payment -= moneies.Sum(x => x.GetPrice());

			return moneies;
		}

		/// <summary>
		/// 返却する貨幣の個数を計算する
		/// </summary>
		/// <param name="payment"></param>
		/// <returns></returns>
		private int CalcMoneyCount<MoneyType>(int payment)
			where MoneyType : IMoney, new()
		{
			var sampleMoney = new MoneyType();
			decimal div = payment / sampleMoney.GetPrice();
			int count = (int)Math.Floor(div);

			return count;
		}
	}
}
