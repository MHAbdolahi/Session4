using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Personel> list = new List<Personel>();
        private void button1_Click(object sender, EventArgs e)
        {

            if (mtbCode.Text == "")
            {
                MessageBox.Show("کد وارد نشده است.", "خطا", MessageBoxButtons.OK);
                return;
            }

            // اگر شماره همراه کمتر از 11 رقم بود خطا بدهد 
            if (mtbMobile.Text.Length < 10)
            {
                MessageBox.Show("شماره همراه 11 رقم می باشد");
                return;
            }

            // شی گرفتن از یک کلاس 
            Personel personel = new Personel();
            personel.Code = Convert.ToInt32(mtbCode.Text);
            personel.Name = txtName.Text;
            personel.Family = txtFamily.Text;
            personel.Mobile = mtbMobile.Text;
            personel.Address = txtAddress.Text;

            list.Add(personel);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].HeaderText = "کد";
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[3].HeaderText = "نام پدر";
            dataGridView1.Columns[4].HeaderText = "موبایل";



            // SQL Command  در جلسه های آینده 

            MessageBox.Show("درج شد");

            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {


            MessageBox.Show("ویرایش شد.");

            ClearForm();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            MessageBox.Show("حذف شد.");

            ClearForm();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


        private void ClearForm()
        {
            mtbCode.Text = "";
            txtName.Text = "";
            txtFamily.Text = "";
            mtbMobile.Text = "";
            txtAddress.Text = "";
            mtbCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // شی گرفتن از یک کلاس 
            Personel personel = new Personel();

            personel.Code = 1;
            personel.Name = "محمدحسین";
            personel.Family = "عبدالهی";
            personel.Mobile = "09303712953";
            personel.Address = "مشهد 17 شهریور";

            list.Add(personel);

            // کلمه new مهم می باشد 
            personel = new Personel();
            personel.Code = 2;
            personel.Name = "نیما";
            personel.Family = "کیهان";
            personel.Mobile = "0915321321";
            personel.Address = "مشهد";

            list.Add(personel);

            personel = new Personel();
            personel.Code = 3;
            personel.Name = "امین";
            personel.Family = "کیهان";
            personel.Mobile = "09158004531";
            personel.Address = "مشهد 17 شهریور";

            list.Add(personel);

            personel = new Personel();
            personel.Code = 3;
            personel.Name = "احمد";
            personel.Family = "کیهان";
            personel.Mobile = "09908520258";
            personel.Address = "مشهد مصلی";

            list.Add(personel);

            dataGridView1.DataSource = list;

            comboBox1.SelectedIndex = 0;
        }

        string selectedFilterItem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "کد":
                    lblFindTitle.Text = "کد";
                    selectedFilterItem = "Code";
                    break;
                case "نام":
                    selectedFilterItem = "Name";
                    lblFindTitle.Text = "نام";
                    break;
                default:
                    break;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "کد":
                    int code = Convert.ToInt32(txtFind.Text);

                    var a = from i in list
                            where i.Code == code
                            select i;

                    dataGridView1.DataSource = a.ToList(); // ToList() مهم می باشد
                    break;
                case "نام":

                    var query = from i in list
                                where i.Name == txtFind.Text
                                select i;
                    dataGridView1.DataSource = query.ToList(); // ToList() مهم می باشد
                    break;
                default:
                    break;
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSort.SelectedItem)
            {
                case "صعودی":

                    switch (selectedFilterItem)
                    {
                        case "Code":
                            var queryCode = from i in list
                                        orderby i.Code ascending
                                        select i;

                            dataGridView1.DataSource = queryCode.ToList();
                            break;
                        case "Name":
                                var queryName = from i in list
                                            orderby i.Name ascending
                                            select i;

                                dataGridView1.DataSource = queryName.ToList();
                            
                            break;
                        default:
                            break;
                    }


                    break;
                case "نزولی":
                    break;
                default:
                    break;
            }
        }
    }
}
