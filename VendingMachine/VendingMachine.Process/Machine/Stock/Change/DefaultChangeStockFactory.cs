using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock.Change
{
	/// <summary>
	/// 釣銭の初期ストックを作成するクラス
	/// </summary>
	public class DefaultChangeStockFactory : IDefaultChangeStockFactory
	{
		/// <summary>
		/// ストックを作成するクラス
		/// </summary>
		private IChangeStockerFactory _factory = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="factory"></param>
		public DefaultChangeStockFactory(IChangeStockerFactory factory)
		{
			this._factory = factory;
		}

		/// <summary>
		/// 初期ストックを作成
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public ChangeStockerContainer Create()
		{
			var container = new ChangeStockerContainer();

			//貨幣ごとのストックを作成してコンテナに入れる
			container.Supplement(typeof(Yen10), _factory.Create<Yen10>(300));
			container.Supplement(typeof(Yen50), _factory.Create<Yen50>(100));
			container.Supplement(typeof(Yen100), _factory.Create<Yen100>(50));
			container.Supplement(typeof(Yen500), _factory.Create<Yen100>(2));

			return container;
		}

	}
}
