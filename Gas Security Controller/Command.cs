using System;
using System.Collections.Generic;
using System.Text;

namespace GSC
{
    public struct Command
    {
        public const string F1 = "68 86 00 00";
        public const string F2 = "68 86 00 10";
        public const string F3 = "68 86 00 11";
        public const string F4 = "68 86 00 12";

        public const string S_1 = "69 96 01 01";
        public const string F_1 = "69 96 01 02";
        public const string Q_1 = "69 96 01 04";

        public const string S_2 = "69 96 02 01";
        public const string F_2 = "69 96 02 02";
        public const string Q_2 = "69 96 02 04";

        public const string S_3 = "69 96 03 01";
        public const string F_3 = "69 96 03 02";
        public const string Q_3 = "69 96 03 04";

        public const string S_4 = "69 96 04 01";
        public const string F_4 = "69 96 04 02";
        public const string Q_4 = "69 96 04 04";

        public const string Check1 = "68 86 01";
        public const string Check2 = "68 86 02";
        public const string Check3 = "68 86 03";
        public const string Check4 = "68 86 04";

        public const string Check1Response = "01";
        public const string Check2Response = "02";
        public const string Check3Response = "03";
        public const string Check4Response = "04";
    }
}
