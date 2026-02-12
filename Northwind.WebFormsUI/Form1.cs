using Northwind.Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Entities.Concrete;
using Northwind.DataAcsess.Concrete.EntityFramework;
using Northwind.DataAcsess.Concrete.NHibernate;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            //_productService = new ProductManager(new NhProductDal());

            _categoryService = new CategoryManager(new EfCategoryDal());
            // _categoryService = new CategoryManager(new NhCategoryDal());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                LoadProducts();
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryIdAdd.DataSource = _categoryService.GetAll();
            cbxCategoryIdAdd.DisplayMember = "CategoryName";
            cbxCategoryIdAdd.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt32(cbxCategoryIdAdd.SelectedValue),
                ProductName = tbxProductNameAdd.Text,
                QuantityPerUnit = tbxQuantityPerUnitAdd.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                UnitsInStock = Convert.ToInt16(tbxUnitInStockAdd.Text),
            });
            MessageBox.Show("Product Added!");
            LoadProducts();
        }

        private void btnUptade_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                  ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                  ProductName= tbxProductNameAdd.Text,
                  CategoryId = Convert.ToInt32(cbxCategoryIdAdd.Text),
                  UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                  QuantityPerUnit = tbxUnitPriceAdd.Text,
                  UnitsInStock = Convert.ToInt16(tbxUnitInStockAdd.Text),

            });
            MessageBox.Show("Product Updated!");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;

            tbxProductNameAdd.Text= row.Cells[2].Value.ToString();
            cbxCategoryIdAdd.Text = row.Cells[1].Value.ToString();
            tbxQuantityPerUnitAdd.Text = row.Cells[3].Value.ToString();
            tbxUnitInStockAdd.Text = row.Cells[5].Value.ToString();
            tbxUnitPriceAdd.Text = row.Cells[4].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    });
                    MessageBox.Show("Product Deleted!");
                    LoadProducts();
                }
                catch
                {
                    
                }                 

        }
    }
}
