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
	/// 自販機クラス
	/// </summary>
	public class Vending
	{
		//ドリンクストッククラス
		private DrinkStockerContainer _drinkStockerContainer = null;

		//会計クラス
		private AccountingMachine _accountingMachine = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Vending(DrinkStockerContainer drinkStockerContainer,  ChangeStockerContainer changeStockerContainer)
		{
			this._drinkStockerContainer = drinkStockerContainer;
			this._accountingMachine = new AccountingMachine(changeStockerContainer);
		}

		/// <summary>
		/// お金を払う
		/// </summary>
		/// <param name="money"></param>
		public void PayMoney(IMoney money)
		{
			_accountingMachine.KeepPayment(money);
		}

		/// <summary>
		/// ドリンクを選択する
		/// </summary>
		/// <returns></returns>
		public IDrink Select(Type drinkType)
		{
			//計算処理
			int price = this._drinkStockerContainer.GetDrinkPrice(drinkType);
			_accountingMachine.Buy(price);

			//ストックからドリンクを出す
			var drink = this._drinkStockerContainer.Put(drinkType);

			return drink;
		}

		/// <summary>
		/// おつりを返す
		/// </summary>
		/// <returns></returns>
		public List<IMoney> ReturnChange()
		{
			return _accountingMachine.ReturnChange();
		}

		/// <summary>
		/// ドリンクメニューを取得
		/// </summary>
		/// <returns></returns>
		public List<Type> GetDrinkMenu()
		{
			return _drinkStockerContainer.GetStockDrinkLsit();
		}

		/// <summary>
		/// 現在の代金を表示
		/// </summary>
		/// <returns></returns>
		public int DispPayment()
		{
			return _accountingMachine.DispPayment();
		}
	}
}
