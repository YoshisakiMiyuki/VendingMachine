using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Drink;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 複数のドリンクストックを持つクラス
	/// </summary>
	public class DrinkStockerContainer : StockerContainerBase<IDrink>
	{
		/// <summary>
		/// 複数のドリンクストック
		/// </summary>
		private Dictionary<Type, DrinkStocker<IDrink>> _container = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DrinkStockerContainer()
		{
			this._container = new Dictionary<Type, DrinkStocker<IDrink>>();
		}

		/// <summary>
		/// 在庫切れかどうか
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override bool IsOutOfStock(Type drinkType)
		{
			//引数をチェック
			CheckArgumentType(drinkType);

			return _container[drinkType].IsOutOfStock();
		}

		/// <summary>
		/// ストックからドリンクを出す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IDrink Put(Type drinkType)
		{
			//引数をチェック
			CheckArgumentType(drinkType);

			return _container[drinkType].Put() as IDrink;
		}

		/// <summary>
		/// ストックしているドリンク一覧を取得する
		/// 在庫切れも取得
		/// </summary>
		/// <returns></returns>
		public List<Type> GetStockDrinkLsit()
		{
			return _container.Keys.ToList();
		}

		/// <summary>
		/// 在庫切れのドリンク一覧を取得する
		/// </summary>
		/// <returns></returns>
		public List<Type> GetOutOfDrinkList()
		{
			var outOfDrinkList = _container.Keys.Where(x => _container[x].IsOutOfStock());
			return outOfDrinkList.ToList();
		}

		public int GetDrinkPrice(Type drinkType)
		{
			//引数をチェック
			CheckArgumentType(drinkType);

			//型が一致するストックの商品値段を取得
			var stocker = _container[drinkType];
			return stocker.GetPrice();
		}

		/// <summary>
		/// ストックレーンを追加
		/// </summary>
		/// <param name="type"></param>
		/// <param name="stocker"></param>
		public void Supplement(Type drinkType, DrinkStocker<IDrink> stocker)
		{
			_container.Add(drinkType, stocker);
		}
	}
}
