using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Common.Enums.CheckManda;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Interfaces;

namespace UncleProductTracking.Biz.Manager
{
    public class UserBizManager : IUserBiz
    {
        private readonly IUserRepo _repo;

        public UserBizManager(IUserRepo repo)
        {
            _repo = repo;
        }

        public void CheckManda(User model, JobType jobType)
        {
            try
            {
                if (jobType == JobType.Create || jobType == JobType.Update)
                {
                    if (string.IsNullOrEmpty(model.FirstName))
                    {
                        throw new Exception("Adınız alanı boş bırakılamaz");
                    }
                    if (string.IsNullOrEmpty(model.LastName))
                    {
                        throw new Exception("Soyadınız alanı boş bırakılamaz");
                    }
                }

                if (jobType == JobType.Delete)
                {
                    if (model.Id <= 0)
                    {
                        throw new Exception("Silinecek kullanıcı bulunamadı");
                    }
                }

                if (string.IsNullOrEmpty(model.UserName))
                {
                    throw new Exception("Soyadınız alanı boş bırakılamaz");
                }
                if (string.IsNullOrEmpty(model.UserName))
                {
                    throw new Exception("Soyadınız alanı boş bırakılamaz");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Create(User model)
        {
            try
            {
                this.CheckManda(model, JobType.Create);
                return _repo.Create(model);
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
                _repo.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _repo.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _repo.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                username = username.Trim();
                password = password.Trim();
                return _repo.GetUserByUsernameAndPassword(username, password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Update(User model)
        {
            try
            {
                this.CheckManda(model, JobType.Update);
                return _repo.Update(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
