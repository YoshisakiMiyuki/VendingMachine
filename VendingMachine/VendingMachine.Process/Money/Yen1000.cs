using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Process.Money
{
	/// <summary>
	/// 1000円札クラス
	/// </summary>
	public class Yen1000 : IBill
	{
		/// <summary>
		/// 金額を返す
		/// </summary>
		/// <returns></returns>
		public int GetPrice()
		{
			return 1000;
		}
	}
}
