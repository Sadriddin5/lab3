using System.ComponentModel.DataAnnotations;

namespace SysProgLab3.Models
{
    /*Исходная информация содержится в двух таблицах:
1. «Прейскурант цен» (№ п/п; код товара (ключевое поле); наименование товара; цена единицы товара) - 7 строк.
2. «Учет реализации товаров» (№ п/п; дата продажи (7 разных значений); код товара; наименование товара; количество проданного товара (10 разных значений); стоимость товара) - 15 строк.
Составить в алфавитном порядке список товаров реализованных после указанной даты с указанием количества, цены и объема выручки.*/
    public class AccountingGoods
    {
        [Key]
        public long IDCounting { get; set;}    
     public required DateTime DateOfSale { get; set;}
     public long CodeGood {  get; set;}
     public required string NameGood {  get; set;}
     public required int CountOfSold { get; set;}
     public required decimal PriceGood { get; set;}
        public PriceCurant? PriceCurant { get; set;}

    }
}
