using Microsoft.EntityFrameworkCore;
using System;

namespace SysProgLab3.Models
{
    public static class SeedData
    { /*Исходная информация содержится в двух таблицах:
1. «Прейскурант цен» (№ п/п; код товара (ключевое поле); наименование товара; цена единицы товара) - 7 строк.
2. «Учет реализации товаров» (№ п/п; дата продажи (7 разных значений); код товара; наименование товара; количество проданного товара (10 разных значений); стоимость товара) - 15 строк.
Составить в алфавитном порядке список товаров реализованных после указанной даты с указанием количества, цены и объема выручки.*/
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.PriceCurants.Count() == 0 &&
               context.AccountingGoods.Count() == 0)
            {
                PriceCurant p1 = new PriceCurant {NameGood="Water", PriceGood=40};
                PriceCurant p2 = new PriceCurant { NameGood = "IceCream", PriceGood = 140 };
                PriceCurant p3 = new PriceCurant { NameGood = "Salt", PriceGood = 70 };
                PriceCurant p4 = new PriceCurant { NameGood = "Sugar", PriceGood = 100 };
                PriceCurant p5 = new PriceCurant { NameGood = "Milk", PriceGood = 80 };
                PriceCurant p6 = new PriceCurant { NameGood = "Butter", PriceGood = 200 };
                PriceCurant p7 = new PriceCurant { NameGood = "Bread", PriceGood = 70 };
                context.PriceCurants.Add(p1);
                context.PriceCurants.Add(p2);
                context.PriceCurants.Add(p3);
                context.PriceCurants.Add(p4);
                context.PriceCurants.Add(p5);
                context.PriceCurants.Add(p6);
                context.PriceCurants.Add(p7);
                context.AccountingGoods.AddRange(
                    new AccountingGoods { CodeGood = 01, CountOfSold = 23, NameGood = "Water", DateOfSale = new DateTime(2024, 12, 10), PriceGood = 60, },
                      new AccountingGoods { CodeGood = 02, CountOfSold = 23, NameGood = "IceCream", DateOfSale = new DateTime(2024, 12, 10), PriceGood = 60, },
                      new AccountingGoods { CodeGood = 03, CountOfSold = 12, NameGood = "Salt", DateOfSale = new DateTime(2024, 12, 11), PriceGood = 80 },
                      new AccountingGoods { CodeGood = 04, CountOfSold = 43, NameGood = "Sugar", DateOfSale = new DateTime(2024, 12, 12), PriceGood = 110 },
                      new AccountingGoods { CodeGood = 05, CountOfSold = 73, NameGood = "Milk", DateOfSale = new DateTime(2024, 12, 13), PriceGood = 90 },
                      new AccountingGoods { CodeGood = 06, CountOfSold = 22, NameGood = "Butter", DateOfSale = new DateTime(2024, 12, 14), PriceGood = 210 },
                      new AccountingGoods { CodeGood = 07, CountOfSold = 34, NameGood = "Bread", DateOfSale = new DateTime(2024, 12, 15), PriceGood = 80 },
                      new AccountingGoods { CodeGood = 01, CountOfSold = 41, NameGood = "Water", DateOfSale = new DateTime(2024, 12, 16), PriceGood = 50 },
                      new AccountingGoods { CodeGood = 02, CountOfSold = 69, NameGood = "IceCream", DateOfSale = new DateTime(2024, 12, 17), PriceGood = 150 },
                      new AccountingGoods { CodeGood = 03, CountOfSold = 100, NameGood = "Salt", DateOfSale = new DateTime(2024, 12, 16), PriceGood = 80 },
                      new AccountingGoods { CodeGood = 04, CountOfSold = 100, NameGood = "Sugar", DateOfSale = new DateTime(2024, 12, 15), PriceGood = 110 },
                      new AccountingGoods { CodeGood = 05, CountOfSold = 43, NameGood = "Milk", DateOfSale = new DateTime(2024, 12, 14), PriceGood = 90 },
                      new AccountingGoods { CodeGood = 06, CountOfSold = 23, NameGood = "Butter", DateOfSale = new DateTime(2024, 12, 10), PriceGood = 210 },
                      new AccountingGoods { CodeGood = 07, CountOfSold = 23, NameGood = "Bread", DateOfSale = new DateTime(2024, 12, 12), PriceGood = 80 },
                       new AccountingGoods { CodeGood = 07, CountOfSold = 23, NameGood = "Bread", DateOfSale = new DateTime(2024, 12, 12), PriceGood = 80 }
                    );
                //AccountingGoods ag1 = new AccountingGoods { CodeGood = 01, CountOfSold = 23, NameGood = "Water", DateOfSale = new DateTime(2024, 12, 10), PriceGood = 60, };
               // context.AccountingGoods.Add(ag1);
                context.MyUsers.Add(new MyUser { Login = "user1", Password = "pass" });
                context.SaveChanges();
            }
        }
    }
}
