using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace V8bshage.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvId { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Фото")]
        public byte[] Photo { get; set; }
        public string UserId { get; set; }
    }
}
