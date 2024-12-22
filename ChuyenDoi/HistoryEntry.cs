using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoi
{
    // Lớp lưu trữ thông tin lịch sử
    [Serializable]
    public class HistoryEntry
    {
        public double InputValue { get; set; }
        public string FromUnit { get; set; }
        public double Result { get; set; }
        public string ToUnit { get; set; }
        public DateTime Timestamp { get; set; }

        public HistoryEntry(double inputValue, string fromUnit, double result, string toUnit, DateTime timestamp)
        {
            InputValue = inputValue;
            FromUnit = fromUnit;
            Result = result;
            ToUnit = toUnit;
            Timestamp = timestamp;
        }
    }
}
