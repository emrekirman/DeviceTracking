using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Interfaces;
using UncleProductTracking.Repo.UnitOfWork.Interfaces;

namespace UncleProductTracking.Biz.Manager
{
    public class DeviceTypeBizManager : IDeviceTypeBiz
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceTypeBizManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DeviceType Create(DeviceType model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                DeviceType deviceType = _unitOfWork.DeviceType.Create(model);
                _unitOfWork.Complete();
                return deviceType;
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
                _unitOfWork.DeviceType.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DeviceType> GetAll()
        {
            try
            {
                return _unitOfWork.DeviceType.GetAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public DeviceType GetById(int id)
        {
            try
            {
                return _unitOfWork.DeviceType.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DeviceType> GetCreatedDateOrderDescList()
        {
            try
            {
                return _unitOfWork.DeviceType.GetCreatedDateOrderDescList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DeviceType Update(DeviceType model)
        {
            try
            {
                DeviceType deviceType = _unitOfWork.DeviceType.Update(model);
                _unitOfWork.Complete();
                return deviceType;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
