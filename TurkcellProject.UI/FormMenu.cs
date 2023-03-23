using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkcellProject.UI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is executed when the varlik listeleme is clicked. It opens the ProductList form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void varlıkListelemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductList formProductList = new FormProductList();
            formProductList.MdiParent = this;
            formProductList.Show();
        }

        /// <summary>
        /// This method is executed when the varlik güncelleme is clicked. It opens the Update Product form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void varlıkGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateProduct formUpdateProduct = new FormUpdateProduct();
            formUpdateProduct.MdiParent = this;
            formUpdateProduct.Show();
        }

        /// <summary>
        /// This method is executed when the kullanıcı zimmeti raporu is clicked. It opens the ProductList form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kullanıcıZimmetiRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserDebitView formUserDebitView = new FormUserDebitView();
            formUserDebitView.MdiParent = this;
            formUserDebitView.Show();
        }

        /// <summary>
        /// This method is executed when the ekip zimmeti raporu is clicked. It opens the ProductList form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ekipZimmetiRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTeamDebitView formTeamDebitView = new FormTeamDebitView();
            formTeamDebitView.MdiParent = this;
            formTeamDebitView.Show();
        }
    }
}
