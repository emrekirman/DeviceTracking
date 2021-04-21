using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UncleProductTracking.Entities.Models.Base;

namespace UncleProductTracking.Report.Base
{
    public interface IBaseReport<T> where T : BaseModel
    {
        MemoryStream ExportExcel(T model);

        MemoryStream ExportListExcel(List<T> list);
    }
}
