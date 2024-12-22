using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoi
{
    public abstract class Unit
    {
        // Tên của đơn vị đo lường, không thể thay đổi từ bên ngoài.
        public string Name { get; private set; }

        // Giá trị của đơn vị so với đơn vị cơ sở
        public string Symbol { get; private set; }

        // Constructor để khởi tạo một đối tượng Unit với tên và giá trị.
        public Unit(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // 1 km = ?m.
        // value giá trị cần đổi (1)
        // targetUnit đơn vị đến (m)
        public abstract double ConvertTo(Unit TargetUnit, double value);
    }
}
