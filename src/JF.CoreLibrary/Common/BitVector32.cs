using System.Threading;

namespace JF.CoreLibrary.Common
{
    public struct BitVector32
    {
        #region 成员字段

        private int _data;

        #endregion

        #region 构造方法

        public BitVector32(int data)
        {
            _data = data;
        }

        #endregion

        #region 公共属性

        public int Data
        {
            get
            {
                return _data;
            }
        }

        public bool this[int bit]
        {
            get
            {
                var data = _data;
                return (data & bit) == bit;
            }
            set
            {
                while (true)
                {
                    var oldData = _data;
                    int newData;

                    if (value)
                    {
                        newData = oldData | bit;
                    }
                    else
                    {
                        newData = oldData & ~bit;
                    }

                    var result = Interlocked.CompareExchange(ref _data, newData, oldData);

                    if (result == oldData)
                    {
                        break;
                    }
                }
            }
        }

        #endregion

        #region 类型转换

        public static implicit operator int(BitVector32 vector)
        {
            return vector._data;
        }

        public static implicit operator BitVector32(int data)
        {
            return new BitVector32(data);
        }

        #endregion

        #region 重写方法

        public override string ToString()
        {
            return _data.ToString();
        }

        #endregion
    }
}
