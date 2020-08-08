using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.CustomException;
using VendingMachine.Process.Drink;
using VendingMachine.Process.Machine.Stock;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine
{
	/// <summary>
	/// 会計を行うクラス
	/// </summary>
	public class AccountingMachine
	{
		/// <summary>
		/// 代金の合計
		/// </summary>
		private int _payment;

		//釣銭をストックするクラス
		private ChangeStockerContainer _changeStockerContainer = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AccountingMachine(ChangeStockerContainer changeStocker)
		{
			this._changeStockerContainer = changeStocker;
		}

		/// <summary>
		/// 代金を預かる
		/// </summary>
		/// <param name="money"></param>
		public void KeepPayment(IMoney money)
		{
			this._changeStockerContainer.Supplement(money);
			this._payment += money.GetPrice();
		}

		/// <summary>
		/// 購入処理
		/// </summary>
		public void Buy(int price)
		{
			//投入金額が商品金額より小さい場合、代金不足エラーを発生させる
			if(this._payment < price)
			{
				throw new ShortPaidException();
			}

			this._payment -= price;
		}

		/// <summary>
		/// おつりを返す
		/// </summary>
		/// <returns></returns>
		public List<IMoney> ReturnChange()
		{
			var calculator = new ChangeCalculator(this._changeStockerContainer);
			var change = calculator.ReturnChange(this._payment);
			CleatPayment();
			return change;
		}

		/// <summary>
		/// 代金を初期化
		/// </summary>
		private void CleatPayment()
		{
			this._payment = 0;
		}

		/// <summary>
		/// 現在の代金を表示
		/// </summary>
		/// <returns></returns>
		public int DispPayment()
		{
			return this._payment;
		}
	}
}
