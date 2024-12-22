using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChuyenDoi
{
    public partial class Form1 : Form
    {
        private ChuyenDoi chuyenDoi;
        private HistoryManager historyManager; // Quản lý lịch sử

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();

            chuyenDoi = new ChuyenDoi();
            historyManager = new HistoryManager(); // Khởi tạo đối tượng HistoryManager

            // Tải lịch sử vào DataGridView
            LoadHistoryToDataGridView();

            // Khởi tạo các nhóm đơn vị
            // Chiều Dài
            GrUnit length = new GrUnit("Length");
            length.AddUnit(new LengthUnit("Meter", "m", 1));
            length.AddUnit(new LengthUnit("Kilometer", "km", 0.001));
            length.AddUnit(new LengthUnit("Hectometer", "hm", 0.01));
            length.AddUnit(new LengthUnit("Decameter", "dam", 0.1));
            length.AddUnit(new LengthUnit("Deximeter", "dm", 10));
            length.AddUnit(new LengthUnit("Centimeter", "cm", 100));
            length.AddUnit(new LengthUnit("Milimeter", "mm", 1000));
            length.AddUnit(new LengthUnit("Inch", "inch", 39.3701));

            // Khối Lượng
            GrUnit weight = new GrUnit("Weight");
            weight.AddUnit(new WeightUnit("Kilogram", "kg", 1));
            weight.AddUnit(new WeightUnit("Tấn", "tấn", 0.001));
            weight.AddUnit(new WeightUnit("Tạ", "tạ", 0.01));
            weight.AddUnit(new WeightUnit("Yến", "yến", 0.1));
            weight.AddUnit(new WeightUnit("Hectogram", "hg", 10));
            weight.AddUnit(new WeightUnit("Decagram", "dag", 100));
            weight.AddUnit(new WeightUnit("Gram", "g", 1000));
            weight.AddUnit(new WeightUnit("Pound", "lb", 2.20462));

            // Nhiệt Độ
            GrUnit temperature = new GrUnit("Temperature");
            temperature.AddUnit(new TemperatureUnit("Celsius", "°C"));
            temperature.AddUnit(new TemperatureUnit("Fahrenheit", "°F"));
            temperature.AddUnit(new TemperatureUnit("Kelvin", "°K"));

            // Thêm các nhóm đơn vị vào danh sách chuyển đổi
            chuyenDoi.AddLoaiDonVi(length);
            chuyenDoi.AddLoaiDonVi(weight);
            chuyenDoi.AddLoaiDonVi(temperature);

            // Thêm các nhóm đơn vị vào ComboBox GrUnit
            foreach (var unit in chuyenDoi.DsLoaiDv)
            {
                cbbGrUnit.Items.Add(unit.NameGr);
            }

            // Thiết lập chế độ chỉ đọc cho ComboBox
            cbbGrUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Xử lý sự kiện khi người dùng chọn nhóm đơn vị
            cbbGrUnit.SelectedIndexChanged += CbbGrUnit_SelectedIndexChanged;

            // Xử lý sự kiện khi nhấn phím Enter trong TextBox
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyPreview = true; // Đảm bảo form có thể nhận sự kiện phím

            textValue.KeyPress += TxtValue_KeyPress; // Khống chế nhập liệu trong TextBox
        }

        // Cập nhật DataGridView để hiển thị kết quả chuyển đổi
        private void InitializeDataGridView()
        {
            // Thêm các cột vào DataGridView
            dgvSave.Columns.Add("Giá trị", "Giá trị");
            dgvSave.Columns.Add("Đơn vị gốc", "Đơn vị gốc");
            dgvSave.Columns.Add("Kết quả", "Kết quả");
            dgvSave.Columns.Add("Đơn vị mới", "Đơn vị mới");
            dgvSave.Columns.Add("Mốc thời gian", "Mốc thời gian");

            // Cập nhật chiều rộng cột "Mốc thời gian"
            dgvSave.Columns["Mốc thời gian"].Width = 156;
            dgvSave.Columns["Đơn vị mới"].Width = 140;
            dgvSave.Columns["Đơn vị gốc"].Width = 140;
            dgvSave.Columns["Giá trị"].Width = 180;
            dgvSave.Columns["Kết quả"].Width = 180;

            // Thiết lập cột "Mốc thời gian" để hiển thị ngày giờ
            dgvSave.Columns["Mốc thời gian"].DefaultCellStyle.Format = "HH:mm dd/MM";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView
            dgvSave.ReadOnly = true; // Không cho phép chỉnh sửa dữ liệu
            dgvSave.AllowUserToAddRows = false; // Không cho phép thêm hàng
            dgvSave.AllowUserToDeleteRows = false; // Không cho phép xóa hàng
        }

        private void TxtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && textValue.Text.Contains('.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && textValue.SelectionStart == 0)
            {
                e.Handled = true;
            }
            // Chặn trường hợp nhập dấu âm sau dấu chấm
            if (e.KeyChar == '.' && textValue.Text.Contains('-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && textValue.SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        // Xử lý sự kiện nhấn phím Enter trong TextBox
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformConvert();
                e.Handled = true;
            }
        }

        // Cập nhật các ComboBox dựa trên nhóm đơn vị đã chọn
        private void CbbGrUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = cbbGrUnit.SelectedItem.ToString();
            GrUnit selectedGrUnit = chuyenDoi.DsLoaiDv.FirstOrDefault(g => g.NameGr == selectedGroup);

            if (selectedGrUnit != null)
            {
                if (selectedGrUnit != null)
                {
                    cbbFrom.DataSource = selectedGrUnit.getname();
                    cbbTo.DataSource = selectedGrUnit.getname();
                }
            }
        }

        private void LoadHistoryToDataGridView()
        {
            try
            {
                string filePath = "history.bin";
                chuyenDoi.History = historyManager.DocDuLieu(filePath); // Sử dụng historyManager để gọi DocDuLieu

                // Hiển thị dữ liệu trong DataGridView
                dgvSave.Rows.Clear();

                // Thêm các mục lịch sử
                foreach (var entry in chuyenDoi.History)
                {
                    dgvSave.Rows.Add(entry.InputValue, entry.FromUnit, entry.Result, entry.ToUnit, entry.Timestamp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error khi tải lịch sử: {ex.Message}", "Load History Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformConvert()
        {
            try
            {
                double input = double.Parse(textValue.Text);

                string fromUnit = cbbFrom.SelectedItem?.ToString(); 
                string toUnit = cbbTo.SelectedItem?.ToString();
                string groupName = cbbGrUnit.SelectedItem?.ToString();
               
                if (string.IsNullOrEmpty(fromUnit) || string.IsNullOrEmpty(toUnit) || string.IsNullOrEmpty(groupName))

                {
                    throw new ArgumentException("Vui lòng chọn loại đơn vị, nguồn và đơn vị đích.");
                }

                double result = chuyenDoi.Convertc_CD(input, fromUnit, toUnit, groupName);
                labelKQ.Text = $"{input} {fromUnit} = {result} {toUnit}";

                // Tạo mục lịch sử
                HistoryEntry entry = new HistoryEntry(input, fromUnit, result, toUnit, DateTime.Now);
                chuyenDoi.History.Insert(0, entry);

                // Cập nhật DataGridView              
                dgvSave.Rows.Insert(0, input, fromUnit, result, toUnit, entry.Timestamp);

                // Lưu lịch sử vào file
                string filePath = "history.bin";
                historyManager.LuuDuLieu(filePath, chuyenDoi.History);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "history.bin"; // Đường dẫn tới file lịch sử
                chuyenDoi.XoaLichSu(filePath); // Gọi hàm xóa lịch sử
                MessageBox.Show("Lịch sử đã được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView nếu cần
                dgvSave.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi xóa lịch sử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}








