using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UncleProductTracking.Entities.Models.Base;

namespace UncleProductTracking.Entities.Models
{
    public class DeviceType : BaseModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
