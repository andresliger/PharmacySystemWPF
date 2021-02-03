using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PharmacySystemWPF
{
    /// <summary>
    /// Interaction logic for Pharmacy.xaml
    /// </summary>
    public partial class Pharmacy : Window
    {
        public Pharmacy()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex_Numbers = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static readonly Regex _regexLetters = new Regex("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$"); //regex that matches disallowed text
        
        private bool OnlyNumbers(string text)
        {
            return !_regex_Numbers.IsMatch(text);
        }
        private bool OnlyLetters(string text)
        {
            return _regexLetters.IsMatch(text);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
            if (validateForm())
            {

                PharmacyItem item = new PharmacyItem();
                item.NameMedicine = txtName.Text;
                item.TypeMedicine = cmbType.Text;
                item.ItemNumber = Int32.Parse(txtTotal.Text);
                item.ProviderName = getSelectedProvider();

                String finalAddress = "";
                if (cbSecondary.IsChecked.Value)
                {
                    finalAddress += "Calle de la Rosa n. 28 ";
                    if (cbSecondary.IsChecked.Value)
                        finalAddress += " y\n";

                }

                if (cbMain.IsChecked.Value)
                {
                    finalAddress += "Calle Alcazabilla n. 3. ";
                }

                item.Address = finalAddress;

                ProductDetail productDetail = new ProductDetail(item);
                productDetail.Show();



            }
            else
            {
                MessageBox.Show("Aún existen pendientes revisar los campos...!");
            }

            validateForm();
        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !OnlyLetters(e.Text);
        }

        private void txtTotal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !OnlyNumbers(e.Text);
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            isValidateMedicineName();
        }

        /***
        * Método para validar todos los campos del formulario
        */
        public bool validateForm()
        {

            //Validacion campo de nombre de medicina
            isValidateMedicineName();
            isValidItemNumbers();
            isValidAddress();

            if (isValidateMedicineName() && isValidItemNumbers() && isValidAddress())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isValidateMedicineName()
        {

            Boolean isValid = true;
            if (txtName.Text.Length<=0)
            {
                isValid = false;
                iconCheckName.ToolTip = "El campo no puede estar vacío";
                iconCheckName.Source = new BitmapImage(new Uri(@"/info.jpg", UriKind.Relative));
            }
            else
            {
                iconCheckName.ToolTip = "";
                iconCheckName.Source = new BitmapImage(new Uri(@"/check.jpg", UriKind.Relative));
            }
            return isValid;
        }

        public bool isValidItemNumbers()
        {

            Boolean isValid = true;
            if (txtTotal.Text=="" || Int32.Parse(txtTotal.Text) <= 0)
            {
                isValid = false;
                iconCheckTotal.ToolTip = "El campo no puede estar vacío o ser menor a 0";
                iconCheckTotal.Source = new BitmapImage(new Uri(@"/info.jpg", UriKind.Relative));
            }
            else
            {
                iconCheckTotal.ToolTip = "";
                iconCheckTotal.Source = new BitmapImage(new Uri(@"/check.jpg", UriKind.Relative));
            }
            return isValid;
        }

        public bool isValidAddress()
        {

            bool isValid = true;
            if (cbMain.IsChecked.Value || cbSecondary.IsChecked.Value)
            {
                iconCheckBranch.ToolTip = "";
                iconCheckBranch.Source = new BitmapImage(new Uri(@"/check.jpg", UriKind.Relative));
            }
            else
            {
                iconCheckBranch.ToolTip = "El campo no puede estar vacío";
                iconCheckBranch.Source = new BitmapImage(new Uri(@"/info.jpg", UriKind.Relative));
                isValid = false;
            }
            return isValid;
        }

        public String getSelectedProvider()
        {

            if (rbCamefar.IsChecked.Value)
                return rbCamefar.Content.ToString();
            else if (rbCofarma.IsChecked.Value)
                return rbCofarma.Content.ToString();
            else if (rbEmpsephar.IsChecked.Value)
                return rbEmpsephar.Content.ToString();
            else
                return "No se ha seleccionado proveedor";
        }

        private void txtTotal_LostFocus(object sender, RoutedEventArgs e)
        {
            isValidItemNumbers();
        }

        private void cbMain_Checked(object sender, RoutedEventArgs e)
        {
            isValidAddress();
        }

        private void cbSecondary_Checked(object sender, RoutedEventArgs e)
        {
            isValidAddress();
        }

        private void txtTotal_KeyUp(object sender, KeyEventArgs e)
        {
            isValidItemNumbers();
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            isValidateMedicineName();
        }
    }
}
