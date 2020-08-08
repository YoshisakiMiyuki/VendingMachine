using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock.Drink
{
	/// <summary>
	/// ドリンクの初期ストックを作成するクラス
	/// </summary>
	public class DefaultDrinkStockFactory : IDefaultDrinkStockFactory
	{
		private IDrinkStockerFactory _factory = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="factory"></param>
		public DefaultDrinkStockFactory(IDrinkStockerFactory factory)
		{
			this._factory = factory;
		}

		/// <summary>
		/// 初期ストックを作成
		/// </summary>
		/// <returns></returns>
		public DrinkStockerContainer Create()
		{
			var container = new DrinkStockerContainer();

			//ドリンクごとのストックを作成してコンテナに入れる
			container.Supplement(typeof(Cola), _factory.Create<Cola>(3, 120));
			container.Supplement(typeof(IceTea), _factory.Create<IceTea>(2, 100));

			return container;
		}
	}
}
