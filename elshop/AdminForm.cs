using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elshop
{
    public partial class AdminForm : Form
    {
        Form1 form1;
        public int ID;
        public int selectRow;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public AdminForm()
        {
            InitializeComponent();
        }
        public AdminForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=LAPTOP-R7H40FQK\BIZARRO;Initial Catalog=ElectroShop;Integrated Security=True");
            da = new SqlDataAdapter($"Select Sotrudnik.Familiya, Sotrudnik.Imya, Sotrudnik.Otchestvo, Dolzhnost.Naimenovanie, Sotrudnik.Kod_sotrudnika from Vedomost_sotrudnika " +
                $"left join Sotrudnik on Vedomost_sotrudnika.Kod_sotrudnika = Sotrudnik.Kod_sotrudnika " +
                $"left join Dolzhnost on Vedomost_sotrudnika.Kod_dolzhnosti = Dolzhnost.Kod_dolzhnosti " +
                $"where Sotrudnik.[Kod_sotrudnika] = '{ID}'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Vedomost_sotrudnika");
            Fio.Text = ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[3].ToString() + ": " +
                ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[0].ToString() + " " + 
                ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[1].ToString() + " " + 
                ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[2].ToString();
            con.Close();
            GetList();
        }

        /*void GetList()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R7H40FQK\BIZARRO;Initial Catalog=ElectroShop;Integrated Security=True");
            da = new SqlDataAdapter($"Select Sotrudnik.Kod_sotrudnika, Sotrudnik.Familiya, Sotrudnik.Imya, Sotrudnik.Otchestvo, " +
                $"Sotrudnik.[Login], Sotrudnik.[Password], Dolzhnost.Naimenovanie, Dolzhnost.Oklad, Kod_vedomosti_sotrudnika, Dolzhnost.Kod_dolzhnosti from Vedomost_sotrudnika " +
                $"left join Sotrudnik on Vedomost_sotrudnika.Kod_sotrudnika = Sotrudnik.Kod_sotrudnika " +
                $"left join Dolzhnost on Vedomost_sotrudnika.Kod_dolzhnosti = Dolzhnost.Kod_dolzhnosti", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Vedomost_sotrudnika");
            dataGridView1.DataSource = ds.Tables["Vedomost_sotrudnika"];
            con.Close();
        }*/

        void GetList()
        {
            dataGridView1.DataSource = GetData.GetDataList($"Select Sotrudnik.Kod_sotrudnika, Sotrudnik.Familiya, Sotrudnik.Imya, Sotrudnik.Otchestvo, " +
                $"Sotrudnik.[Login], Sotrudnik.[Password], Dolzhnost.Naimenovanie, Dolzhnost.Oklad, Kod_vedomosti_sotrudnika, Dolzhnost.Kod_dolzhnosti from Vedomost_sotrudnika " +
                $"left join Sotrudnik on Vedomost_sotrudnika.Kod_sotrudnika = Sotrudnik.Kod_sotrudnika " +
                $"left join Dolzhnost on Vedomost_sotrudnika.Kod_dolzhnosti = Dolzhnost.Kod_dolzhnosti", "Vedomost_sotrudnika").Tables["Vedomost_sotrudnika"];
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            form1.Show(this);
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string KODSTR = "";
            string KODDOL = "";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (tbFam.Text != "" && tbImya.Text != "" && tbOtch.Text != "" && tbLog.Text != "" && tbPass.Text != "")
            {
                cmd.CommandText = String.Format("insert into Sotrudnik(Familiya,Imya,Otchestvo,Login,Password) values ('{0}','{1}','{2}','{3}','{4}')", 
                    tbFam.Text, tbImya.Text, tbOtch.Text, tbLog.Text, tbPass.Text);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter("SELECT MAX (Kod_sotrudnika) FROM Sotrudnik", con);
                ds = new DataSet();
                da.Fill(ds, "Sotrudnik");
                KODSTR = ds.Tables["Sotrudnik"].Rows[0].ItemArray[0].ToString();
                if (radioButton1.Checked) KODDOL = "1";
                else if (radioButton2.Checked) KODDOL = "2";
                else if (radioButton3.Checked) KODDOL = "3";
                else MessageBox.Show("Должность не выбрана");
                cmd.CommandText = String.Format("insert into Vedomost_sotrudnika(Kod_sotrudnika,Kod_dolzhnosti) values ('{0}','{1}')", KODSTR, KODDOL);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            GetList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selRow = dataGridView1.Rows[selectRow];
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                if (tbFam.Text != "" && tbImya.Text != "" && tbOtch.Text != "" && tbLog.Text != "" && tbPass.Text != "")
                {
                    cmd.CommandText = $"update Sotrudnik set Familiya = '{tbFam.Text}', Imya = '{tbImya.Text}', " +
                        $"Otchestvo = '{tbOtch.Text}', Login = '{tbLog.Text}', Password = '{tbPass.Text}' where Kod_sotrudnika = {selRow.Cells["Kod_sotrudnika"].Value}";
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
            con.Close();
            GetList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var selRow = dataGridView1.Rows[selectRow];
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"delete FROM Vedomost_sotrudnika WHERE [Kod_vedomosti_sotrudnika] = " +
                $"'{selRow.Cells["Kod_vedomosti_sotrudnika"].Value}' " +
                $"delete FROM Sotrudnik where [Kod_sotrudnika] = '{selRow.Cells["Kod_sotrudnika"].Value}'";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
            try
            {
                var selRow = dataGridView1.Rows[e.RowIndex];
                tbFam.Text = selRow.Cells["Familiya"].Value.ToString();
                tbImya.Text = selRow.Cells["Imya"].Value.ToString();
                tbOtch.Text = selRow.Cells["Otchestvo"].Value.ToString();
                tbLog.Text = selRow.Cells["Login"].Value.ToString();
                tbPass.Text = selRow.Cells["Password"].Value.ToString();
                tbFam.Text = selRow.Cells["Familiya"].Value.ToString();
                switch (selRow.Cells["Naimenovanie"].Value.ToString())
                {
                    case "Администратор":
                        radioButton1.Checked = true;
                        break;
                    case "Кладовщик":
                        radioButton2.Checked = true;
                        break;
                    case "Кассир":
                        radioButton3.Checked = true;
                        break;
                }
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }
    }
}