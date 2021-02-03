using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemWPF
{
    class PharmacyItem
    {
        private String nameMedicine;
        private Int32 itemNumber;
        private String typeMedicine;
        private String providerName;
        private String address;

        public PharmacyItem()
        {
        }

        public string NameMedicine { get => nameMedicine; set => nameMedicine = value; }
        public int ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string TypeMedicine { get => typeMedicine; set => typeMedicine = value; }
        public string ProviderName { get => providerName; set => providerName = value; }
        public string Address { get => address; set => address = value; }

        public String getFullDescriptionPayment()
        {
            return "Pedido por: " + itemNumber + " unidades del " + typeMedicine + " " + nameMedicine + "\n" +
                       "Para la farmacia " + providerName + " situada en: \n" + address;

        }

    }
}
