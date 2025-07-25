﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevApi.Models.Common;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class UserDto:BaseDto
    {
        public Guid UserGuid { get; set; }
        public long UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
    }

    public class UserReqDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
         
        
    }
    public class UserResponseDto : ValidationMessageDto
    {
        public Guid UserGuid { get; set; }
        public long UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public int CompanyCount { get; set; }
        public bool IsSingleUser { get; set; } 
        public Guid SessionToken{ get; set; } 
        public Guid MCompanyGuid { get; set; } 
        public DateTime LastLogin{ get; set; } 
        public string SubscriptionDays { get; set; } 
    }
}
