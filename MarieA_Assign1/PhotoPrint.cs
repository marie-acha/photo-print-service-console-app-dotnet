using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieA_Assign1
{
    internal class PhotoPrint
    {
        //read-only properties
        public string SizeName
        {
            get;
        }

        public double PrintUnitPrice
        {
            get;
        }

        //read-write properties
        public int NumPrints
        {
            get;
            set;
        }

        //read-only computed property
        //calculate the total price of prints by multiplying the number of prints and the unit price
        public double PrintTotal
        {
            get
            {
                return NumPrints * (PrintUnitPrice);
            }
        }

        //constructor
        public PhotoPrint(string sizeName, double printUnitPrice)
        {
            SizeName = sizeName;
            PrintUnitPrice = printUnitPrice;
        }

        //ToString() method to combine and display all details of PhotoPrint
        //using String.Format()
        public override string ToString()
        {
            object[] printDetails = { "PrintSize", "UnitPrice", "NumPrints", "PrintTotal", SizeName, PrintUnitPrice, NumPrints, PrintTotal };
            string bannerDetail = "*{0,36}: {4,-40}*" + "\n" +
                                  "*{1,36}: {5,-40:C}*" + "\n" +
                                  "*{2,36}: {6,-40}*" + "\n" +
                                  "*{3,36}: {7,-40:C}*";
            string printBannerDetail = String.Format(bannerDetail, printDetails);
            return printBannerDetail;
        }
    }
}
