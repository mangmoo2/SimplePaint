namespace SimplePaint
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
            lblAppName = new Label();
            GroupBox = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            groupBox1 = new GroupBox();
            cmbColor = new ComboBox();
            groupBox2 = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            GroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.Red;
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(132, 30);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SimplePaint";
            lblAppName.Click += label1_Click;
            // 
            // GroupBox
            // 
            GroupBox.Controls.Add(btnCircle);
            GroupBox.Controls.Add(btnRectangle);
            GroupBox.Controls.Add(btnLine);
            GroupBox.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            GroupBox.Location = new Point(12, 57);
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(218, 90);
            GroupBox.TabIndex = 1;
            GroupBox.TabStop = false;
            GroupBox.Text = "도형선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = Properties.Resources.스크린샷_2026_04_30_093228;
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(146, 22);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(64, 62);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = Properties.Resources.스크린샷_2026_04_30_093223;
            btnRectangle.Location = new Point(76, 22);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(64, 62);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnLine
            // 
            btnLine.Image = Properties.Resources.스크린샷_2026_04_30_093219;
            btnLine.Location = new Point(6, 22);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(64, 62);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbColor);
            groupBox1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox1.Location = new Point(236, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(107, 90);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black", "Red", "Blue", "Green" });
            cmbColor.Location = new Point(6, 43);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(95, 23);
            cmbColor.TabIndex = 4;
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(trbLineWidth);
            groupBox2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox2.Location = new Point(349, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(131, 90);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "선 두께";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 45);
            trbLineWidth.Minimum = 1;
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(119, 45);
            trbLineWidth.TabIndex = 4;
            trbLineWidth.Value = 2;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.PaleGoldenrod;
            btnOpenFile.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.Location = new Point(486, 93);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(61, 48);
            btnOpenFile.TabIndex = 5;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.Salmon;
            btnSaveFile.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(553, 93);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(61, 48);
            btnSaveFile.TabIndex = 6;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.Location = new Point(12, 153);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(602, 252);
            picCanvas.TabIndex = 7;
            picCanvas.TabStop = false;
            picCanvas.Paint += picCanvas_Paint;
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(625, 417);
            Controls.Add(picCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Controls.Add(GroupBox);
            Name = "Form1";
            Text = "Form1";
            GroupBox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox GroupBox;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
    }
}
