using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Weather_Calendar_D20.Extensions;
using Weather_Calendar_D20.Weather.Data;
using Weather_Calendar_D20.Weather.Variation;

namespace Weather_Calendar_D20.Weather
{
    public class WeatherGenerator
    {
        #region Public Static Methods

        public static WeatherData[] GenerateWeather(DateTime? equivalentDateTime, WeatherData weather = null)
        {
            if (equivalentDateTime.HasValue)
            {
                DateTime dateTime = equivalentDateTime.Value;
                int monthIdx = dateTime.Month - 1;
                if (weather == null)
                {
                    weather = new WeatherData();
                }

                List<WeatherData> weatherDatas = WeatherData.GenerateTemperature(dateTime, weather);

                weatherDatas = FogData.GenerateFog(dateTime, weatherDatas);

                weatherDatas = WindData.GenerateWind(dateTime, weatherDatas);

                weatherDatas = PrecipitationData.GeneratePrecipitation(dateTime, weatherDatas);

                return weatherDatas.ToArray();
            }

            return null;
        }

        #endregion

    }
}
