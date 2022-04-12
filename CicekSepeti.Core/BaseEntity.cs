using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Core.Models.Product
{
    public class BaseEntity
    {       
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateByUser { get; set; }
        public DateTime? ModifyDateTime { get; set; }
        public string ModifyByUser { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeleteDateTime { get; set; }

    }
}
