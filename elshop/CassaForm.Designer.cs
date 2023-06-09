namespace elshop
{
    partial class CassaForm
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
            this.Fio = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.btnChek = new System.Windows.Forms.Button();
            this.cbTovar = new System.Windows.Forms.ComboBox();
            this.numKolvo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cena = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Summa = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.Opisanie = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.Proizvoditel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numKolvo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Fio
            // 
            this.Fio.AutoSize = true;
            this.Fio.Location = new System.Drawing.Point(12, 12);
            this.Fio.Name = "Fio";
            this.Fio.Size = new System.Drawing.Size(35, 13);
            this.Fio.TabIndex = 0;
            this.Fio.Text = "label1";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(713, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // btnChek
            // 
            this.btnChek.Location = new System.Drawing.Point(681, 56);
            this.btnChek.Name = "btnChek";
            this.btnChek.Size = new System.Drawing.Size(107, 23);
            this.btnChek.TabIndex = 3;
            this.btnChek.Text = "Распечатать чеки";
            this.btnChek.UseVisualStyleBackColor = true;
            this.btnChek.Click += new System.EventHandler(this.btnChek_Click);
            // 
            // cbTovar
            // 
            this.cbTovar.FormattingEnabled = true;
            this.cbTovar.Location = new System.Drawing.Point(15, 58);
            this.cbTovar.Name = "cbTovar";
            this.cbTovar.Size = new System.Drawing.Size(197, 21);
            this.cbTovar.TabIndex = 4;
            this.cbTovar.SelectedValueChanged += new System.EventHandler(this.cbTovar_SelectedValueChanged);
            // 
            // numKolvo
            // 
            this.numKolvo.Location = new System.Drawing.Point(350, 59);
            this.numKolvo.Name = "numKolvo";
            this.numKolvo.Size = new System.Drawing.Size(91, 20);
            this.numKolvo.TabIndex = 5;
            this.numKolvo.ValueChanged += new System.EventHandler(this.numKolvo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Товар";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Цена за шт:";
            // 
            // Cena
            // 
            this.Cena.AutoSize = true;
            this.Cena.Location = new System.Drawing.Point(291, 61);
            this.Cena.Name = "Cena";
            this.Cena.Size = new System.Drawing.Size(35, 13);
            this.Cena.TabIndex = 9;
            this.Cena.Text = "label4";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(568, 56);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(107, 23);
            this.btnBuy.TabIndex = 11;
            this.btnBuy.Text = "Оформить заказ";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Сумма:";
            // 
            // Summa
            // 
            this.Summa.AutoSize = true;
            this.Summa.Location = new System.Drawing.Point(497, 61);
            this.Summa.Name = "Summa";
            this.Summa.Size = new System.Drawing.Size(35, 13);
            this.Summa.TabIndex = 13;
            this.Summa.Text = "label6";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 307);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Описание:";
            // 
            // Opisanie
            // 
            this.Opisanie.AutoSize = true;
            this.Opisanie.Location = new System.Drawing.Point(78, 105);
            this.Opisanie.Name = "Opisanie";
            this.Opisanie.Size = new System.Drawing.Size(35, 13);
            this.Opisanie.TabIndex = 16;
            this.Opisanie.Text = "label8";
            // 
            // Model
            // 
            this.Model.AutoSize = true;
            this.Model.Location = new System.Drawing.Point(53, 82);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(35, 13);
            this.Model.TabIndex = 17;
            this.Model.Text = "label4";
            // 
            // Proizvoditel
            // 
            this.Proizvoditel.AutoSize = true;
            this.Proizvoditel.Location = new System.Drawing.Point(12, 82);
            this.Proizvoditel.Name = "Proizvoditel";
            this.Proizvoditel.Size = new System.Drawing.Size(35, 13);
            this.Proizvoditel.TabIndex = 18;
            this.Proizvoditel.Text = "label6";
            // 
            // CassaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Proizvoditel);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.Opisanie);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Summa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.Cena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numKolvo);
            this.Controls.Add(this.cbTovar);
            this.Controls.Add(this.btnChek);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.Fio);
            this.Name = "CassaForm";
            this.Text = "CassaForm";
            this.Load += new System.EventHandler(this.CassaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numKolvo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Fio;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button btnChek;
        private System.Windows.Forms.ComboBox cbTovar;
        private System.Windows.Forms.NumericUpDown numKolvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Cena;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Summa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Opisanie;
        private System.Windows.Forms.Label Model;
        private System.Windows.Forms.Label Proizvoditel;
    }
}