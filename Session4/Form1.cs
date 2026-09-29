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

        }
    }
}
