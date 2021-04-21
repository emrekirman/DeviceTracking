using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.UnitOfWork.Interfaces;

namespace UncleProductTracking.Biz.Manager
{
    public class UnitBizManager : IUnitBiz
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitBizManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Unit Create(Unit model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                Unit unit = _unitOfWork.Unit.Create(model);
                _unitOfWork.Complete();
                return unit;
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
                _unitOfWork.Unit.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Unit> GetAll()
        {
            try
            {
                return _unitOfWork.Unit.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OptionModel<int>> GetAllUnitsFromOpt()
        {
            try
            {
                List<OptionModel<int>> retList = _unitOfWork.Unit.GetAll()
                    .Select(x => new OptionModel<int> { Label = x.Title, Value = x.Id })
                    .ToList();

                return retList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Unit GetById(int id)
        {
            try
            {
                return _unitOfWork.Unit.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Unit Update(Unit model)
        {
            try
            {
                Unit unit = _unitOfWork.Unit.Update(model);
                _unitOfWork.Complete();
                return unit;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
