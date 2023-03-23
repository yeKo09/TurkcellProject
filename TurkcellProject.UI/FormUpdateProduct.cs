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
    public partial class FormUpdateProduct : Form
    {
        public ProductUpdateView productUpdateView;
        public ProductGroupDAL productGroupDal;
        public BrandDAL brandDal;
        public ModelDAL modelDal;
        public List<String> guarenteedTypes;
        public CurrencyDAL currencyDal;
        public CurrentProductPriceDAL currentProductPriceDal;
        public ProductWithBarcodeDAL productWithBarcodeDal;
        public ProductWithoutBarcodeDAL productWithoutBarcodeDal;
        public UnitDAL unitDal;
        public ProductUpdateDAL productUpdateDal;
        public bool isCurrentPriceChanged;
        public ProductStatusDAL productStatusDal;
        public StatusDAL statusDal;

        public FormUpdateProduct()
        {
            InitializeComponent();
            productGroupDal = new ProductGroupDAL();
            brandDal = new BrandDAL();
            modelDal = new ModelDAL();
            guarenteedTypes = new List<string>() { "Evet", "Hayır" };
            currencyDal = new CurrencyDAL();
            productUpdateView = null;
            currentProductPriceDal = new CurrentProductPriceDAL();
            productWithBarcodeDal = new ProductWithBarcodeDAL();
            productWithoutBarcodeDal = new ProductWithoutBarcodeDAL();
            unitDal = new UnitDAL();
            productUpdateDal = new ProductUpdateDAL();
            isCurrentPriceChanged = false;
            productStatusDal = new ProductStatusDAL();
            statusDal = new StatusDAL();

        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
            gboxProduct.Enabled = false;
            cmbActions.Enabled = false;
        }

        /// <summary>
        /// Searches the entered product on the database and returns an error if it can't find
        /// if it finds, it enables the groupbox below
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if (IsValidationWrong())
            {
                MessageBox.Show("Girdiğiniz veride bir hata oluştu. Lütfen tekrar deneyiniz.");
                return;
            }
            productUpdateView = productUpdateDal.SelectSingleItem(Convert.ToInt32(txtProductID.Text));
            if (productUpdateView == null)
            {
                MessageBox.Show("Aradığınız varlık bulunamadı.");
                gboxProduct.Enabled = false;
            }
            else
            {
                MessageBox.Show("Aradığınız ürün bulundu !");
                gboxProduct.Enabled = true;
                FillProductInformation();
            }
        }

        private bool IsValidationWrong()
        {
            if (txtProductID.Text.IsEmpty())
            {
                return true;
            }
            else if(txtProductID.Text.DoesContainLetter())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// If the product is found, then there is a need to fill the information to the elements in the groupbox
        /// </summary>
        private void FillProductInformation()
        {
            bool isWithBarcode = PutWithBarcode();
            if (!isWithBarcode)
            {
                PutWithoutBarcode();
            }
            int statusID = productStatusDal.SelectSingleItem(productUpdateView.TheProduct.ProductID).StatusID;
            lblDurum.Text = statusDal.SelectSingleItem(statusID).StatusName;
            PutActions();
            cmbUnit.DataSource = unitDal.Select();
            cmbProductType.DataSource = productGroupDal.Select();
            PutProductType();
            cmbBrand.DataSource = brandDal.Select();
            PutBrand();
            cmbIsGuarenteed.DataSource = guarenteedTypes;
            PutGuarenteed();
            rtxtDescription.Text = productUpdateView.TheProduct.ProductDescription;
            dtEntryDate.Value = productUpdateView.TheProduct.ProductEntryDate;
            dtRetireDate.Enabled = false;
            txtCost.Text = productUpdateView.TheProduct.ProductCost.ToString();
            cmbCurrency.DataSource = currencyDal.Select();
            PutCurrency();
            cmbCurrentPriceCurrency.DataSource = currencyDal.Select();
            PutCurrentPrice();
        }

        /// <summary>
        /// This method puts the actions according the products' status.
        /// </summary>
        private void PutActions()
        {
            cmbActions.Items.Clear();
            cmbActions.Items.Add("Zimmete Ata");
            if (lblDurum.Text == "Müşteride")
            {
                cmbActions.Items.Clear();
            }
            else if(lblDurum.Text == "Zimmetli")
            {
                cmbActions.Items.Add("Tüket");
            }
            cmbActions.Enabled = true;
        }

        /// <summary>
        /// If the searched product is without barcode, this method displays the information without barcode and
        /// enables the parts that is non-barcode fields, but disables the elements that has the parts of barcode
        /// </summary>
        private void PutWithoutBarcode()
        {
            ProductWithoutBarcode productWithoutBarcode = productWithoutBarcodeDal.SelectSingleItem(productUpdateView.TheProduct.ProductID);
            
            if(productWithoutBarcode != null)
            {
                rbWithoutBarcode.Enabled = true;
                rbWithoutBarcode.Checked = true;
                rbWithBarcode.Enabled = false;
                txtBarcode.Text = "";
                txtBarcode.Enabled = false;
                cmbUnit.Enabled = true;
                ndCount.Enabled = true;
                ndCount.Value = productWithoutBarcode.Count;
                PutUnit(productWithoutBarcode.UnitID);
                productUpdateView.IsWithBarcode = false;
                productUpdateView.NonBarcodedProduct = productWithoutBarcode;
            }
        }

        /// <summary>
        /// This method puts the units into the combobox.
        /// </summary>
        /// <param name="unitID"></param>
        private void PutUnit(int unitID)
        {
            Unit unit = unitDal.SelectSingleItem(unitID);
            foreach (Unit item in cmbUnit.Items)
            {
                if (item.UnitID == unit.UnitID)
                {
                    cmbUnit.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// If the searched product is with barcode, this method displays the information with barcode and
        /// enables the parts that is barcode fields, but disables the elements that has the parts of non-barcode
        /// </summary>
        /// <returns></returns>
        private bool PutWithBarcode()
        {
            ProductWithBarcode productWithBarcode = productWithBarcodeDal.SelectSingleItem(productUpdateView.TheProduct.ProductID);
            if (productWithBarcode != null)
            {
                rbWithBarcode.Enabled = true;
                rbWithoutBarcode.Enabled = false;
                rbWithBarcode.Checked = true;
                cmbUnit.Enabled = false;
                ndCount.Value = 1;
                ndCount.Enabled = false;
                txtBarcode.Enabled = true;
                txtBarcode.Text = productWithBarcode.Barcode.ToString();
                productUpdateView.IsWithBarcode = true;
                productUpdateView.BarcodedProduct = productWithBarcode;
                return true;
            }
            return false;
        }

        /// <summary>
        /// This methods puts the information about the currenct price into the txtCurrentPrice and cmbCurrenPriceCurrency
        /// </summary>
        private void PutCurrentPrice()
        {
            CurrentProductPrice currentProductPrice = currentProductPriceDal.SelectSingleItem(productUpdateView.TheProduct.ProductID);
            txtCurrentPrice.Text = currentProductPrice.CurrentProductMoney.ToString();
            foreach (Currency item in cmbCurrentPriceCurrency.Items)
            {
                if (item.CurrencyID == currentProductPrice.CurrencyID)
                {
                    cmbCurrentPriceCurrency.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// This method puts the currency into the combobox.
        /// </summary>
        private void PutCurrency()
        {
            foreach (Currency item in cmbCurrency.Items)
            {
                if (item.CurrencyID == productUpdateView.TheProduct.ProductCurrencyID)
                {
                    cmbCurrency.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// This method puts the guarenteed part into combobox.
        /// </summary>
        private void PutGuarenteed()
        {
            if (productUpdateView.TheProduct.IsProductGuarenteed)
            {
                cmbIsGuarenteed.SelectedIndex = 0;
            }
            else
            {
                cmbIsGuarenteed.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// This method fills the model into combobox.
        /// </summary>
        /// <param name="brandID"></param>
        private void FillModel(int brandID)
        {
            cmbModel.DataSource = modelDal.SelectWithID(brandID);
        }

        /// <summary>
        /// This method puts the model in the combobox.
        /// </summary>
        /// <param name="brandID"></param>
        private void PutModel(int brandID)
        {
            FillModel(brandID);
            foreach (Model item in cmbModel.Items)
            {
                if (item.ModelID == productUpdateView.TheProduct.ProductModelID)
                {
                    cmbModel.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// This method puts the brand in the combobox.
        /// </summary>
        private void PutBrand()
        {
            Model selectedModel = modelDal.SelectSingleItem(productUpdateView.TheProduct.ProductModelID);
            foreach (Brand item in cmbBrand.Items)
            {
                if (item.BrandID == selectedModel.ModelBrandID)
                {
                    cmbBrand.SelectedItem = item;
                }
            }
            PutModel((cmbBrand.SelectedItem as Brand).BrandID);
        }

        /// <summary>
        /// This method puts the product type in the combobox.
        /// </summary>
        private void PutProductType()
        {
            foreach (ProductGroup item in cmbProductType.Items)
            {
                if(item.ProductGroupID == productUpdateView.TheProduct.ProductGroupID)
                {
                    cmbProductType.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// This method gets all the information that is on the form elements and then fills the appropiate object according to it and then it checkes whether the product is with barcode or not and according to that, it prepares the data and sends it with the current price to be updated alonside product itself.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //barcode nonbarcode
            if (productUpdateView.IsWithBarcode)
            {
                productUpdateView.BarcodedProduct.Barcode = new Guid(txtBarcode.Text);
            }
            else
            {
                productUpdateView.NonBarcodedProduct.Count = Convert.ToInt16(ndCount.Value);
                productUpdateView.NonBarcodedProduct.UnitID = (cmbUnit.SelectedItem as Unit).UnitID;
            }
            productUpdateView.TheProduct.ProductGroupID = (cmbProductType.SelectedItem as ProductGroup).ProductGroupID;
            productUpdateView.TheProduct.ProductModelID = (cmbModel.SelectedItem as Model).ModelID;
            productUpdateView.TheProduct.IsProductGuarenteed = (cmbIsGuarenteed.SelectedItem as string).Equals("Evet")
                ? true : false;
            productUpdateView.TheProduct.ProductDescription = rtxtDescription.Text;
            productUpdateView.TheProduct.ProductEntryDate = dtEntryDate.Value;
            productUpdateView.TheProduct.ProductCost = Convert.ToDecimal(txtCost.Text);
            productUpdateView.TheProduct.ProductCurrencyID = (cmbCurrency.SelectedItem as Currency).CurrencyID;
            //güncel fiyat
            productUpdateView.ProductCurrentPrice = new CurrentProductPrice()
            {
                CurrencyID = (cmbCurrency.SelectedItem as Currency).CurrencyID,
                CurrentProductMoney = Convert.ToDecimal(txtCurrentPrice.Text),
                ProductID = productUpdateView.TheProduct.ProductID,
                CreatedDate = DateTime.Now
            };
            productUpdateView.UserID = FormLogin.theUser.UserID;
            MessageBox.Show(productUpdateDal.Update(productUpdateView).ResultMessage);
            Clean();
        }

        /// <summary>
        /// This method cleans the form elements.
        /// </summary>
        private void Clean()
        {
            txtProductID.Clear();
        }

        /// <summary>
        /// This method is activated when the brand combobox item changes, this method is useful because it fills the model combobox according to the data in the brand which does not allow confusions such as Iphone S10.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillModel((cmbBrand.SelectedItem as Brand).BrandID);
        }

        /// <summary>
        /// Whichever action the user choose, this methods loads the form according to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActions.SelectedItem.Equals("Zimmete Ata"))
            {
                FormAddDebit formAddDebit = new FormAddDebit(productUpdateView.TheProduct.ProductID);
                formAddDebit.Show();
            }
            else if (cmbActions.SelectedItem.Equals("Tüket"))
            {
                FormConsume formConsume = new FormConsume(productUpdateView.TheProduct.ProductID);
                formConsume.Show();
            }
        }
    }
}
