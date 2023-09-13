using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;

namespace DiscoveryZoneApi.Serveries.FieldsServices
{
    public interface IFieldsService
    {
        Task<BaseResponse> GetFields(string UserId,int page);


 Task<dynamic> GetAllFields();

        Task<Field> AddField(Field Field);

         Task<Field> GitFieldById(int FieldId);


        Task<Field> DeleteField(int FieldId);

        void UpdateField(Field Field);


         bool SaveChanges();
    }
}