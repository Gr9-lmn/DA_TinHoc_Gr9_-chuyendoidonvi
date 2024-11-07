using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm các loại đơn vị vào ListBox
            listBoxCategories.Items.Add("Chiều Dài");
            listBoxCategories.Items.Add("Khối Lượng");
            listBoxCategories.Items.Add("Nhiệt Độ");
            // Đặt tên listbox là: listBoxCategories
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Giả sử bạn có một TextBox tên là textBox2
            textBox2.Enabled = false;  // Ngừng tương tác với TextBox (không thể chọn hay sao chép)
            textBox2.ReadOnly = true;

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xóa các mục hiện có trong ComboBox
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();

            // Cập nhật các ComboBox dựa vào lựa chọn từ ListBox
            switch (listBoxCategories.SelectedItem.ToString())
            {
                case "Chiều Dài":
                    string[] lengthUnits = { "Kilometers (km)", "Hectometers (hm)", "Decameters (dam)",
                                             "Meters (m)", "Decimeters (dm)", "Centimeters (cm)", "Millimeters (mm)" };
                    comboBoxFrom.Items.AddRange(lengthUnits);
                    comboBoxTo.Items.AddRange(lengthUnits);
                    break;

                case "Khối Lượng":
                    string[] weightUnits = { "Tấn", "Tạ", "Yến", "Kilograms (kg)",
                                             "Hectograms (hg)", "Decagrams (dag)", "Grams (g)" };
                    comboBoxFrom.Items.AddRange(weightUnits);
                    comboBoxTo.Items.AddRange(weightUnits);
                    break;

                case "Nhiệt Độ":
                    string[] temperatureUnits = { "Celsius (°C)", "Fahrenheit (°F)", "Kelvin (K)" };
                    comboBoxFrom.Items.AddRange(temperatureUnits);
                    comboBoxTo.Items.AddRange(temperatureUnits);
                    break;
            }
            // Thiết lập giá trị mặc định cho các ComboBox
            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 1;
            // Đặt tên cho 2 comnobox là: comboBoxFrom và comboBoxTo
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private double ConvertUnit(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit) return value;

            switch (fromUnit + " to " + toUnit)
            {
                // chiều dài
                // Km sang các đơn vị còn lại
                case "Kilometers (km) to Hectometers (hm)":  return value * 10;
                case "Kilometers (km) to Decameters (dam)":  return value * 100;
                case "Kilometers (km) to Meters (m)"      :  return value * 1000;
                case "Kilometers (km) to Decimeters (dm)" :  return value * 10000;
                case "Kilometers (km) to Centimeters (cm)":  return value * 100000;
                case "Kilometers (km) to Millimeters (mm)":  return value * 1000000;

                // hm sang các đơn vị còn lại
                case "Hectometers (hm) to Kilometers (Km)" : return value / 10;
                case "Hectometers (hm) to Decameters (dam)": return value * 10;
                case "Hectometers (hm) to Meters (m)"      : return value * 100;
                case "Hectometers (hm) to Decimeters (dm)" : return value * 1000;
                case "Hectometers (hm) to Centimeters (cm)": return value * 10000;
                case "Hectometers (hm) to Millimeters (mm)": return value * 100000;

                // dam sang các đơn vị còn lại
                case "Decameters (dam) to Kilometers (Km)"  : return value / 100;
                case "Decameters (dam) to Hectometers (hm)" : return value / 10;
                case "Decameters (dam) to Meters (m)"       : return value * 10;
                case "Decameters (dam) to Decimeters (dm)"  : return value * 100;
                case "Decameters (dam) to Centimeters (cm)" : return value * 1000;
                case "Decameters (dam) to Millimeters (mm)" : return value * 10000;

                // m sang các đơn vị còn lại
                case "Meters (m) to Kilometers (Km)"    : return value / 1000;
                case "Meters (m) to Hectometers (hm)"   : return value / 100;
                case "Meters (m) to Decameters (dam)"   : return value / 10;
                case "Meters (m) to Decimeters (dm)"    : return value * 10;
                case "Meters (m) to Centimeters (cm)"   : return value * 100;
                case "Meters (m) to Millimeters (mm)"   : return value * 1000;

                // dm sang các đơn vị còn lại
                case "Decimeters (dm) to Kilometers (Km)"   : return value / 10000;
                case "Decimeters (dm) to Hectometers (hm)"  : return value / 1000;
                case "Decimeters (dm) to Decameters (dam)"  : return value / 100;
                case "Decimeters (dm) to Meters (m)"        : return value / 10;
                case "Decimeters (dm) to Centimeters (cm)"  : return value * 10;
                case "Decimeters (dm) to Millimeters (mm)"  : return value * 100;

                // cm sang các đơn vị còn lại
                case "Centimeters (cm) to Kilometers (Km)"  : return value / 100000;
                case "Centimeters (cm) to Hectometers (hm)" : return value / 10000;
                case "Centimeters (cm)  to Decameters (dam)": return value / 1000;
                case "Centimeters (cm) to Meters (m)"       : return value / 100;
                case "Centimeters (cm) to Decimeters (dm)"  : return value / 10;
                case "Centimeters (cm) to Millimeters (mm)" : return value * 10;

                // mm sang các đơn vị còn lại
                case "Millimeters (mm) to Kilometers (Km)"  : return value / 1000000;
                case "Millimeters (mm) to Hectometers (hm)" : return value / 100000;
                case "Millimeters (mm)  to Decameters (dam)": return value / 10000;
                case "Millimeters (mm) to Meters (m)"       : return value / 1000;
                case "Millimeters (mm) to Decimeters (dm)"  : return value / 100;
                case "Millimeters (mm) to Centimeters (cm)" : return value / 10;

                // khối lượng
                // tấn sang các đơn vị còn lại
                case "Tấn to Tạ"                : return value * 10;
                case "Tấn to Yến"               : return value * 100;
                case "Tấn to Kilograms (kg)"    : return value * 1000;
                case "Tấn to Hectograms (hg)"   : return value * 10000;
                case "Tấn to Decagrams (dag)"   : return value * 100000;
                case "Tấn to Grams (g)"         : return value * 1000000;


                // tạ sang các đơn vị còn lại
                case "Tạ to Tấn"                : return value / 10;
                case "Tạ to Yến"                : return value * 10;
                case "Tạ to Kilograms (kg)"     : return value * 100;
                case "Tạ to Hectograms (hg)"    : return value * 1000;
                case "Tạ to Decagrams (dag)"    : return value * 10000;
                case "Tạ to Grams (g)"          : return value * 100000;


                // yến sáng các đơn vị còn lại
                case "Yến to Tấn"               : return value / 100;
                case "Yến to Tạ"                : return value / 10;
                case "Yến to Kilograms (kg)"    : return value * 10;
                case "Yến to Hectograms (hg)"   : return value * 100;
                case "Yến to Decagrams (dag)"   : return value * 1000;
                case "Yến to Grams (g)"         : return value * 10000;


                // kg sang các đơn vị còn lại
                case "Kilograms (kg) to Tấn"            : return value / 1000;
                case "Kilograms (kg) to Tạ"             : return value / 100;
                case "Kilograms (kg) to Yến"            : return value / 10;
                case "Kilograms (kg) to Hectograms (hg)": return value * 10;
                case "Kilograms (kg) to Decagrams (dag)": return value * 100;
                case "Kilograms (kg) to Grams (g)"      : return value * 1000;

                // hg sang các đơn vị còn lại
                case "Hectograms (hg) to Tấn"               : return value / 10000;
                case "Hectograms (hg) to Tạ"                : return value / 1000;
                case "Hectograms (hg) to Yến"               : return value / 100;
                case "Hectograms (hg) to Kilograms (kg)"    : return value / 10;
                case "Hectograms (hg) to Decagrams (dag)"   : return value * 10;
                case "Hectograms (hg) to Grams (g)"         : return value * 100;


                // dag sang các đơn vị còn lại
                case "Decagrams (dag) to Tấn"               : return value / 100000;
                case "Decagrams (dag) to Tạ"                : return value / 10000;
                case "Decagrams (dag) to Yến"               : return value / 1000;
                case "Decagrams (dag) to Kilograms (kg)"    : return value / 100;
                case "Decagrams (dag) to Hectograms (hg)"   : return value / 10;
                case "Decagrams (dag) to Grams (g)"         : return value * 10;


                // g sang các đơn vị còn lại
                case "Grams (g) to Tấn"                     : return value / 1000000;
                case "Grams (g) to Tạ"                      : return value / 100000;
                case "Grams (g) to Yến"                     : return value / 10000;
                case "Grams (g) to Kilograms (kg)"          : return value / 1000;
                case "Grams (g) to Hectograms (hg)"         : return value / 100;
                case "Grams (g) to Decagrams (dag)"         : return value / 10;



                // nhiệt độ
                // C sang còn lại
                case "Celsius (°C) to Fahrenheit (°F)"  : return (value * 9 / 5) + 32;
                case "Celsius (°C) to Kelvin (K)"       : return value + 273.15;

                // F sang còn lại
                case "Fahrenheit (°F) to Celsius (°C)"  : return (value - 32) * 5 / 9;
                case "Fahrenheit (°F) to Kelvin (K)"    : return ((value - 32) * 5 / 9) + 273.15;


                // K sang còn lại
                case "Kelvin (K) to Celsius (°C)"       : return value - 273.15;
                case "Kelvin (K) to Fahrenheit (°F)"    : return ((value - 273.15) * 9 / 5) + 32;


                default: throw new InvalidOperationException("Conversion not supported.");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem giá trị trong txtInput có hợp lệ không
                if (string.IsNullOrEmpty(txtInput.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá trị vào ô đầu vào.");
                    return;
                }

                // Chuyển giá trị nhập vào thành kiểu double
                double inputValue = double.Parse(txtInput.Text);

                // Lấy đơn vị nguồn và đích từ ComboBox
                string fromUnit = comboBoxFrom.SelectedItem.ToString();
                string toUnit = comboBoxTo.SelectedItem.ToString();

                // Gọi hàm ConvertUnit để chuyển đổi giá trị
                double result = ConvertUnit(inputValue, fromUnit, toUnit);

                // Hiển thị kết quả trong textBox2
                textBox2.Text = result.ToString("F2");  // Hiển thị kết quả với 2 chữ số thập phân
            }
            catch (FormatException)
            {
                // Nếu giá trị nhập vào không hợp lệ, hiển thị thông báo lỗi
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ.");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác (nếu có)
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
    

