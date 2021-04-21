using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces.Base;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Context.Base;

namespace UncleProductTracking.Biz.Interfaces
{
    public interface IDeviceTypeBiz : IBaseBiz<DeviceType>
    {
        /// <summary>
        /// Eklenen cihazların tarih olarak sondan başa sıralayarak getirir.
        /// </summary>
        /// <returns></returns>
        List<DeviceType> GetCreatedDateOrderDescList();
    }
}
