namespace elshop
{
    partial class SkladForm
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
            this.BackButton = new System.Windows.Forms.Button();
            this.Fio = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTvr = new System.Windows.Forms.TextBox();
            this.tbMdl = new System.Windows.Forms.TextBox();
            this.tbPrc = new System.Windows.Forms.TextBox();
            this.tbKlv = new System.Windows.Forms.TextBox();
            this.tbPrvz = new System.Windows.Forms.TextBox();
            this.tbOps = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(713, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Fio
            // 
            this.Fio.AutoSize = true;
            this.Fio.Location = new System.Drawing.Point(13, 13);
            this.Fio.Name = "Fio";
            this.Fio.Size = new System.Drawing.Size(35, 13);
            this.Fio.TabIndex = 1;
            this.Fio.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(228, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 396);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Модель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Описание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Производитель";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Цена";
            // 
            // tbTvr
            // 
            this.tbTvr.Location = new System.Drawing.Point(12, 66);
            this.tbTvr.Name = "tbTvr";
            this.tbTvr.Size = new System.Drawing.Size(185, 20);
            this.tbTvr.TabIndex = 9;
            // 
            // tbMdl
            // 
            this.tbMdl.Location = new System.Drawing.Point(12, 116);
            this.tbMdl.Name = "tbMdl";
            this.tbMdl.Size = new System.Drawing.Size(185, 20);
            this.tbMdl.TabIndex = 10;
            // 
            // tbPrc
            // 
            this.tbPrc.Location = new System.Drawing.Point(12, 166);
            this.tbPrc.Name = "tbPrc";
            this.tbPrc.Size = new System.Drawing.Size(185, 20);
            this.tbPrc.TabIndex = 11;
            // 
            // tbKlv
            // 
            this.tbKlv.Location = new System.Drawing.Point(12, 216);
            this.tbKlv.Name = "tbKlv";
            this.tbKlv.Size = new System.Drawing.Size(185, 20);
            this.tbKlv.TabIndex = 12;
            // 
            // tbPrvz
            // 
            this.tbPrvz.Location = new System.Drawing.Point(12, 266);
            this.tbPrvz.Name = "tbPrvz";
            this.tbPrvz.Size = new System.Drawing.Size(185, 20);
            this.tbPrvz.TabIndex = 13;
            // 
            // tbOps
            // 
            this.tbOps.Location = new System.Drawing.Point(12, 316);
            this.tbOps.Multiline = true;
            this.tbOps.Name = "tbOps";
            this.tbOps.Size = new System.Drawing.Size(185, 81);
            this.tbOps.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(110, 415);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(87, 23);
            this.btnChange.TabIndex = 16;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // SkladForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbOps);
            this.Controls.Add(this.tbPrvz);
            this.Controls.Add(this.tbKlv);
            this.Controls.Add(this.tbPrc);
            this.Controls.Add(this.tbMdl);
            this.Controls.Add(this.tbTvr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Fio);
            this.Controls.Add(this.BackButton);
            this.Name = "SkladForm";
            this.Text = "SkladForm";
            this.Load += new System.EventHandler(this.SkladForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label Fio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTvr;
        private System.Windows.Forms.TextBox tbMdl;
        private System.Windows.Forms.TextBox tbPrc;
        private System.Windows.Forms.TextBox tbKlv;
        private System.Windows.Forms.TextBox tbPrvz;
        private System.Windows.Forms.TextBox tbOps;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
    }
}