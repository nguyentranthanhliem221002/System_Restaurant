using BusinessLayer.Service;
using DataLayer.Service;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frm_roles_manager : Form
    {
        private readonly RoleService _roleService;
        public frm_roles_manager(RoleService roleService)
        {
            InitializeComponent();
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }
        private void frm_roles_manager_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }
        public void LoadRoles()
        {
            try
            {
                dgv_listRole.DataSource = _roleService.GetAllRoles();

                if (dgv_listRole.Columns.Contains("Name"))
                    dgv_listRole.Columns["Name"].HeaderText = "Tên quyền";

                if (dgv_listRole.Columns.Contains("Description"))
                    dgv_listRole.Columns["Description"].HeaderText = "Chú thích";


                if (dgv_listRole.Columns.Contains("Users"))
                {
                    dgv_listRole.Columns["Users"].Visible = false;
                }
                if (dgv_listRole.Columns.Contains("RoleType"))
                {
                    dgv_listRole.Columns["RoleType"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message);
            }
        }
    }
}
