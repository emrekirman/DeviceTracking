using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.UnitOfWork.Interfaces;
using UncleProductTracking.Report.Interfaces;

namespace UncleProductTracking.Biz.Manager
{
    public class DeviceBizManager : IDeviceBiz
    {
        private readonly IDeviceReport _report;

        private readonly IUnitOfWork _unitOfWork;

        public DeviceBizManager(IDeviceReport report, IUnitOfWork unitOfWork)
        {
            _report = report;
            _unitOfWork = unitOfWork;
        }

        public Device Create(Device model)
        {
            try
            {
                Device entity = _unitOfWork.Device.Create(model);
                _unitOfWork.Complete();
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.Device.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MemoryStream ExportExcel(Device model)
        {
            try
            {
                return _report.ExportExcel(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MemoryStream ExportListExcel(List<Device> list)
        {
            try
            {
                return _report.ExportListExcel(list);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Device> GetAll()
        {
            try
            {
                List<Device> list = _unitOfWork.Device.GetAll();
                foreach (var item in list)
                {
                    item.CreatedDate = item.CreatedDate.Date;
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Device GetById(int id)
        {
            try
            {
                return _unitOfWork.Device.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OptionModel<DateTime>> GetDates(List<Device> list)
        {
            try
            {
                Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
                List<OptionModel<DateTime>> retList = new List<OptionModel<DateTime>>();

                foreach (var item in list)
                {
                    string key = item.CreatedDate.ToString("dd.MM.yyyy");
                    DateTime value = item.CreatedDate.Date;

                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = value;
                    }
                }

                foreach (var item in dict)
                {
                    retList.Add(new OptionModel<DateTime>
                    {
                        Label = item.Key,
                        Value = item.Value
                    });
                }

                return retList.OrderByDescending(x => x.Value).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Device Update(Device model)
        {
            try
            {
                return _unitOfWork.Device.Update(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
