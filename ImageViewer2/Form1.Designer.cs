namespace ImageViewer2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CreateGrid = new System.Windows.Forms.Button();
            this.Y_ = new System.Windows.Forms.NumericUpDown();
            this.X_ = new System.Windows.Forms.NumericUpDown();
            this.Correct_button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CorrectionGrid = new System.Windows.Forms.DataGridView();
            this.StandartGrid = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandartGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 23);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(148, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "Seek";
            this.toolTip1.SetToolTip(this.button10, "(S)eek to index");
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(90, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(52, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "Refresh";
            this.toolTip1.SetToolTip(this.button9, "(R)efresh directory");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(43, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(41, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Open";
            this.toolTip1.SetToolTip(this.button7, "(O)pen new file");
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(423, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(362, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Rename";
            this.toolTip1.SetToolTip(this.button3, "Rename curren image (F2)");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Next";
            this.toolTip1.SetToolTip(this.button2, "Show next image (right arrow)");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Prev";
            this.toolTip1.SetToolTip(this.button1, "Show previous image (left arrow)");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 730);
            this.panel2.TabIndex = 1;
            this.panel2.Layout += new System.Windows.Forms.LayoutEventHandler(this.panel2_Layout);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.CreateGrid);
            this.panel3.Controls.Add(this.Y_);
            this.panel3.Controls.Add(this.X_);
            this.panel3.Controls.Add(this.Correct_button);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.CorrectionGrid);
            this.panel3.Controls.Add(this.StandartGrid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 730);
            this.panel3.TabIndex = 1;
            // 
            // CreateGrid
            // 
            this.CreateGrid.Location = new System.Drawing.Point(146, 509);
            this.CreateGrid.Name = "CreateGrid";
            this.CreateGrid.Size = new System.Drawing.Size(75, 23);
            this.CreateGrid.TabIndex = 11;
            this.CreateGrid.Text = "Create";
            this.CreateGrid.UseVisualStyleBackColor = true;
            this.CreateGrid.Click += new System.EventHandler(this.CreateGrid_Click);
            // 
            // Y_
            // 
            this.Y_.Location = new System.Drawing.Point(90, 509);
            this.Y_.Name = "Y_";
            this.Y_.Size = new System.Drawing.Size(50, 20);
            this.Y_.TabIndex = 10;
            // 
            // X_
            // 
            this.X_.Location = new System.Drawing.Point(12, 510);
            this.X_.Name = "X_";
            this.X_.Size = new System.Drawing.Size(55, 20);
            this.X_.TabIndex = 9;
            // 
            // Correct_button
            // 
            this.Correct_button.Location = new System.Drawing.Point(9, 535);
            this.Correct_button.Name = "Correct_button";
            this.Correct_button.Size = new System.Drawing.Size(75, 23);
            this.Correct_button.TabIndex = 8;
            this.Correct_button.Text = "Correct";
            this.Correct_button.UseVisualStyleBackColor = true;
            this.Correct_button.Click += new System.EventHandler(this.Correct_button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 490);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Линии";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 512);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Корректируемые координаты (красная сетка)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Эталонные координаты (Синяя сетка)";
            // 
            // CorrectionGrid
            // 
            this.CorrectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CorrectionGrid.Location = new System.Drawing.Point(10, 278);
            this.CorrectionGrid.Name = "CorrectionGrid";
            this.CorrectionGrid.Size = new System.Drawing.Size(240, 202);
            this.CorrectionGrid.TabIndex = 1;
            this.CorrectionGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CorrectionGrid_CellValueChanged);
            // 
            // StandartGrid
            // 
            this.StandartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StandartGrid.Location = new System.Drawing.Point(10, 30);
            this.StandartGrid.Name = "StandartGrid";
            this.StandartGrid.Size = new System.Drawing.Size(240, 202);
            this.StandartGrid.TabIndex = 0;
            this.StandartGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.StandartGrid_CellValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1184, 730);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.pictureBox1_Layout);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(690, 230);
            this.Name = "Form1";
            this.Text = "ImageViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandartGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView CorrectionGrid;
        private System.Windows.Forms.DataGridView StandartGrid;
        private System.Windows.Forms.Button Correct_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Y_;
        private System.Windows.Forms.NumericUpDown X_;
        private System.Windows.Forms.Button CreateGrid;
        private System.Windows.Forms.Button button5;
    }
}

