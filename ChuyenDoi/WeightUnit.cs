using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoi
{
    public class WeightUnit : Unit
    {
        public double Hesochuyendoi { get; set; }

        public WeightUnit(string name, string symbol, double heso) : base(name, symbol)
        {
            Hesochuyendoi = heso;
        }

        public override double ConvertTo(Unit unit, double value)
        {
            if (value < 0)
                throw new ArgumentException("Giá trị của WeightUnit không thể là số âm.");
            if (unit is WeightUnit weightUnit)
            {
                double temp = value / Hesochuyendoi;
                return temp * weightUnit.Hesochuyendoi;
            }
            throw new ArgumentException($"Không thể chuyển đổi từ {Symbol} sang {unit.Symbol}. Đây không phải là cùng loại đơn vị khối lượng.");
        }
    }
}
