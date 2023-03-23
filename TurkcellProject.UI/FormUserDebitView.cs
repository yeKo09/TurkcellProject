using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurkcellProject.DAL;

namespace TurkcellProject.UI
{
    public partial class FormUserDebitView : Form
    {
        public UserDebitViewDAL userDebitViewDal;

        public FormUserDebitView()
        {
            InitializeComponent();
            userDebitViewDal = new UserDebitViewDAL();
        }

        private void FormUserDebitView_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        /// <summary>
        /// Loads all the teamDebitViews
        /// </summary>
        private void LoadAll()
        {
            lwUserDebitView.Items.Clear();
            foreach (var item in userDebitViewDal.Select())
            {
                ListViewItem lwItem = new ListViewItem(item.DebitViewUser.DebitReasonName);
                lwItem.SubItems.Add(item.DebitViewUser.DebitTypeName);
                lwItem.SubItems.Add(item.DebitUserFullname);
                lwItem.SubItems.Add(item.DebitViewUser.ModelName);
                lwItem.SubItems.Add(item.DebitViewUser.BrandName);

                lwUserDebitView.Items.Add(lwItem);

            }
        }
    }
}
