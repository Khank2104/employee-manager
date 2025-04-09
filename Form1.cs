using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManager.Services;
using EmployeeManager.Data;
namespace EmployeeManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new string[] { "Đang làm việc", "Đã nghỉ" });
            cmbStatus.SelectedIndex = 0;
            LoadEmployees();
        }

        private void LoadEmployees(string keyword = "")
        {
            using (var context = new EmployeeContext())
            {
                var employees = context.Employees
                    .Where(e => string.IsNullOrEmpty(keyword) || e.Name.Contains(keyword))
                    .Select(e => new
                    {
                        e.EmployeeId,
                        e.Name,
                        e.Role,
                        e.Status,
                        e.ParkingLotName 
                    })
                    .ToList();

                dgvEmployees.DataSource = employees;
            }
            dgvEmployees.Columns["EmployeeId"].HeaderText = "Mã NV";
            dgvEmployees.Columns["Name"].HeaderText = "Tên";
            dgvEmployees.Columns["Role"].HeaderText = "Vai trò";
            dgvEmployees.Columns["Status"].HeaderText = "Trạng thái";
            dgvEmployees.Columns["ParkingLotName"].HeaderText = "Bãi đỗ xe";

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ tên và vai trò.");
                return;
            }

            using (var context = new EmployeeContext())
            {
                var service = new EmployeeService(context);
                bool result = service.AddEmployee(
                    txtName.Text.Trim(),
                    txtRole.Text.Trim(),
                    cmbStatus.SelectedItem?.ToString(),
                    txtParkingLotName.Text.Trim() // textbox bạn thêm cho tên bãi đỗ xe
                );

                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadEmployees();
                    txtName.Clear();
                    txtRole.Clear();
                    txtParkingLotName.Clear();
                    cmbStatus.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Kiểm tra lại dữ liệu.");
                }
            }
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployees(txtSearch.Text.Trim());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadEmployees();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
