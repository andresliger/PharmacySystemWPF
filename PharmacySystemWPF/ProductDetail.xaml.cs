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
using System.Windows.Shapes;

namespace PharmacySystemWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        PharmacyItem pharmacyItem;
        public ProductDetail()
        {
            InitializeComponent();
        }

        public ProductDetail(PharmacyItem pharmacyItem)
        {
            InitializeComponent();
            this.pharmacyItem = pharmacyItem;
            txbInformation.Text = pharmacyItem.getFullDescriptionPayment();
            this.Title = pharmacyItem.ProviderName;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pedido confirmado...!");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
