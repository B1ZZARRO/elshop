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
    public partial class SkladForm : Form
    {
        Form1 form1;
        public int ID;
        public int selectRow;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public SkladForm()
        {
            InitializeComponent();
        }
        public SkladForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void SkladForm_Load(object sender, EventArgs e)
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

        void GetList()
        {
            dataGridView1.DataSource = GetData.GetDataList($"Select Tovar.Naimenovanie, Tovar.Proizvoditel, " +
                $"Tovar.Model, Tovar.Cena, Sklad.Kolichestvo, Tovar.Opisanie, Tovar.Kod_tovara from Sklad " +
                $"left join Tovar on Sklad.Kod_tovara = Tovar.Kod_tovara", "Sklad").Tables["Sklad"];       
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            form1.Show(this);
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string KODTVR = "";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("insert into Tovar(Naimenovanie,Model,Cena,Proizvoditel,Opisanie) values ('{0}','{1}','{2}','{3}','{4}')", tbTvr.Text, tbMdl.Text, tbPrc.Text, tbPrvz.Text, tbOps.Text);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter("SELECT MAX (Kod_tovara) FROM Tovar", con);
            ds = new DataSet();
            da.Fill(ds, "Tovar");
            KODTVR = ds.Tables["Tovar"].Rows[0].ItemArray[0].ToString();
            cmd.CommandText = String.Format("insert into Sklad(Kod_tovara,Kolichestvo) values ('{0}','{1}')", KODTVR, tbKlv.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int kolvo;
            var selRow = dataGridView1.Rows[selectRow];
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                if (tbTvr.Text != "" && tbMdl.Text != "" && tbPrc.Text != "" && tbPrvz.Text != "" && tbOps.Text != "")
                {
                    cmd.CommandText = $"update Tovar set Naimenovanie = '{tbTvr.Text}', Model = '{tbMdl.Text}', " +
                        $"Cena = '{tbPrc.Text}', Proizvoditel = '{tbPrvz.Text}', Opisanie = '{tbOps.Text}' where Kod_tovara = {selRow.Cells["Kod_tovara"].Value}";
                    cmd.ExecuteNonQuery();

                }
                kolvo = Convert.ToInt32(tbKlv.Text);
                if (kolvo > (int)selRow.Cells["Kolichestvo"].Value)
                {
                    cmd.CommandText = $"update Sklad set Kolichestvo = '{tbKlv.Text}' where Kod_tovara = {selRow.Cells["Kod_tovara"].Value}";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
            con.Close();
            GetList();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
            try
            {
                var selRow = dataGridView1.Rows[e.RowIndex];
                tbTvr.Text = selRow.Cells["Naimenovanie"].Value.ToString();
                tbMdl.Text = selRow.Cells["Model"].Value.ToString();
                tbPrc.Text = selRow.Cells["Cena"].Value.ToString();
                tbPrvz.Text= selRow.Cells["Proizvoditel"].Value.ToString();
                tbOps.Text = selRow.Cells["Opisanie"].Value.ToString();
                tbKlv.Text = selRow.Cells["Kolichestvo"].Value.ToString();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }
    }
}