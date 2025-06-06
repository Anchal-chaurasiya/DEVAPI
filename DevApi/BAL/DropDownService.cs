using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Common;
using Dapper;
namespace MyApp.BAL
{
    public static class DropDownService
    {
        public static List<DropDownDto> BindDropDown(int ProcId, int ParentId)
        {
            List<DropDownDto> res = new List<DropDownDto>();
            string _proc = "Proc_BindAllDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", ProcId);
            queryparameter.Add("@ParentId", ParentId);
            res = DBHelperDapper.GetAllModelList<DropDownDto>(_proc, queryparameter);
            return res;
        }
    }
}
