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
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AutorizationButton_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=LAPTOP-R7H40FQK\BIZARRO;Initial Catalog=ElectroShop;Integrated Security=True");
            da = new SqlDataAdapter($"Select Sotrudnik.[Login], Sotrudnik.[Password], Dolzhnost.Kod_dolzhnosti, Sotrudnik.Kod_sotrudnika from Vedomost_sotrudnika " +
                $"left join Sotrudnik on Vedomost_sotrudnika.Kod_sotrudnika = Sotrudnik.Kod_sotrudnika " +
                $"left join Dolzhnost on Vedomost_sotrudnika.Kod_dolzhnosti = Dolzhnost.Kod_dolzhnosti " +
                $"WHERE[Login] = '{textBoxLogin.Text}' AND[Password] = '{textBoxPassword.Text}'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Vedomost_sotrudnika");
            if (ds.Tables["Vedomost_sotrudnika"].Rows.Count > 0)
            {
                if ((int)ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[2] == 1)
                {
                    AdminForm adminForm = new AdminForm(this);
                    adminForm.ID = Convert.ToInt32(ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[3]);
                    adminForm.Show();
                    this.Hide();
                }
                if ((int)ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[2] == 2)
                {
                    SkladForm skladForm = new SkladForm(this);
                    skladForm.ID = Convert.ToInt32(ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[3]);
                    skladForm.Show();
                    this.Hide();
                }
                if ((int)ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[2] == 3)
                {
                    CassaForm cassaForm = new CassaForm(this);
                    cassaForm.ID = Convert.ToInt32(ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[3]);
                    cassaForm.Show();
                    this.Hide();
                }
            }
            else MessageBox.Show("Неверный логин или пароль");
            con.Close();     
        }
    }
}