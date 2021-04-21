using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces.Base;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Report.Interfaces;

namespace UncleProductTracking.Biz.Interfaces
{
    public interface IDeviceBiz : IBaseBiz<Device>,IDeviceReport
    {
        List<OptionModel<DateTime>> GetDates(List<Device> list);


    }
}
