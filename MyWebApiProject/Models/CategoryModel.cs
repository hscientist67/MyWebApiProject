using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class CategoryModel
    {
        [DisplayName("Başlık"),Required(ErrorMessage ="{0} boş geçilemez"), MaxLength(15,ErrorMessage ="{0} max {1} karakter olabilir.")]
        public string Title { get; set; }
        [DisplayName("Açıklama"),Required(ErrorMessage ="{0} boş geçilemez"),MaxLength(50, ErrorMessage = "{0} max {1} karakter olabilir.")]
        public string Description { get; set; }
    }
}
