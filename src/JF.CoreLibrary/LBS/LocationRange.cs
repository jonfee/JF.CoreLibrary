using System;

namespace JF.CoreLibrary.LBS
{
    /// <summary>
    /// 地理位置坐标范围
    /// 包含4个坐标点。即 左上标、左下标，右上标，右下标 四个方位坐标点。
    /// </summary>
    public class LocationRange
    {
        #region 属性成员

        /// <summary>
        /// 获取左上坐标点。
        /// </summary>
        public Location LeftTop
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取左下坐标点。
        /// </summary>
        public Location LeftBottom
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取右上坐标点。
        /// </summary>
        public Location RightTop
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取右下坐标点。
        /// </summary>
        public Location RightBottom
        {
            get;
            private set;
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化<see cref="Location"/>类新实例。
        /// </summary>
        /// <param name="leftTop">左上坐标点</param>
        /// <param name="leftBottom">左下坐标点</param>
        /// <param name="rightTop">右上坐标点</param>
        /// <param name="rightBottom">右下坐标点</param>
        public LocationRange(Location leftTop, Location leftBottom, Location rightTop, Location rightBottom)
        {
            if (leftTop == null)
                throw new ArgumentNullException(nameof(LeftTop));

            if (leftBottom == null)
                throw new ArgumentNullException(nameof(leftBottom));

            if (rightTop == null)
                throw new ArgumentNullException(nameof(rightTop));

            if (rightBottom == null)
                throw new ArgumentNullException(nameof(rightBottom));

            this.LeftTop = leftTop;
            this.LeftBottom = leftBottom;
            this.RightTop = rightTop;
            this.RightBottom = rightBottom;
        }

        #endregion
    }
}
