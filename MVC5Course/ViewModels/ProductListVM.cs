using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class ProductListVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "請輸入商品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "商品金額只能介於 0 ~ 999 之間")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public Nullable<decimal> Stock { get; set; }

    }
}