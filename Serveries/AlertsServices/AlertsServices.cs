using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Helpers;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;
using DiscoveryZoneApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static DiscoveryZoneApi.Helpers.Functions;

namespace DiscoveryZoneApi.Serveries.AlertsServices
{
    public class AlertsServices : IAlertsServices
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public AlertsServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Alerts!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Alert? alert = await GitById(typeId);

            if (alert != null)
            {
                _context.Alerts!.Remove(alert);

                await _context.SaveChangesAsync();
            }

            return alert!;
        }

        public Task<List<Alert>> GetAlertsByUserId(string userId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Alert> alerts = await _context.Alerts!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(alerts.Count / pageResults);

            var items = await alerts
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new()
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }

        public async Task<dynamic> GitById(int typeId)
        {
            Alert? alert = await _context.Alerts!.FirstOrDefaultAsync(x => x.Id == typeId);
            return alert!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<dynamic> SendNotification(Alert alert, string topic)
        {
            await _context.Alerts!.AddAsync(alert);
            await _context.SaveChangesAsync();
            FCMPushNotification result = Functions.SendNotificationFromFirebaseCloudTopic(topic, alert.TitleAr!, alert.DescriptionAr!);

            return result;
        }

        public void UpdateObject(dynamic category)
        {
            // nothing
        }

        public async Task<dynamic> ViewedAlert(int alertId)
        {
            Alert? alert = await _context.Alerts!.FirstOrDefaultAsync(t => t.Id == alertId);
            if (alert != null)
            {
                alert.Viewed = true;
                _context.SaveChanges();
            }
            return alert!;
        }


    }
}