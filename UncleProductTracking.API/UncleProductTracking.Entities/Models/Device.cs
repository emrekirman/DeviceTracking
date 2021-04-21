using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UncleProductTracking.Common.Enums;
using UncleProductTracking.Entities.Models.Base;

namespace UncleProductTracking.Entities.Models
{
    public class Device : BaseModel
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string ReaderSerialNumber { get; set; }

        [Required]
        public string IpNumber { get; set; }

        [Required]
        public FramType Fram { get; set; }

        [Required]
        public string Fault { get; set; }

        public string Descreption { get; set; }

        [Required]
        public ConfirmationType Confirmation { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("DeviceType")]
        public int DeviceTypeID { get; set; }

        [ForeignKey("Unit")]
        public int UnitID { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
