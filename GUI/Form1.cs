using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        BUS_ThanhVien busTV = new BUS_ThanhVien();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxHT.Text != "" && textBoxSDT.Text != "" && textBoxSDT.Text != "")
            {
                DTO_ThanhVien tv = new DTO_ThanhVien(0, textBoxHT.Text, textBoxSDT.Text, textBoxEmail.Text);

                if (busTV.themThanhVien(tv))
                {
                    MessageBox.Show("Thêm thành công.");
                    dataGridView1.DataSource = busTV.getThanhVien();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin!!!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busTV.getThanhVien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (textBoxHT.Text != "" && textBoxSDT.Text != "" && textBoxSDT.Text != "")
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    int ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    DTO_ThanhVien tv = new DTO_ThanhVien(ID, textBoxHT.Text, textBoxSDT.Text, textBoxEmail.Text);
                    if (busTV.suaThanhVien(tv))
                    {
                        MessageBox.Show("Sửa thành công.");
                        dataGridView1.DataSource = busTV.getThanhVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin!!!");
                }
            }
            else
            {
                MessageBox.Show("Chọn thành viên để sửa.");
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                if (busTV.xoaThanhVien(ID))
                {
                    MessageBox.Show("Xóa thành công.");
                    dataGridView1.DataSource = busTV.getThanhVien();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!!!");
                }
            }
            else
            {
                MessageBox.Show("Chọn thành viên để xóa.");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.SelectedRows[0];
            textBoxHT.Text = row.Cells[1].Value.ToString();
            textBoxSDT.Text = row.Cells[2].Value.ToString();
            textBoxEmail.Text = row.Cells[3].Value.ToString();
        }
    }
}
