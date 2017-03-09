using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.CoreLibrary.LBS
{
    /// <summary>
    /// 地理位置扩展类
    /// </summary>
    public static class LocationExtension
    {
        /// <summary>
        /// 计算两个位置之间的距离，返回单位（公里）。
        /// </summary>
        /// <remarks>忽略海拔的影响</remarks>
        /// <param name="source">源位置</param>
        /// <param name="target">目标位置</param>
        /// <returns></returns>
        public static double GetDistance(this Location source, Location target)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (target == null)
                throw new ArgumentNullException("target");

            return LocationUtility.GetDistance(source, target);
        }

        /// <summary>
        /// 计算两个位置之间的距离，返回单位（公里）。
        /// </summary>
        /// <remarks>忽略海拔的影响</remarks>
        /// <param name="source">源位置</param>
        /// <param name="latitude">目标位置纬度。</param>
        /// <param name="longitude">目标位置经度。</param>
        /// <returns></returns>
        public static double GetDistance(this Location source, double latitude, double longitude)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return LocationUtility.GetDistance(source.Latitude, source.Longitude, latitude, longitude);
        }

       /// <summary>
       /// 计算以源位置为中心指定半径（单位：公里）的地理位置覆盖区域
       /// </summary>
       /// <param name="source">源位置</param>
       /// <param name="distance">半径（单位：公里）</param>
       /// <returns></returns>
        public static LocationRange GetPosition(this Location source, double distance)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return LocationUtility.GetPosition(source, distance);
        }

        /// <summary>
        /// 检测目标是否在源位置指定半径（单位：公里）覆盖范围内
        /// </summary>
        /// <param name="source">源位置</param>
        /// <param name="target">目标位置</param>
        /// <param name="distance">源位置的覆盖半径（单位：公里）</param>
        /// <returns></returns>
        public static bool IsInRange(this Location source, Location target, double distance)
        {
            return LocationUtility.IsInRange(source, target, distance);
        }

        /// <summary>
        /// 检测目标是否在源位置指定半径（单位：公里）覆盖范围内
        /// </summary>
        /// <param name="source">源位置</param>
        /// <param name="latitude">目标纬度。</param>
        /// <param name="longitude">目标经度。</param>
        /// <param name="distance">源位置的覆盖半径（单位：公里）</param>
        /// <returns></returns>
        public static bool IsInRange(this Location source, double latitude, double longitude, double distance)
        {
            return LocationUtility.IsInRange(source, new Location(latitude, longitude), distance);
        }
    }
}
