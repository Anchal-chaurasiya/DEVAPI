using DevApi.Models;
using DevApi.Models.Common;
using Dapper;
using System;
using System.Collections.Generic;
using MyApp.Models;

namespace DevApi.BAL
{
    public class CompanyService
    {
        public CommonResponseDto<ValidationMessageDto> SaveCompany(CommonRequestDto<CompanyDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var company = request.Data;
            string proc = "Proc_SaveCompany";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CompanyName", company.CompanyName);
            queryParameter.Add("@CompanyType", company.CompanyType);
            queryParameter.Add("@MobileNo", company.MobileNo);
            queryParameter.Add("@EmailId", company.EmailId);
            queryParameter.Add("@Logo", company.Logo);
            queryParameter.Add("@GSTN", company.GSTN);
            queryParameter.Add("@TIN", company.TIN);
            queryParameter.Add("@PAN", company.PAN);
            queryParameter.Add("@BAddress", company.BAddress);
            queryParameter.Add("@BAddress2", company.BAddress2);
            queryParameter.Add("@BCity", company.BCity);
            queryParameter.Add("@BStateId", company.BStateId);
            queryParameter.Add("@BCountryId", company.BCountryId);
            queryParameter.Add("@BZipCode", company.BZipCode);
            queryParameter.Add("@SAddress1", company.SAddress1);
            queryParameter.Add("@SAddress2", company.SAddress2);
            queryParameter.Add("@SCity", company.SCity);
            queryParameter.Add("@SStateId", company.SStateId);
            queryParameter.Add("@SCountryId", company.SCountryId);
            queryParameter.Add("@BZipCode1", company.BZipCode1);
            queryParameter.Add("@BankName", company.BankName);
            queryParameter.Add("@AccountHolderName", company.AccountHolderName);
            queryParameter.Add("@AccountNo", company.AccountNo);
            queryParameter.Add("@IFSCCode", company.IFSCCode);
            queryParameter.Add("@AccountType", company.AccountType);
            queryParameter.Add("@SwiftCode", company.SwiftCode);
            queryParameter.Add("@UPIId", company.UPIId);
            queryParameter.Add("@CreatedBy", company.CreatedBy);
            queryParameter.Add("@Remarks", company.Remarks);

            var result = DBHelperDapper.GetAllModelNew<CompanyDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;

            return response;
        }

        public CommonResponseDto<ValidationMessageDto> UpdateCompany(CommonRequestDto<CompanyDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var company = request.Data;
            string proc = "Proc_SaveCompany";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@CompanyGuid", company.CompanyGuid);
            queryParameter.Add("@CompanyName", company.CompanyName);
            queryParameter.Add("@CompanyType", company.CompanyType);
            queryParameter.Add("@MobileNo", company.MobileNo);
            queryParameter.Add("@EmailId", company.EmailId);
            queryParameter.Add("@Logo", company.Logo);
            queryParameter.Add("@GSTN", company.GSTN);
            queryParameter.Add("@TIN", company.TIN);
            queryParameter.Add("@PAN", company.PAN);
            queryParameter.Add("@BAddress", company.BAddress);
            queryParameter.Add("@BAddress2", company.BAddress2);
            queryParameter.Add("@BCity", company.BCity);
            queryParameter.Add("@BStateId", company.BStateId);
            queryParameter.Add("@BCountryId", company.BCountryId);
            queryParameter.Add("@BZipCode", company.BZipCode);
            queryParameter.Add("@SAddress1", company.SAddress1);
            queryParameter.Add("@SAddress2", company.SAddress2);
            queryParameter.Add("@SCity", company.SCity);
            queryParameter.Add("@SStateId", company.SStateId);
            queryParameter.Add("@SCountryId", company.SCountryId);
            queryParameter.Add("@BZipCode1", company.BZipCode1);
            queryParameter.Add("@BankName", company.BankName);
            queryParameter.Add("@AccountHolderName", company.AccountHolderName);
            queryParameter.Add("@AccountNo", company.AccountNo);
            queryParameter.Add("@IFSCCode", company.IFSCCode);
            queryParameter.Add("@AccountType", company.AccountType);
            queryParameter.Add("@SwiftCode", company.SwiftCode);
            queryParameter.Add("@UPIId", company.UPIId);
            queryParameter.Add("@IsActive", company.IsActive);
            queryParameter.Add("@ModifiedBy", company.ModifiedBy);
            queryParameter.Add("@Remarks", company.Remarks);

            var result = DBHelperDapper.GetAllModelNew<CompanyDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;

            return response;
        }

        public CommonResponseDto<List<CompanyDto>> GetCompanyList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<CompanyDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            string proc = "Proc_SaveCompany";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);

            var list = DBHelperDapper.GetAllModelList<CompanyDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<CompanyDto> GetCompanyByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<CompanyDto>();

            string proc = "Proc_SaveCompany";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@CompanyGuid", request.Data);

            var company = DBHelperDapper.GetAllModel<CompanyDto>(proc, queryParameter);
            response.Data = company;
            response.Flag = company != null ? 1 : 0;
            response.Message = company != null ? "Success" : "Not found";
            return response;
        }

        public List<CompanyDto> GetCompanyDropdown()
        {
            string proc = "Proc_SaveCompany";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 5);

            var res = DBHelperDapper.GetAllModelList<CompanyDto>(proc, queryParameter);
            return res;
        }
    }
}