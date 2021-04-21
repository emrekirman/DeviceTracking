using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Context;
using UncleProductTracking.Repo.Context.Base;
using UncleProductTracking.Repo.Interfaces;

namespace UncleProductTracking.Repo.Manager
{
    public class DeviceTypeRepoManager : BaseDbContext, IDeviceTypeRepo
    {
        public DeviceTypeRepoManager(AppDbContext db)
        {
            _db = db;
        }

        public DeviceType Create(DeviceType model)
        {
            try
            {
                DeviceType deviceType = _db.DeviceType.Add(model).Entity;
                _db.SaveChanges();
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
                DeviceType deviceType = this.GetById(id);
                _db.DeviceType.Remove(deviceType);
                _db.SaveChanges();
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
                return _db.DeviceType.ToList();
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
                return _db.DeviceType.Find(id);
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
                return _db.DeviceType.OrderByDescending(x => x.CreatedDate).ToList();
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
                DeviceType deviceType = _db.DeviceType.Update(model).Entity;
                _db.SaveChanges();
                return deviceType;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
