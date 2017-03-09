using System;

namespace JF.CoreLibrary.LBS
{
    /// <summary>
    /// 表示一个地理坐标
    /// </summary>
    [Serializable]
    public class Location
    {
        #region 属性成员

        /// <summary>
        /// 获取或设置纬度值。
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置经度值。
        /// </summary>
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// 获取海拔高度。 
        /// 以米为单位，可以是负数，0，正数，或 NaN, ; 如果未知。
        /// </summary>
        public double Altitude
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前坐标所属坐标系。
        /// </summary>
        public LocationSeries Series
        {
            get;
            private set;
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化<see cref="Location"/>类的新实例。
        /// 从经度、纬度、海拔高度、地理坐标协调系列。
        /// </summary>
        /// <param name="latitude">纬度值。范围可以是从 -90.0 到 90.0</param>
        /// <param name="longitude">经度值。 范围可以是从 -180.0 到 180.0</param>
        /// <param name="altitude">以米为单位海拔高度。 可以是负数，0，正数，或 NaN, ; 如果未知。</param>
        /// <param name="series"><see cref="LocationSeries"/>地理坐标协调系列</param>
        public Location(double latitude, double longitude, double altitude = 0, LocationSeries series = LocationSeries.UNKNOWN)
        {
            // 说明：
            //  1、经度范围为-180至180
            //  2、纬度范围为-90至90
            if (Math.Abs(latitude) > 90 || Math.Abs(longitude) > 180)
                throw new ArgumentException($"{nameof(longitude)} or {latitude} out of range.");

            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
            this.Series = series;
        }

        /// <summary>
        /// 初始化<see cref="Location"/>类的新实例。
        /// 从经度、纬度、海拔高度、地理坐标协调系列。
        /// </summary>
        /// <param name="latitude">纬度值。范围可以是从 -90.0 到 90.0</param>
        /// <param name="longitude">经度值。范围可以是从 -180.0 到 180.0</param>
        /// <param name="altitude">以米为单位海拔高度。 可以是负数，0，正数，或 NaN, ; 如果未知。</param>
        /// <param name="series"><see cref="LocationSeries"/>地理坐标协调系列</param>
        [Obsolete("字符串转Double时，后期需要优化，优化方式：使用封闭的String转Double方法")]
        public Location(string latitude, string longitude, double altitude = 0, LocationSeries series = LocationSeries.UNKNOWN)
        {
            if (string.IsNullOrWhiteSpace(longitude))
                throw new ArgumentNullException(nameof(longitude));

            if (string.IsNullOrWhiteSpace(latitude))
                throw new ArgumentNullException(nameof(latitude));

            double longitude1 = 0;
            double latitude1 = 0;
            double.TryParse(longitude, out longitude1);
            double.TryParse(latitude, out latitude1);

            if (Math.Abs(latitude1) > 90 || Math.Abs(longitude1) > 180)
                throw new ArgumentException($"{nameof(longitude)} or {latitude} out of range.");

            this.Latitude = latitude1;
            this.Longitude = longitude1;
            this.Altitude = altitude;
            this.Series = series;
        }

        #endregion

        #region 重写方法

        /// <summary>
        /// Returns the hash code for this <see cref="Location"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return $"{this.Longitude}{this.Latitude}{this.Altitude}{this.Series}".GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="Location"/> value.
        ///  说明：必须经度、纬度、所属系列均相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var location = obj as Location;

            if (location == null)
                return false;

            return location.GetHashCode().Equals(this.GetHashCode());
        }

        /// <summary>
        /// override ToString方法
        /// 返回位置经纬度(纬度在前)用英文“,”号分隔的字符串，如：“130.091231,22.890123”
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Latitude},{this.Longitude}";
        }

        #endregion
    }
}
