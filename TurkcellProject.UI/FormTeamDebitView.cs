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
    public partial class FormTeamDebitView : Form
    {
        public TeamDebitViewDAL teamDebitViewDal;

        public FormTeamDebitView()
        {
            InitializeComponent();
            teamDebitViewDal = new TeamDebitViewDAL();
        }

        private void FormTeamDebitView_Load(object sender, EventArgs e)
        {
            LoadAll();
        }


        /// <summary>
        /// Loads all the userDebitViews
        /// </summary>
        private void LoadAll()
        {
            lwTeamDebitView.Items.Clear();
            foreach (var item in teamDebitViewDal.Select())
            {
                ListViewItem lwItem = new ListViewItem(item.DebitViewTeam.DebitReasonName);
                lwItem.SubItems.Add(item.DebitViewTeam.DebitTypeName);
                lwItem.SubItems.Add(item.TeamName);
                lwItem.SubItems.Add(item.DebitViewTeam.ModelName);
                lwItem.SubItems.Add(item.DebitViewTeam.BrandName);

                lwTeamDebitView.Items.Add(lwItem);

            }
        }
    }
}
