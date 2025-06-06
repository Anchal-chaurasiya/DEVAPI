using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;

namespace MyApp.BAL
{
    public class MenuService
    { 
        

        public List<UserMenuDto> GetUserMenuList(CommonRequestDto<int> commonRequest)
        {
            string proc = "Proc_GetMenu";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@userId", commonRequest.Data);
            var res = DBHelperDapper.GetAllModelList<UserMenuDto>(proc, queryParameter);
            return res;
        }
    }
}
