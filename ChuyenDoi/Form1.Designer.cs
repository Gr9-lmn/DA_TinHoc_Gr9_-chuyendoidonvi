namespace ChuyenDoi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbbGrUnit = new ComboBox();
            cbbTo = new ComboBox();
            cbbFrom = new ComboBox();
            textValue = new TextBox();
            dgvSave = new DataGridView();
            labelKQ = new Label();
            buttonXoa = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSave).BeginInit();
            SuspendLayout();
            // 
            // cbbGrUnit
            // 
            cbbGrUnit.FormattingEnabled = true;
            cbbGrUnit.Location = new Point(42, 99);
            cbbGrUnit.Name = "cbbGrUnit";
            cbbGrUnit.Size = new Size(182, 33);
            cbbGrUnit.TabIndex = 0;
            // 
            // cbbTo
            // 
            cbbTo.FormattingEnabled = true;
            cbbTo.Location = new Point(641, 99);
            cbbTo.Name = "cbbTo";
            cbbTo.Size = new Size(182, 33);
            cbbTo.TabIndex = 2;
            // 
            // cbbFrom
            // 
            cbbFrom.FormattingEnabled = true;
            cbbFrom.Location = new Point(333, 99);
            cbbFrom.Name = "cbbFrom";
            cbbFrom.Size = new Size(182, 33);
            cbbFrom.TabIndex = 1;
            // 
            // textValue
            // 
            textValue.Location = new Point(42, 181);
            textValue.Name = "textValue";
            textValue.Size = new Size(182, 31);
            textValue.TabIndex = 3;
            // 
            // dgvSave
            // 
            dgvSave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSave.Location = new Point(12, 233);
            dgvSave.Name = "dgvSave";
            dgvSave.RowHeadersWidth = 62;
            dgvSave.RowTemplate.Height = 33;
            dgvSave.Size = new Size(843, 205);
            dgvSave.TabIndex = 4;
            // 
            // labelKQ
            // 
            labelKQ.AutoSize = true;
            labelKQ.Location = new Point(344, 184);
            labelKQ.Name = "labelKQ";
            labelKQ.Size = new Size(171, 25);
            labelKQ.TabIndex = 5;
            labelKQ.Text = "Kết Quả Hiện Ở Đây";
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(669, 175);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(112, 34);
            buttonXoa.TabIndex = 6;
            buttonXoa.Text = "Xóa Lịch Sử";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 9);
            label1.Name = "label1";
            label1.Size = new Size(196, 25);
            label1.TabIndex = 7;
            label1.Text = "Chuyển Đổi Các Đơn Vị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 145);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 8;
            label2.Text = "Nhập Giá Trị";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 59);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 9;
            label3.Text = "Loại Đơn Vị ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 59);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 10;
            label4.Text = "Đơn Vị Gốc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(686, 59);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 11;
            label5.Text = "Đơn Vị Mới";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonXoa);
            Controls.Add(labelKQ);
            Controls.Add(dgvSave);
            Controls.Add(textValue);
            Controls.Add(cbbFrom);
            Controls.Add(cbbTo);
            Controls.Add(cbbGrUnit);
            Name = "Form1";
            Text = "Chuyển Đổi Đơn Vị";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSave).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbbGrUnit;
        private ComboBox cbbTo;
        private ComboBox cbbFrom;
        private TextBox textValue;
        private DataGridView dgvSave;
        private Label labelKQ;
        private Button buttonXoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
