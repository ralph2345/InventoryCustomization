using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryCustomization
{
    public partial class formAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        private BindingSource showProductList;

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new StringFormatException("Invalid product name");
               
            }
            else
            {
                return name;
            }
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {
                throw new NumberFormatException("Invalid input number in quantity");
            }
            else
            {
                return Convert.ToInt32(qty);
            }
               
          
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {
                throw new CurrencyFormatException("Invalid input currency");
            }
            else
            {
                return Convert.ToDouble(price);
            }
               
        }
        public formAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void formAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal care",
                "Other"
            };
            foreach (string CategoryBox in ListOfProductCategory)
            {
                cbCategory.Items.Add(CategoryBox);
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtPruductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-mm-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("dddd-mm-dd");
                _Description = richTextDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName,_Category,_MfgDate,_ExpDate,_SellPrice,_Quantity , _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException s)
            {
                MessageBox.Show(s.Message);
            }
            catch (NumberFormatException n)
            {
                MessageBox.Show(n.Message);
            }
            catch (CurrencyFormatException c)
            {
                MessageBox.Show(c.Message);
            }

            finally
            {
                MessageBox.Show("This is finally message");
            }

        }

    }//class

}//namespace
