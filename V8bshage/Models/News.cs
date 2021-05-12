using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace V8bshage.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public byte[] Photo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
    }
}
