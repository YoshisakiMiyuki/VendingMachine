using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Process;
using VendingMachine.Process.CustomException;
using VendingMachine.Process.Drink;
using VendingMachine.Process.Machine;
using VendingMachine.Process.Machine.Stock;
using VendingMachine.Process.Money;
using VendingMachine.UI;

namespace VendingMachine
{
	class Program
	{
		static void Main(string[] args)
		{
			List<IMoney> change = null;

			try
			{
				//自販機を用意
				var defaultFactory = new DefaultVendingStockFactory();
				var vending = defaultFactory.Create();

				//コマンド選択
				while(true)
				{
					Console.WriteLine("現在の投入金額:" + vending.DispPayment());
					var command = new BuyCommandRequest().Request();

					switch (command)
					{
						case BuyCommandRequest.BuyCommandType.Pay:
							//お金を払う
							IMoney payment = new PaymentRequest().Request();
							vending.PayMoney(payment);
							break;

						case BuyCommandRequest.BuyCommandType.SelectDrink:
							//ドリンク選ぶ
							var selectRequest = new DrinkSelectRequest(vending.GetDrinkMenu());
							Type drinkType = selectRequest.Request();
							var drink = vending.Select(drinkType);
							Console.WriteLine(drink.GetName() + "を購入しました。");
							break;

						case BuyCommandRequest.BuyCommandType.ReturnChange:
							//おつりを返す
							change = vending.ReturnChange();
							foreach (var money in change)
							{
								Console.WriteLine(money.GetPrice() + "円玉が返ってきました。");
							}
							Console.WriteLine("合計" + change.Sum(x => x.GetPrice()) + "円返って来ました");
							break;

						case BuyCommandRequest.BuyCommandType.Cancel:
							//自販機で買うのをやめる
							return;

						default:
							throw new NotSupportedException("未実装のコマンドです");
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadKey();
			}
		}
	}
}
