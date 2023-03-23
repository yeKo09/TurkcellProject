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
    public partial class FormAddDebit : Form
    {

        public DebitTypeDAL debitTypeDal;
        public DebitDAL debitDal;
        public DebitReasonDAL debitReasonDal;
        public ProductStatusDAL productStatusDal;
        public Debit insertedDebit;
        public ProductWarehouseDAL productWarehouseDal;
        public TeamDAL teamDal;
        public UserDAL userDal;
        public UserDebitDAL userDebitDal;
        public TeamDebitDAL teamDebitDal;
        public int productID;
        

        public FormAddDebit(int productID)
        {
            InitializeComponent();
            debitTypeDal = new DebitTypeDAL();
            debitReasonDal = new DebitReasonDAL();
            insertedDebit = new Debit();
            debitDal = new DebitDAL();
            productStatusDal = new ProductStatusDAL();
            productWarehouseDal = new ProductWarehouseDAL();
            teamDal = new TeamDAL();
            userDal = new UserDAL();
            teamDebitDal = new TeamDebitDAL();
            userDebitDal = new UserDebitDAL();
            this.productID = productID;
          
        }

        private void FormAddDebit_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }
        /// <summary>
        /// This method loads the two combobox.
        /// </summary>
        private void LoadInformation()
        {
            cmbDebitReason.DataSource = debitReasonDal.Select();
            cmbDebitType.DataSource = debitTypeDal.Select();
        }

        /// <summary>
        /// this method gathers all the information and adds a debit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDebit_Click(object sender, EventArgs e)
        {
            if (IsValidationWrong())
            {
                MessageBox.Show("Girdiğiniz verilerde bir hata oluştu. Lütfen tekrar deneyiniz.");
                return;
            }
            insertedDebit.DebitReasonID = (cmbDebitReason.SelectedItem as DebitReason).DebitReasonID;
            insertedDebit.DebitTypeID = (cmbDebitType.SelectedItem as DebitType).DebitTypeID;
            insertedDebit.DebitStartDate = dtEntryDate.Value;
            insertedDebit.DebitEndDate = dtEndDate.Value;
            insertedDebit.DebitDescription = rtxtDescription.Text;
            insertedDebit.ProductID = this.productID;
            insertedDebit.DebitCreatedByID = FormLogin.theUser.UserID;
            insertedDebit.DebitCreatedDate = DateTime.Now;
            
           
            MyResult debitResult = debitDal.Insert(insertedDebit);
            MyResult productStatusResult = productStatusDal.Update(new ProductStatus()
            {
                ProductID = this.productID,
                StatusID = 1
            });
            InsertUserDebit(debitResult);
            
            MessageBox.Show("Zimmet başarıyla atandı!");
            Clean();
        }

        private bool IsValidationWrong()
        {
            if (txtDebitOwner.Text.IsEmpty() || rtxtDescription.Text.IsEmpty())
            {
                return true;
            }
            else if (txtDebitOwner.Text.DoesContainLetter())
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
            txtDebitOwner.Clear();
            cmbDebitReason.SelectedIndex = 0;
            cmbDebitType.SelectedIndex = 0;
            dtEntryDate.Value = DateTime.Now;
            dtEndDate.Value = DateTime.Now;
            rtxtDescription.Clear();
        }

        /// <summary>
        /// This method checks if the debit belongs to a personel or a team and then tries to find such record.
        /// If it does, then that means it is time to insert a new userDebit
        /// </summary>
        /// <param name="debitResult"></param>
        private void InsertUserDebit(MyResult debitResult)
        {
            if (insertedDebit.DebitTypeID == 1)
            {
                if (userDal.SelectSingleItem(Convert.ToInt32(txtDebitOwner.Text)) == null)
                {
                    MessageBox.Show("Personel bulunamadı...");
                }
                else
                {
                    userDebitDal.Insert(new UserDebit()
                    {
                        UserID = Convert.ToInt32(txtDebitOwner.Text),
                        DebitID = ((int)debitResult.Result)
                    });
                }

            }
            else if (insertedDebit.DebitTypeID == 2)
            {
                if (teamDal.SelectSingleItem(Convert.ToInt32(txtDebitOwner.Text)) == null)
                {
                    MessageBox.Show("Ekip bulunamadı...");
                }
                else
                {
                    teamDebitDal.Insert(new TeamDebit()
                    {
                        TeamID = Convert.ToInt32(txtDebitOwner.Text),
                        DebitID = ((int)debitResult.Result)
                    });
                }
            }
        }
    }
}
