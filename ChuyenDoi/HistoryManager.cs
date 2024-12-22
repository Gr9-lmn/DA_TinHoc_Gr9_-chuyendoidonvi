using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChuyenDoi
{
    public class HistoryManager
    {
        // Lưu dữ liệu vào file
        public void LuuDuLieu(string filePath, List<HistoryEntry> history)
        {
            if (!File.Exists(filePath))
            {
                string directoryName = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directoryName))
                    Directory.CreateDirectory(directoryName);
            }
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, history);
                file.Close();
            }
        }

        // Đọc dữ liệu từ file
        public List<HistoryEntry> DocDuLieu(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<HistoryEntry>)bf.Deserialize(file);
                }
            }
            else
            {
                return new List<HistoryEntry>(); // Trả về danh sách trống nếu không có file
            }
        }

        // Xóa lịch sử (xóa nội dung trong file)
        public void XoaLichSu(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Ghi danh sách trống vào file để xóa lịch sử
                using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, new List<HistoryEntry>()); // Ghi danh sách trống vào file
                }
            }
            else
            {
                throw new FileNotFoundException($"Không tìm thấy file lịch sử tại: {filePath}");
            }
        }
    }
}

