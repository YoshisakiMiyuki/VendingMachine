using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process.Money;

namespace VendingMachine.UI
{
	/// <summary>
	/// 支払い要求を行うクラス
	/// </summary>
	public class PaymentRequest : RequestBase<IMoney>
	{
		/// <summary>
		/// お金の支払いを要求する
		/// </summary>
		/// <returns></returns>
		protected override string InputRequest()
		{
			// コンソールで入力要求
			Console.Write("お金を投入してください。(半角英数):");
			return Console.ReadLine();
		}

		/// <summary>
		/// 文字型をお金に変換
		/// </summary>
		/// <param name="moneyStr"></param>
		/// <param name="money"></param>
		/// <returns></returns>
		protected override bool InputConvert(string str, out IMoney input)
		{
			//文字列をお金に変換
			var convertor = new MoneyConvertor();
			if (convertor.TryToMoney(str, out input) == false)
			{
				Console.WriteLine("その貨幣には対応していません。");
				return false;
			}

			return true;
		}

		
	}
}
