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
using TurkcellProject.DTO;

namespace TurkcellProject.UI
{
    public partial class FormProductList : Form
    {
        public FormProductList()
        {
            InitializeComponent();
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
            //LoadAllProducts();
            FillCredentials();
            HideFromStaff();
        }

        /// <summary>
        /// This method disables "Tüm Varlıklar" section if the user logged in is a staff(Personel).
        /// </summary>
        private void HideFromStaff()
        {
            if (FormLogin.theUser.UserRoleID == 1)
            {
                lblAllProducts.Enabled = false;
            }
            
        }

        /// <summary>
        /// This method fills the profile credentials according to the user who logged in
        /// </summary>
        private void FillCredentials()
        {
            RoleDAL roleDal = new RoleDAL();
            string userRole = roleDal.GetRole(FormLogin.theUser.UserRoleID).RoleName;
            string profileCredential = FormLogin.theUser.UserName + " " + FormLogin.theUser.UserSurname + "-" + userRole;
            lblProfile.Text = profileCredential;
        }

        /// <summary>
        /// This method loads the products.
        /// </summary>
        /// <param name="loadedItems"></param>
        private void LoadProducts(List<ProductListView> loadedItems)
        {
            lwProducts.Items.Clear();
            foreach (var item in loadedItems)
            {
                ListViewItem lwItem = new ListViewItem(item.ProductID.ToString());
                lwItem.SubItems.Add(item.Barcode.ToString());
                lwItem.SubItems.Add(item.ProductTypeName);
                lwItem.SubItems.Add(item.CurrentPrice.ToString());
                lwItem.SubItems.Add(item.ModelName);
                lwItem.SubItems.Add(item.BrandName);
                
                lwProducts.Items.Add(lwItem);
                
            }
        }

        /// <summary>
        /// This method is activated when the "Tüm Varliklar" label is clicked. And then it fetches all the data that the user is allowed to see.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAllProducts_Click(object sender, EventArgs e)
        {
            ProductWithBarcodeDAL allProducts = new ProductWithBarcodeDAL();
            LoadProducts(allProducts.Select());
        }

        /// <summary>
        /// This method is activated when the "Varliklarim" label is clicked. And then it fetches the debits who assigned to that user only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMyProducts_Click(object sender, EventArgs e)
        {
            UserDebitWithBarcodeDAL myDebitProducts = new UserDebitWithBarcodeDAL();
            LoadProducts(myDebitProducts.SelectWithID(FormLogin.theUser.UserID));
        }

        /// <summary>
        /// This method is activated when the "Ekip Varliklari" label is clicked. And then it fetches the debits who assigned to that user's team only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMyTeamProducts_Click(object sender, EventArgs e)
        {
            TeamDebitWithBarcodeDAL teamDebitProducts = new TeamDebitWithBarcodeDAL();
            LoadProducts(teamDebitProducts.SelectWithID(FormLogin.theUser.UserTeamID));
        }

        /// <summary>
        /// This method is activated when the "Takip ettiğim varliklar" label is clicked. And then it fetches the debits who is created by that user only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCreatedByUser_Click(object sender, EventArgs e)
        {
            CreatedByUserWithBarcodeDAL createdByMeProducts = new CreatedByUserWithBarcodeDAL();
            LoadProducts(createdByMeProducts.SelectWithID(FormLogin.theUser.UserID));
        }
    }
}
