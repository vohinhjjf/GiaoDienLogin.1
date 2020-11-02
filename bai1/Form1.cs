﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void delPassData(TextBox text);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Lấy file path mà chương trình chạy(VD:C:\...\bai1\bin\debug
            var CurrentDirectory = System.Environment.CurrentDirectory;
            //Lấy file path đã bỏ đi bin\debug -> Đây là địa chỉ của toàn bộ project
            string CurrentProjectD = Directory.GetParent(CurrentDirectory).Parent.FullName;
            //Ghép địa chỉ của toàn bộ project với thư mục chứa file database SQLite để kết nối SQLite
            SQLiteConnection conn = new SQLiteConnection(@"Data Source="+CurrentProjectD+@"\Database\NHAHANG.db;");
            try
            {
                conn.Open();
                string tk = textBoxUser.Text;
                string mk = textBoxPassword.Text;
                string sql = "select *from NGUOIDUNG where TaiKhoan='"+tk+"' and MatKhau='"+mk+"'";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader dta = cmd.ExecuteReader();
                if (dta.Read()==true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Form2 frm = new Form2();      //Tạo Form2
                    frm.Sender(textBox.Text);    //Gọi delegate
                    frm.Show();

                }    
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối");
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBoxUser.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "Tên đăng nhập";
            }    
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Mật khẩu";
            }
        }

        private void button_Click_2(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
