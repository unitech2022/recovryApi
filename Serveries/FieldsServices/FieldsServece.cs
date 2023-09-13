using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using DiscoveryZoneApi.Models.BaseEntity;

using X.PagedList;

namespace DiscoveryZoneApi.Serveries.FieldsServices
{
    public class FieldsService : IFieldsService

    {


        private readonly IMapper _mapper;

        private readonly IConfiguration _config;
        private readonly AppDBcontext _context;

        public FieldsService(IMapper mapper, IConfiguration config, AppDBcontext context)
        {
            _mapper = mapper;
            _config = config;
            _context = context;
        }

        public async Task<Field> AddField(Field Field)
        {

            await _context.Fields!.AddAsync(Field);

            await _context.SaveChangesAsync();

            return Field;

        }

      
        public async Task<BaseResponse> GetFields(string UserId, int page)
        {
            List<Field> Fields = await _context.Fields!.ToListAsync();
           


            var pageResults = 10f;
            var pageCount = Math.Ceiling(Fields.Count() / pageResults);

            var items = await Fields
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;

        }

        public async Task<Field> GitFieldById(int FieldId)
        {

            Field? Field = await _context.Fields!.FirstOrDefaultAsync(x => x.Id == FieldId);
            return Field!;
        }

        public void UpdateField(Field Field)
        {


            // nothing

        }

  public async Task<Field> DeleteField(int FieldId)
        {
            Field? Field = await _context.Fields!.FirstOrDefaultAsync(x => x.Id == FieldId);

            if (Field != null)
            {
                _context.Fields!.Remove(Field);

                await _context.SaveChangesAsync();
            }

            return Field!;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<dynamic> GetAllFields()
        {
             List<Field> Fields = await _context.Fields!.ToListAsync();
             return Fields;
        }
    }
}