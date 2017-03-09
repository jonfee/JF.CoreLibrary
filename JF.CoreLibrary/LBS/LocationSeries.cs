namespace JF.CoreLibrary.LBS
{
    /// <summary>
    /// 地理坐标协调系列。
    /// </summary>
    public enum LocationSeries
    {
        /// <summary>
        /// 未知坐标系。
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// 地球坐标系，国际上通用的坐标系。
        /// </summary>
        WGS84,

        /// <summary>
        /// 火星坐标系，由WGS84坐标系加密后的坐标系。
        /// </summary>
        GCJ02,

        /// <summary>
        /// 百度坐标系，GCJ02坐标系加密后的坐标系。
        /// </summary>
        BD09
    }
}
