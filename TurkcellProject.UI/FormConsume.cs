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
using TurkcellProject.ExtensionMethods;

namespace TurkcellProject.UI
{
    public partial class FormConsume : Form
    {

        public CustomerDAL customerDal;
        public CustomerProductDAL customerProductDal;
        public CustomerProduct insertedData;
        public ProductStatusDAL productStatusDal;
        public int productID;
        public Customer customer;
       

        public FormConsume(int productID)
        {
            InitializeComponent();
            customerDal = new CustomerDAL();
            customerProductDal = new CustomerProductDAL();
            insertedData = new CustomerProduct();
            productStatusDal = new ProductStatusDAL();
            this.productID = productID;
            this.customer = new Customer();
            
        }

        /// <summary>
        /// This method checks for if such a costumer with the customerSubNo that is entered exists, if they do add a customerproduct because that user has just consumed the product at hand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsume_Click(object sender, EventArgs e)
        {
            if (IsValidationWrong())
            {
                MessageBox.Show("Girdiğiniz verilerde bir hata var. Lütfen tekrar deneyiniz.");
                return;
            }
            bool doesCustomerExist = CheckIfCustomerExists();
            if (!doesCustomerExist)
            {
                MessageBox.Show("Böyle bir müşteri bulunmamaktadır.");
                return;
            }
            productStatusDal.Update(new ProductStatus()
            {
                ProductID = this.productID,
                StatusID = 3
            });
            insertedData.ProductID = this.productID;
            insertedData.CustomerID = this.customer.CustomerID;
            insertedData.CustomerProductDescription = rtxtDescription.Text;
            insertedData.CreatedDate = DateTime.Now;
            MyResult customerProductResult = customerProductDal.Insert(insertedData);
            MessageBox.Show(customerProductResult.ResultType == true ? "İşlem Başarılı" : "Hata oluştu");
            Clean();
        }

        private bool IsValidationWrong()
        {
            if (txtSubNo.Text.IsEmpty() || rtxtDescription.Text.IsEmpty())
            {
                return true;
            }
            else if (txtSubNo.Text.DoesContainLetter())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method cleans the form elements.
        /// </summary>
        private void Clean()
        {
            txtSubNo.Clear();
            rtxtDescription.Clear();
        }

        /// <summary>
        /// This method checks if the customer exists.
        /// </summary>
        /// <returns></returns>
        private bool CheckIfCustomerExists()
        {
            this.customer = customerDal.SelectSingleItem(Convert.ToInt32(txtSubNo.Text));
            return (this.customer != null);
        }

        private void FormConsume_Load(object sender, EventArgs e)
        {

        }
    }
}
