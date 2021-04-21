using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        private readonly IDeviceTypeBiz _deviceTypeBiz;

        public DeviceTypeController(IDeviceTypeBiz deviceTypeBiz)
        {
            _deviceTypeBiz = deviceTypeBiz;
        }

        [HttpPost("create")]
        public ActionResult<DeviceType> Create(DeviceType model)
        {
            try
            {
                return Ok(_deviceTypeBiz.Create(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getOrderDescList")]
        public ActionResult<List<DeviceType>> GetOrderDesc()
        {
            try
            {
                return Ok(_deviceTypeBiz.GetCreatedDateOrderDescList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
        public ActionResult<List<DeviceType>> GetAll()
        {
            try
            {
                return Ok(_deviceTypeBiz.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getById")]
        public ActionResult<DeviceType> GetById(int id)
        {
            try
            {
                return Ok(_deviceTypeBiz.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deviceTypeBiz.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("update")]
        public ActionResult<DeviceType> Update(DeviceType model)
        {
            try
            {
                return Ok(_deviceTypeBiz.Update(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
