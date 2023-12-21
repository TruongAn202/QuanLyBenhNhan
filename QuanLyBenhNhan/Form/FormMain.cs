using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // kéo 
using System.IO;

namespace QuanLyBenhNhan
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        
        private Form activeForm = null; // hoạt động form, != null thi form dang hoat dong
        private void openChildform(Form childForm) // setup mở form con
        {
            if(activeForm != null) 
            {
                activeForm.Close(); // nếu khác null thì đóng form hiện tại
            }
            activeForm = childForm; // gán form con vào
            childForm.TopLevel = false; //Nếu thuộc tính này(TopLevel) được thiết lập thành false, form con sẽ được hiển thị bên trong form cha, true thì sẽ hiển thị cửa sổ mới ko giới hạn kích thước
            childForm.FormBorderStyle = FormBorderStyle.None; // cho from ko viền
            childForm.Dock = DockStyle.Fill; // form con, thuộc tính dock => fill
            panelChildForm.Controls.Add(childForm); //(Thêm childForm vào panel panelChildForm),panelChildForm là một đối tượng Panel, và childForm là một đối tượng Form. đối tượng childForm sẽ được thêm vào danh sách các thành phần con của panelChildForm, và sẽ hiển thị bên trong panel này
            panelChildForm.Tag = childForm;//cho phép truy cập vào đối tượng childForm vừa thêm ở trên từ panel panelChildForm bằng cách sử dụng thuộc tính Tag
            childForm.BringToFront(); // đưa form con lên trước
            childForm.Show();
  
        }  

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) // hành dộng hỏi khi nhấn thoát
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Cảnh báo!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK) // hiển thị messagebox có title là thông báo, nội dung :"", nếu != nhấn ok thì cancel = true(tức là bấm vào cancel)
            {
                e.Cancel = true;
            }
        }


        
        private void btnHome_Click(object sender, EventArgs e) // click vào cái hình
        {

            if (activeForm != null)
            {
                activeForm.Close(); // nếu khác null thì đóng form hiện tại
            }
        }

        
       
        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start(); // cho time vừa tạo chạy           
            
            string absolutePath = "iconMini.png"; // để hỉnh ở ngoài, click vào hình chọn: copy to Output -> copu if newer, thêm ảnh: click phải dự án -> add -> Existring items
            Image image = Image.FromFile(absolutePath);

            // image -> icon
            Icon icon = Icon.FromHandle(((Bitmap)image).GetHicon());

            // Đặt Icon cho Form
            this.Icon = icon;

            //dulieu
            TruyCapDuLieu.docFile("data.dat");     
        }

        private void timer1_Tick(object sender, EventArgs e) // tạo 1 timer rồi click vào
        {
            labTime.Text = DateTime.Now.ToLongTimeString(); // hiện giờ
            labDay.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        


        private void btnInsertCha_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnCloseMain_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            openChildform(new FormQLHD());
        }

        private void btnQLBN_Click(object sender, EventArgs e)
        {
            openChildform(new FormQLBN());
        }

        private void btnQLBS_Click(object sender, EventArgs e)
        {
            openChildform(new FormQLBS());
        }

        private void btnQLPK_Click(object sender, EventArgs e)
        {
            openChildform(new FormQLPK());
        }

        private void btnQLDV_Click(object sender, EventArgs e)
        {
            openChildform(new FormQLDV());
        }
    }
}
