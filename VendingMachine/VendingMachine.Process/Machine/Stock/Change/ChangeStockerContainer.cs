using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.Process.Machine.Stock
{
	/// <summary>
	/// 複数の貨幣のストックを持つクラス
	/// </summary>
	public class ChangeStockerContainer : StockerContainerBase<IMoney>
	{
		/// <summary>
		/// 複数の貨幣ストック
		/// </summary>
		private Dictionary<Type, ChangeStocker<IMoney>> _container = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeStockerContainer()
		{
			_container = new Dictionary<Type, ChangeStocker<IMoney>>();
		}

		/// <summary>
		/// 釣銭切れかどうか
		/// </summary>
		/// <returns></returns>
		public override bool IsOutOfStock(Type moneyType) 
		{
			//引数をチェック
			CheckArgumentType(moneyType);

			return _container[moneyType].IsOutOfStock();
		}

		/// <summary>
		/// 貨幣をストックから出す
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IMoney Put(Type moneyType) 
		{
			//引数をチェック
			CheckArgumentType(moneyType);

			return _container[moneyType].Put() as IMoney;
		}

		/// <summary>
		/// 貨幣をストックから出す
		/// </summary>
		/// <returns></returns>
		public List<IMoney> Put(Type moneyType, int count)
		{
			//引数をチェック
			CheckArgumentType(moneyType);

			//指定個数だけ出す
			List<IMoney> money = new List<IMoney>();

			for (int i = 0; i < count; i++)
			{
				money.Add(this.Put(moneyType));
			}

			return money;
		}

		/// <summary>
		/// 貨幣をストックに加える
		/// </summary>
		/// <param name="money"></param>
		public void Supplement(IMoney money)
		{
			_container[money.GetType()].Supplement(money);
		}

		/// <summary>
		/// ストックレーンを追加
		/// </summary>
		/// <param name="type"></param>
		/// <param name="stocker"></param>
		public void Supplement(Type moneyType, ChangeStocker<IMoney> stocker)
		{
			_container.Add(moneyType, stocker);
		}
	}
}
