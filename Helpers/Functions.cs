using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DiscoveryZoneApi.Helpers
{
    public class Functions
    {
        public static double GetDistance(double Lat1,
                 double Long1, double Lat2, double Long2)
        {

            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                       Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                       Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }


        // string modle, string modleId,,NotificationData notificationData
        // public static async Task<bool> SendNotificationAsync(AppDBcontext _context, string titleAr, string titleEng, string descAr, string descEng
        // )
        // {

        //     Alert notif = new()
        //     {
        //         TitleAr = titleAr,
        //         TitleEng = titleEng,
        //         DescriptionAr = descAr,
        //         DescriptionEng = descEng,
        //         //   Modle = modle ?? "user",
        //         UserId = "",
        //         Viewed = false,
        //         // Image = user.ProfileImage ?? "a.jpg",
        //         Type = " 1",

        //     };




        //     await _context.Alerts!.AddAsync(notif);
        //     await _context.SaveChangesAsync();


        //     using (var client = new HttpClient())
        //     {
        //         var firebaseOptionsServerId = "AAAAvPS7SPE:APA91bE_ID5rnop9OMpUK02GulrdZAre4esBUXhLnFeqfRDR-RWugiRa29YvdVzT_mU6mppprbPTOGq0Vcdk5uiSf3kEi8ZoY1ui0EmoswqNxtpB-BbYq6l-uNoLLGav5qLxCOvkJCzY";

        //         client.BaseAddress = new Uri("https://fcm.googleapis.com");
        //         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //         client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
        //             $"key={firebaseOptionsServerId}");
        //         var data = new
        //         {
        //             to = token,
        //             notification = new
        //             {
        //                 body = body,
        //                 title = title,
        //             },
        //             click_action = "FLUTTER_NOTIFICATION_CLICK",
        //             priority = "high",

        //         };


        //         var json = JsonConvert.SerializeObject(data);
        //         var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //         var result = await client.PostAsync("/fcm/send", httpContent);

        //         return result.StatusCode.Equals(HttpStatusCode.OK);
        //     }
        // }

        public class FCMPushNotification
        {
            public FCMPushNotification()
            {
                // TODO: Add constructor logic here
            }

            public bool Successful
            {
                get;
                set;
            }

            public string Response
            {
                get;
                set;
            }
            public Exception Error
            {
                get;
                set;
            }
        }
        public static FCMPushNotification SendNotificationFromFirebaseCloudTopic(string topics, string titleAr, string descAr)
        {
            FCMPushNotification result = new();


            try
            {


                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //serverKey - Key from Firebase cloud messaging server  
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAo_J8wj0:APA91bFzoT91mmYfRNM0cb5cH8OM33YJRSnBKOYJ_H2P64f4YzsgD0sXdruCyAC5TAZ01lpusDR5ykK5wZQX27JE-9yZoDc9vZPl8wlVEoioDzojCiKHRr5849DLBy5ZtTNcFLRx7RCD"));
                //Sender Id - From firebase project setting  
                tRequest.Headers.Add(string.Format("Sender: id={0}", "704147931709"));
                tRequest.ContentType = "application/json";
                var payload = new
                {
                    to = "/topics/" + topics,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = descAr,
                        title = titleAr,
                        badge = 1
                    },
                    data = new
                    {
                        subject = descAr,
                        imageUrl = "",
                        desc = titleAr,
                        data = DateTime.Now.ToString()
                    }

                };

                string postbody = JsonConvert.SerializeObject(payload).ToString();
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                using WebResponse tResponse = tRequest.GetResponse();
                using Stream dataStreamResponse = tResponse.GetResponseStream();
                if (dataStreamResponse != null) using (StreamReader tReader = new(dataStreamResponse))
                    {
                        String sResponseFromServer = tReader.ReadToEnd();
                        result.Response = sResponseFromServer;
                    }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }
            return result;






        }

    }
}