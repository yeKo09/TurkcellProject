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
    public partial class FormLogin : Form
    {
        public static User theUser;
        public FormLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        /// <summary>
        /// when the giriş yap button is clicked, this method works and check the user's credentials to give them the authorization or not. Whether it is a fail or success, the method will dsiplay a message informing the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValidationWrong())
            {
                MessageBox.Show("Eksik değer(ler) girdiniz. Lütfen tekrar deneyiniz.");
                return;
            }
            UserLoginDAL userLoginDal = new UserLoginDAL();
            User userLogined = userLoginDal.Login(txtEmail.Text, txtPassword.Text);
            if(userLogined != null)
            {
                theUser = userLogined;
                MessageBox.Show("Teşekkürler " + theUser.UserName + " başarıyla giriş yaptınız.");
                FormMenu formMenu = new FormMenu();
                formMenu.Show();
            }
            else
            {
                MessageBox.Show("Lütfen tekrar deneyiniz.");
            }
            Clean();
            
        }

        private bool IsValidationWrong()
        {
            if (txtEmail.Text.IsEmpty() || txtPassword.Text.IsEmpty())
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
            txtEmail.Clear();
            txtPassword.Clear();
        }
    }
}
