using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Process.Money
{
	/// <summary>
	/// お金の変換クラス
	/// </summary>
	public class MoneyConvertor
	{
		/// <summary>
		/// 文字型をお金クラスに変換
		/// </summary>
		/// <param name="str"></param>
		/// <param name="money"></param>
		/// <returns></returns>
		public bool TryToMoney(string str, out IMoney money)
		{
			money = null;

			//数値型に変換可能か
			int moneyNum;
			if (int.TryParse(str, out moneyNum) == false)
			{
				return false;
			}

			//お金クラスに変換可能か
			return TryToMoney(moneyNum, out money);
		}

		/// <summary>
		/// int型をお金クラスに変換
		/// </summary>
		/// <param name="num"></param>
		/// <param name="money"></param>
		/// <returns></returns>
		public bool TryToMoney(int num, out IMoney money)
		{
			money = null;

			//対応しているお金の一覧を取得
			var supportMoneyList = GetSupportedMoneyList();

			//数値をお金に変換できたら成功
			foreach (var moneyType in supportMoneyList)
			{
				bool isSuccess = ConvertMoney(num, moneyType, out IMoney temp);
				money = isSuccess ? temp : money;
			}

			return money != null;
		}

		/// <summary>
		/// int型をお金クラスに変換
		/// </summary>
		/// <param name="num"></param>
		/// <param name="moneyType"></param>
		/// <param name="money"></param>
		/// <returns></returns>
		private bool ConvertMoney(int num, Type moneyType, out IMoney money)
		{
			money = null;

			//お金タイプをインスタンス化して値を比較
			var sampleMoney = (IMoney)Activator.CreateInstance(moneyType);
			if (sampleMoney.GetPrice() == num)
			{
				money = sampleMoney;
				return true;
			}

			return false;
		}

		/// <summary>
		/// 対応しているお金のタイプ一覧を取得
		/// </summary>
		/// <returns></returns>
		private List<Type> GetSupportedMoneyList()
		{
			//貨幣クラスを実装する、抽象クラスでない型を返す
			return Assembly.GetAssembly(typeof(IMoney))
				.GetTypes()
				.Where(x => typeof(IMoney).IsAssignableFrom(x) && !x.IsAbstract)
				.ToList();
		}
	}
}
