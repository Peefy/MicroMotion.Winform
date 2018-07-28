using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMotion.Helpers
{
    /// <summary>
    /// 地址要减一，如果是PLC去读则不用减一
    /// </summary>
    public class AddressHelper
    {
        public const ushort QualityFlow = 247 - 1;
        public const ushort Density = 249 - 1;
        public const ushort Temperature = 251 - 1;
        /// <summary>
        /// 这个的地址我不太清楚
        /// </summary>
        public const ushort TotalAmount = 259 - 1;

        /// <summary>
        /// 目标值
        /// </summary>
        public const ushort Goal = 1289 - 1;
        /// <summary>
        /// 批控器  实际加料值
        /// </summary>
        public const ushort Real = 1291 - 1;

        public const ushort DO1 = 1182 - 1;

        public const ushort CoilIsStartBacth = 100 - 1;
        public const ushort CoilResumeBacth = 101 - 1;
        public const ushort CoilEndBacth = 198 - 1;
        public const ushort CoilResetReal = 211 - 1;

        public static ushort NumberUnitOfWord = 1;
        public static ushort NumberUnitOfFloat = 2;
    }
}
