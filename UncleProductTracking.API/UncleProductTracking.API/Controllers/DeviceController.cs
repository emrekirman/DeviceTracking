using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        private readonly IDeviceBiz _deviceBiz;

        public DeviceController(IDeviceBiz deviceBiz)
        {
            _deviceBiz = deviceBiz; ;
        }

        [HttpPost("create")]
        public ActionResult<Device> Create(Device model)
        {
            try
            {
                return Ok(_deviceBiz.Create(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
        public ActionResult<List<Device>> GetAll()
        {
            try
            {
                return Ok(_deviceBiz.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("delete/{id}")]
        public ActionResult<Device> Delete(int id)
        {
            try
            {
                _deviceBiz.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Device> GetById(int id)
        {
            try
            {
                return Ok(_deviceBiz.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("update")]
        public ActionResult<Device> Update(Device model)
        {
            try
            {
                return Ok(_deviceBiz.Update(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAllDevice")]
        public ActionResult<List<Device>> GetAllDevice()
        {
            try
            {
                return Ok(_deviceBiz.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("getDates")]
        public ActionResult<OptionModel<DateTime>> GetDates(List<Device> list)
        {
            try
            {
                return Ok(_deviceBiz.GetDates(list));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("fillData")]
        //public ActionResult FillData()
        //{
        //    try
        //    {
        //        for (int i = 0; i < 100; i++)
        //        {
        //            _deviceBiz.Create(new Device
        //            {
        //                Confirmation = Common.Enums.ConfirmationType.Yes,
        //                CreatedDate = DateTime.Now.Date,
        //                DeviceTypeID = 5,
        //                Fault = "asdasdasd",
        //                Fram = Common.Enums.FramType.Available,
        //                IpNumber = "127.0.0.1",
        //                ReaderSerialNumber = "12313123",
        //                SerialNumber = "12323132131",
        //                UnitID = 8
        //            });
        //        }
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPost("getReportList")]
        public IActionResult GetReportList(List<Device> list)
        {
            try
            {
                MemoryStream memoryStream = _deviceBiz.ExportListExcel(list);

                return File(
                        fileContents: memoryStream.ToArray(),
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileDownloadName: $"CihazListesi-{DateTime.Now.ToString("ddMMyyyy")}"
                    );

                //return result;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost("getDeviceReport")]
        public IActionResult GetDeviceReport(Device model)
        {
            try
            {
                MemoryStream memoryStream = _deviceBiz.ExportExcel(model);

                return File(
                        fileContents: memoryStream.ToArray(),
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileDownloadName: $"CihazDetay-{DateTime.Now.ToString("ddMMyyyy")}"
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
