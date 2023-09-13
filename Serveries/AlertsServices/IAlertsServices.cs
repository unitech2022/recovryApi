using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Core;
using DiscoveryZoneApi.Models;

namespace DiscoveryZoneApi.Serveries.AlertsServices
{
    public interface IAlertsServices :BaseInterface
    {
        //  Task<AlertResponse> GetAlertsByUserId(string userId);
          Task<dynamic> ViewedAlert(int alertId);
    }
}