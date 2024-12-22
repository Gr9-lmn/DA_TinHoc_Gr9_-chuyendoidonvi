using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuyenDoi
{
    public class ChuyenDoi
    {
        public List<GrUnit> DsLoaiDv { get; set; } // Danh sách nhóm đơn vị

        public List<HistoryEntry> History { get; set; } // Lịch sử chuyển đổi

        private HistoryManager historyManager; // Quản lý lưu/đọc lịch sử

        public ChuyenDoi()
        {
            DsLoaiDv = new List<GrUnit>();
            History = new List<HistoryEntry>();
            historyManager = new HistoryManager(); // Khởi tạo đối tượng quản lý lịch sử
        }

        public void AddLoaiDonVi(GrUnit u)
        {
            if (DsLoaiDv.Any(a => a.NameGr == u.NameGr))
            {
                throw new InvalidOperationException($"Đơn vị {u.NameGr} đã tồn tại.");
            }
            else
            {
                DsLoaiDv.Add(u);
            }
        }

        public double Convertc_CD(double value, string from, string to, string groupName)
        {
            var group = DsLoaiDv.FirstOrDefault(g => g.NameGr == groupName);
            if (group == null)
                throw new ArgumentException($"Không tìm thấy nhóm đơn vị với tên '{groupName}'.");

            var fromUnit = group.UnitList.FirstOrDefault(u => u.Symbol == from);
            var toUnit = group.UnitList.FirstOrDefault(u => u.Symbol == to);

            if (fromUnit == null)
                throw new ArgumentException($"Đơn vị nguồn '{from}' không tồn tại trong nhóm {groupName}.");
            if (toUnit == null)
                throw new ArgumentException($"Đơn vị đích '{to}' không tồn tại trong nhóm {groupName}.");

            double result = group.Convert(from, to, value);

            // Thêm vào lịch sử
            History.Add(new HistoryEntry(value, from, result, to, DateTime.Now));
            return result;
        }

        // Hàm xóa lịch sử
        public void XoaLichSu(string filePath)
        {
            try
            {
                historyManager.XoaLichSu(filePath);
                History.Clear(); // Xóa lịch sử trong bộ nhớ
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lịch sử: {ex.Message}");
            }
        }
    }
}
