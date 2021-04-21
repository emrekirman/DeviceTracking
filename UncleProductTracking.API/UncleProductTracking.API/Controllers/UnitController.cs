using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBiz _unitBiz;

        public UnitController(IUnitBiz unitBiz)
        {
            this._unitBiz = unitBiz;
        }

        [HttpPost("create")]
        public ActionResult<Unit> Create(Unit model)
        {
            try
            {
                return Ok(_unitBiz.Create(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
        public ActionResult<Unit> GetAll()
        {
            try
            {
                return Ok(_unitBiz.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getById")]
        public ActionResult<Unit> GetById(int id)
        {
            try
            {
                return Ok(_unitBiz.GetById(id));
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
                _unitBiz.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("update")]
        public ActionResult<Unit> Update(Unit model)
        {
            try
            {
                return Ok(_unitBiz.Update(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAllUnitsFromOpt")]
        public ActionResult<List<OptionModel<int>>> GetAllUnitsFromOpt()
        {
            try
            {
                return Ok(_unitBiz.GetAllUnitsFromOpt());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
