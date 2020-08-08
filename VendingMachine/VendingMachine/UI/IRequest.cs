using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.UI
{
	/// <summary>
	/// コンソールで入力要求をするクラスのインターフェース
	/// </summary>
	public interface IRequest<T>
	{
		/// <summary>
		/// コンソールで入力を要求し、入力値を返す
		/// </summary>
		/// <returns></returns>
		T Request();
	}
}
