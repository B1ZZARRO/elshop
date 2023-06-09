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
using Excel = Microsoft.Office.Interop.Excel;

namespace elshop
{
    public partial class CassaForm : Form
    {
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Worksheet xlSheet;
        Microsoft.Office.Interop.Excel.Range xlSheetRange;

        Form1 form1;
        public int ID;
        public int selectRow;
        string Fam;
        string Im;
        string Otc;
        int rowGen;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public CassaForm()
        {
            InitializeComponent();

        }

        public CassaForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void CassaForm_Load(object sender, EventArgs e)
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
            Fam = ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[0].ToString();
            Im = ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[1].ToString();
            Otc = ds.Tables["Vedomost_sotrudnika"].Rows[0].ItemArray[2].ToString();
            GetList();
            da = new SqlDataAdapter($"select * FROM Tovar", con);
            ds = new DataSet();
            da.Fill(ds, "Tovar");
            List<string> list = new List<string>();
            for (int i = 0; i < ds.Tables["Tovar"].Rows.Count; i++)
            {
                list.Add(ds.Tables["Tovar"].Rows[i].ItemArray[1].ToString());
            }
            cbTovar.DataSource = list;
            con.Close();
            
        }

        void GetList()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R7H40FQK\BIZARRO;Initial Catalog=ElectroShop;Integrated Security=True");
            da = new SqlDataAdapter($"Select Tovar.Naimenovanie, Tovar.Proizvoditel, Tovar.Model, Tovar.Cena, Tovar.Opisanie, Chek.Summa, Chek.Kolichestvo from Chek " +
                $"left join Sklad on Chek.Kod_sklada = Sklad.Kod_sklada " +
                $"left join Tovar on Sklad.Kod_tovara = Tovar.Kod_tovara", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Chek");
            dataGridView1.DataSource = ds.Tables["Chek"];
            con.Close();
        }

        void GetList1()
        {
            dataGridView1.DataSource = GetData.GetDataList($"Select Tovar.Naimenovanie, Tovar.Proizvoditel, Tovar.Model, Tovar.Cena, Tovar.Opisanie, Chek.Summa, Chek.Kolichestvo from Chek " +
                $"left join Sklad on Chek.Kod_sklada = Sklad.Kod_sklada " +
                $"left join Tovar on Sklad.Kod_tovara = Tovar.Kod_tovara", "Chek").Tables["Chek"];
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            form1.Show(this);
            this.Hide();
        }        

        private void btnChek_Click(object sender, EventArgs e)
        {
            generateExcelCheck(true, true);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            var selRow = dataGridView1.Rows[selectRow];
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"update Sklad set Kolichestvo = (Kolichestvo - {numKolvo.Value}) where Kod_tovara = (select Kod_tovara from Tovar where Naimenovanie='{cbTovar.SelectedItem}'); ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"insert into Chek(Kolichestvo, Summa, Kod_sklada, Kod_sotrudnika) values('{numKolvo.Value}', '{Summa.Text}', " +
                $"(select Kod_sklada from Sklad where Kod_tovara = (select Kod_tovara from Tovar where Naimenovanie = '{cbTovar.SelectedItem}')), " +
                $"(select Kod_Sotrudnika from Sotrudnik where Familiya = '{Fam}' and Imya = '{Im}' and Otchestvo = '{Otc}')); ";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void cbTovar_SelectedValueChanged(object sender, EventArgs e)
        {
            chngItemes();
        }

        private void numKolvo_ValueChanged(object sender, EventArgs e)
        {
            chngItemes();
        }
        void chngItemes()
        {
            try
            {
                float qwe;
                string asd;
                cmd = new SqlCommand();
                da = new SqlDataAdapter($"Select Tovar.Proizvoditel, Tovar.Model, Tovar.Opisanie, Tovar.Cena, Sklad.Kolichestvo from Sklad " +
                $"left join Tovar on Sklad.Kod_tovara = Tovar.Kod_tovara where Naimenovanie = '{cbTovar.SelectedItem}'", con);
                ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                da.Fill(ds, "Sklad");
                Proizvoditel.Text = ds.Tables["Sklad"].Rows[0].ItemArray[0].ToString();
                Model.Text = ds.Tables["Sklad"].Rows[0].ItemArray[1].ToString();
                Opisanie.Text = ds.Tables["Sklad"].Rows[0].ItemArray[2].ToString();
                Cena.Text = ds.Tables["Sklad"].Rows[0].ItemArray[3].ToString();
                con.Close();
                if (numKolvo.Value > Convert.ToInt32(ds.Tables["Sklad"].Rows[0].ItemArray[4]))
                {
                    MessageBox.Show("На складе не достаточно выбранного товара", "Ошибка ввода");
                    numKolvo.Value = Convert.ToInt32(ds.Tables["Sklad"].Rows[0].ItemArray[4]);
                }
                asd = ds.Tables["Sklad"].Rows[0].ItemArray[3].ToString();
                qwe = (float)Convert.ToInt32(asd);
                Summa.Text = Convert.ToString((int)numKolvo.Value * qwe);
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
            try
            {
                var selRow = dataGridView1.Rows[e.RowIndex];
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        private DataTable GetData(bool all)
        {
            DataTable dt = new DataTable();
            try
            {
                string str = $"top {rowGen} ";
                if (all) { str = ""; }
                da = new SqlDataAdapter($"Select Tovar.Naimenovanie, Tovar.Proizvoditel, Tovar.Model, Tovar.Cena, Tovar.Opisanie, Chek.Summa, Chek.Kolichestvo from Chek " +
                $"left join Sklad on Chek.Kod_sklada = Sklad.Kod_sklada " +
                $"left join Tovar on Sklad.Kod_tovara = Tovar.Kod_tovara", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Tab");
                dt = ds.Tables["Tab"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }

        void generateExcelCheck(bool tab, bool all)
        {
            xlApp = new Excel.Application();

            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Данные";
                //Выгрузка данных
                DataTable dt = new DataTable();
                if (tab) dt = GetData(all);
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;
                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);
                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }
                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }
                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;
                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
                //Отсоединяемся от Excel
                releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }
        }

        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}