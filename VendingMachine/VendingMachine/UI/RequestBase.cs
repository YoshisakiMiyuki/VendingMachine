using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.UI
{
	/// <summary>
	/// コンソールで入力要求をするクラスの親クラス
	/// </summary>
	public abstract class RequestBase<T> : IRequest<T>
	{
		/// <summary>
		/// 入力要求
		/// </summary>
		/// <returns></returns>
		public T Request()
		{
			bool inputOK = false;
			T input = default(T);

			//正しい値が入力されるまで実行します
			while(!inputOK)
			{
				string str = InputRequest();
				inputOK = InputConvert(str, out input);

				Console.WriteLine("\n");
			}

			return input;
		}

		/// <summary>
		/// 入力要求して入力値を返す
		/// </summary>
		/// <returns></returns>
		protected abstract string InputRequest();

		/// <summary>
		/// 入力値を変換する
		/// </summary>
		/// <param name="str"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		protected abstract bool InputConvert(string str, out T input);
	}
}
