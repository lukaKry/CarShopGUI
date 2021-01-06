using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarClassLibrary;

namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store myStore = new Store();
        BindingSource carInventoryBindingSource = new BindingSource();
        BindingSource cartBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_create_car_Click(object sender, EventArgs e)
        {
            Car c = new Car(txt_make.Text, txt_model.Text, decimal.Parse(txt_price.Text), txt_color.Text);
            myStore.CarList.Add(c);
            carInventoryBindingSource.ResetBindings(false);
            txt_color.Clear();
            txt_make.Clear();
            txt_model.Clear();
            txt_price.Clear();

        }

        private void btn_add_to_cart_Click(object sender, EventArgs e)
        {
            //get the selected item
            Car selected = (Car) lst_inventory.SelectedItem;
            //add item to the list (using cast syntax)
            myStore.ShoppingList.Add(selected);
            //Reset datasource
            cartBindingSource.ResetBindings(false);
        }

        private void lst_inventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carInventoryBindingSource.DataSource = myStore.CarList;
            lst_inventory.DataSource = carInventoryBindingSource;
            lst_inventory.DisplayMember = ToString();

            cartBindingSource.DataSource = myStore.ShoppingList;
            lst_cart.DataSource = cartBindingSource;
            lst_cart.DisplayMember = ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lst_cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            decimal total = myStore.Checkout();
            lbl_total_cost.Text = "Total cost: $" + total;
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            cartBindingSource.ResetBindings(false);

        }
    }
}
