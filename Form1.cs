using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListviewNguyen
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Thiết lập chế độ hiển thị của ListView
            //lvSinhVien.View = View.Details;
            //lvSinhVien.FullRowSelect = true;
            //lvSinhVien.GridLines = true;
            //lvSinhVien.MultiSelect = false;
            //lvSinhVien.HideSelection = false;


            //// Thêm các cột vào ListView
            //lvSinhVien.Columns.Add("First Name", 160);
            //lvSinhVien.Columns.Add("Last Name", 93);
            //lvSinhVien.Columns.Add("Phone", 175);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
        string.IsNullOrWhiteSpace(txtLastName.Text) ||
        string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                // Hiển thị thông báo nếu một trong các trường bị bỏ trống
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng không thêm dữ liệu
            }
            
                // Tạo một ListViewItem với giá trị cột đầu tiên
                ListViewItem lvi = new ListViewItem(txtFirstName.Text);
                // Thêm dữ liệu cho các cột còn lại của dòng
                lvi.SubItems.Add(txtLastName.Text);
                lvi.SubItems.Add(txtPhone.Text);
                // Đưa dòng dữ liệu lên ListView
                lvSinhVien.Items.Add(lvi);

                // Xóa dữ liệu trong các TextBox sau khi thêm
                txtFirstName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();

            
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                // Lấy dòng được chọn
                ListViewItem lvi = lvSinhVien.SelectedItems[0];
                // Gán từng cột của dòng cho các giá trị tương ứng
                txtFirstName.Text = lvi.SubItems[0].Text;
                txtLastName.Text = lvi.SubItems[1].Text;
                txtPhone.Text = lvi.SubItems[2].Text;
            }
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                // Xóa mục được chọn khỏi ListView
                lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục để xóa.");
            }
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
        }

        private void txtEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                ListViewItem lvi = lvSinhVien.SelectedItems[0];
                // Cập nhật thông tin của mục đã chọn
                lvi.SubItems[0].Text = txtFirstName.Text;
                lvi.SubItems[1].Text = txtLastName.Text;
                lvi.SubItems[2].Text = txtPhone.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục để chỉnh sửa.");
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy sự kiện đóng form
            }
        }
    }
}
