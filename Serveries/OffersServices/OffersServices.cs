using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;
using DiscoveryZoneApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DiscoveryZoneApi.Serveries.OffersServices
{
    public class OffersServices : IOffersServices
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public OffersServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Offers!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Offer? Offer = await GitById(typeId);

            if (Offer != null)
            {
                _context.Offers!.Remove(Offer);

                await _context.SaveChangesAsync();
            }

            return Offer!;
        }

        public Task<List<Offer>> GetOffersByUserId(string userId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Offer> Offers = await _context.Offers!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(Offers.Count() / pageResults);

            var items = await Offers
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

        public async Task<dynamic> GitById(int typeId)
        {
            Offer? Offer = await _context.Offers!.FirstOrDefaultAsync(x => x.Id == typeId);
            return Offer!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            // nothing
        }

        public async Task<Offer> UpdateOfferStatus(int status, int id)
        {
            Offer? offer = await _context.Offers!.FirstOrDefaultAsync(t => t.Id == id);

            if (offer != null)
            {
                offer.Status = status;
                await _context.SaveChangesAsync();
            }
            return offer!;
        }

        public async Task<Offer> UpdateOffer(string image, string DescAr, int id, int order)
        {
            Offer? offer = await _context.Offers!.FirstOrDefaultAsync(t => t.Id == id);
            if (image != null && offer!.Image != image)
            {

                offer.Image = image;
            }

            if (DescAr != null && offer!.DescAr != DescAr)
            {

                offer.DescAr = DescAr;
            }

        
            if (offer!.Order != order)
            {

                offer.Order = order;
            }

            await _context.SaveChangesAsync();
            return offer;
        }
    }
}