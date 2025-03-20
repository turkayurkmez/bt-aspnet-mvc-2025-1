using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application.DataTransferObjects
{
    public class CreateNewProductRequest
    {
        [Required(ErrorMessage = "Ürün adını giriniz")]
        [StringLength(50, ErrorMessage = "Ürün adı en fazla 50 karakter olabilir")]
        [MinLength(3, ErrorMessage = "Ürün adı en az 3 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ürün açıklamasını giriniz")]
        [StringLength(250, ErrorMessage = "Ürün açıklaması en fazla 250 karakter olabilir")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

        public int Stock { get; set; } = 0;
        public string ImageUrl { get; set; }

    }
}
