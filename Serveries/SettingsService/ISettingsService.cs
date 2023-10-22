
using DiscoveryZoneApi.Models;

using DiscoveryZoneApi.Models.BaseEntity;

namespace DiscoveryZoneApi.Serveries.SettingsService
{
    public interface ISettingsService
    {
        Task<BaseResponse> GetSettings(string UserId, int page);


        Task<dynamic> GetAllSettings();

        Task<Setting> AddSetting(Setting setting);

        Task<Setting> GitSettingById(int settingId);


        Task<Setting> DeleteSetting(int settingId);

        Task<Setting> UpdateSetting(string value, int settingId);


        bool SaveChanges();
    }
}