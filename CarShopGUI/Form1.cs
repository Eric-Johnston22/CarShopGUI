namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource CarListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            CarListBinding.DataSource = store.CarList;
            listBox1.DataSource = CarListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car();
            newCar.Make = textBox1.Text;
            newCar.Model = textBox2.Text;
            newCar.Price = Decimal.Parse(textBox3.Text);
            newCar.Year = int.Parse(textBox4.Text);
            newCar.IsNew = comboBox1.Text;

            store.CarList.Add(newCar);

            CarListBinding.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);

            ShoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label5.Text = total.ToString();
        }


        private void textBox1_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please enter a valid number");
            }
            else
            {
                errorProvider1.Clear();
            }
           
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Please enter a valid number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Please enter a valid number");
            }
            else if (!Decimal.TryParse(textBox3.Text, out decimal res))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Please enter a valid number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Please enter a valid number");
            }
            else if (!Int32.TryParse(textBox4.Text, out int res))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Please enter a valid number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider1.SetError(comboBox1, "Please make a selection");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}