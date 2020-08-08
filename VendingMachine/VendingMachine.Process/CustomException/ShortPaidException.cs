using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Process.CustomException
{
	/// <summary>
	/// 代金不足エラー
	/// </summary>
	public class ShortPaidException : Exception
	{
		public override string Message => "代金が不足しています！";
	}
}
