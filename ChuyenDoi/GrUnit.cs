using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoi
{
    public class GrUnit
    {
        public string NameGr { get; set; } // Tên nhóm đơn vị

        public List<Unit> UnitList { get; set; } // Danh sách đơn vị

        public GrUnit(string tennhom) // NameGr và danh sách các unit của NameGr đó.
        {
            NameGr = tennhom;
            UnitList = new List<Unit>();
        }

        public void AddUnit(Unit unit) // Hàm kiểm tra và thêm unit Và GrUnit 
        {
            if (UnitList.Any(u => u.Symbol == unit.Symbol))
            {
                throw new InvalidOperationException($"Đơn vị {unit.Symbol} đã tồn tại trong nhóm.");
            }
            else
            {
                UnitList.Add(unit);
            }
        }

        public List<string> getname()
        {
            var list = new List<string>();
            foreach (var a in UnitList)
            {
                list.Add(a.Symbol);
            }
            return list;
        }

        public double Convert(string from, string to, double value)
        {
            var donvinnguon = UnitList.Find(unit => unit.Symbol == from);
            var donviden = UnitList.Find(unit => unit.Symbol == to);

            if (donvinnguon == null) { throw new ArgumentException($"Không tìm thấy đơn vị nguồn: {from} trong nhóm {NameGr}."); }
            if (donviden == null)    { throw new ArgumentException($"Không tìm thấy đơn vị đích: {to} trong nhóm {NameGr}."); }

            // Kiểm tra tính tương thích
            if (donvinnguon.GetType() != donviden.GetType())
            { throw new ArgumentException($"Không thể chuyển đổi giữa các đơn vị {from} và {to} vì chúng không phải cùng loại."); }

            return donvinnguon.ConvertTo(donviden, value);
        }
    }
}
