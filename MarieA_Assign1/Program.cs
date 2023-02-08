using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MarieA_Assign1
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            WriteLine("Hello there! Welcome to the Photo Print Services!");
            WriteLine("You can place orders for three different print sizes. \n");
            WriteLine("We have the following print sizes available...");

            //to create three objects of PhotoPrint by setting the size name and each unit price
            PhotoPrint photoPrintType1 = new PhotoPrint("4x6 Print", 2.63);
            PhotoPrint photoPrintType2 = new PhotoPrint("6x9 Print", 8.75);
            PhotoPrint photoPrintType3 = new PhotoPrint("8x12 Print", 10.50);

            //formatted string to display three different print sizes and each price unit
            object[] printSizeNameAndUnitPrice = { photoPrintType1.SizeName, photoPrintType2.SizeName, photoPrintType3.SizeName,
                                                   photoPrintType1.PrintUnitPrice, photoPrintType2.PrintUnitPrice, photoPrintType3.PrintUnitPrice };
            string availablePrintSizes = String.Format("{0} with print unit price of {3:C}" + "\n" +
                                                       "{1} with print unit price of {4:C}" + "\n" +
                                                       "{2} with print unit price of {5:C}", printSizeNameAndUnitPrice);
            WriteLine(availablePrintSizes);

            WriteLine("\n\nLet us begin by entering the number of prints for each of these print sizes");
            //call to method UpdateNumPrint where user specifiy the number of prints for each sizes
            UpdateNumPrint(photoPrintType1);
            UpdateNumPrint(photoPrintType2);
            UpdateNumPrint(photoPrintType3);
            WriteLine("The number of prints for each print size has been entered.\n\n");

            //call to method ChooseAction() where user choose what action to do (View, Update, Quit)
            ChooseAction(photoPrintType1, photoPrintType2, photoPrintType3);
        }

        //method to update the number of prints for each print size based on user's input
        static void UpdateNumPrint(PhotoPrint anyPrint)
        {
            Write("Enter the number of prints for {0}: ", anyPrint.SizeName);
            anyPrint.NumPrints = int.Parse(ReadLine()); //input is stored in the NumPrints property
        }

        //method to choose action wherein user chooses 1 to view cart, 2 to update cart, 3 to quit the app
        static void ChooseAction(PhotoPrint printType1, PhotoPrint printType2, PhotoPrint printType3)
        {
            WriteLine("\nWhat would you like to do?");
            Write("Press 1 to View Cart, Press 2 to Update Cart, Press 3 to Quit: ");
            int userAction = int.Parse(ReadLine()); //input is parsed and stored in userAction variable

            //Depending on the user's input, if condition is met it will enter and execute the block
            //else user did not input the correct number
            if (userAction == 1)
            {
                //method to view details in cart
                ViewOrder(printType1, printType2, printType3); 

            }
            else if(userAction == 2)
            {
                //method to update the number of prints
                UpdateOrder(printType1, printType2, printType3); 
            }
            else if(userAction == 3)
            {
                WriteLine("\nThank you for ordering in our photo prints. Have a great day!");
            }
            else
            {
                WriteLine("\nInvalid input. Please try again."); 
            }
        }

        //method to view the details of cart when user press 1 in ChooseAction()
        static void ViewOrder(PhotoPrint photoType1, PhotoPrint photoType2, PhotoPrint photoType3)
        {
            //the return value of GetOrderTotalSummary() is stored in totalAfterDiscount variable
            //it returns the total amount after discount
            double totalAfterDiscount = GetOrderTotalSummary(photoType1, photoType2, photoType3, out double totalBeforeDiscount, out double discountAmount);
            WriteLine("\nVIEW PHOTO CART \n");
            
            //START - displays output in banner form
            string asteriskLine = String.Format(new string('*', 80));
            string asteriskInBetween = String.Format("*{0,78}*", " ");
            WriteLine(asteriskLine);
            WriteLine(photoType1);
            WriteLine(asteriskInBetween);
            WriteLine(photoType2);
            WriteLine(asteriskInBetween);
            WriteLine(photoType3);
            WriteLine(asteriskLine);

            //Formatted string to display totalBeforeDiscount, discountAmount, and totalAfterDiscount details in a banner
            string displaytotalAmount = "*{0,36}: {3,-40:C}*" + "\n" +
                                        "*{1,36}: {4,-40:C}*" + "\n" +
                                        "*{2,36}: {5,-40:C}*";
            string printBannerTotalAmount = String.Format(displaytotalAmount, "Total before discount", "Discount", "Total after discount",
                                                    totalBeforeDiscount, discountAmount, totalAfterDiscount);
            WriteLine(printBannerTotalAmount);
            WriteLine(asteriskLine);
            //END - displays output in banner form

            //call to method ChooseAction() where user choose what action to do (View, Update, Quit)
            ChooseAction(photoType1, photoType2, photoType3); 
        }

        //method to get the before discount amount, and calculate the total after the discount
        static double GetOrderTotalSummary(PhotoPrint printSizeType1, PhotoPrint printSizeType2, PhotoPrint printSizeType3,
                                            out double totalBeforeDiscount, out double discountAmount)
        {
            //DISCOUNT_AMT is constant, 10% discount if totalBeforeDiscount is >= $50
            const double DISCOUNT_AMT = 10;  
            totalBeforeDiscount = (printSizeType1.PrintTotal + printSizeType2.PrintTotal + printSizeType3.PrintTotal);

            // use if else statement for the discount
            // if totalBeforeDiscount is >= $50, it will return and display the computed totalAfterDiscount
            // else it will return and display the totalBeforeDiscount and discount is 0
            if (totalBeforeDiscount >= 50)
            {
                discountAmount = (DISCOUNT_AMT * totalBeforeDiscount) / 100;
                return (totalBeforeDiscount - discountAmount);
            }
            else
            {
                discountAmount = 0;
                return totalBeforeDiscount;

            }
        } 

        //method to update the detail/s in the cart
        //user is only allowed to update one cart at a time
        static void UpdateOrder(PhotoPrint updateType1, PhotoPrint updateType2, PhotoPrint updateType3)
        {
            
            WriteLine("\nUPDATE PHOTO CART \n");
            WriteLine("Which print size do you like to update?");
            WriteLine("Press 1 for {0}", updateType1.SizeName);
            WriteLine("Press 2 for {0}", updateType2.SizeName);
            WriteLine("Press 3 for {0}", updateType3.SizeName);
            Write("Enter the number (1, 2, or 3): ");
            int userInput = int.Parse(ReadLine());
            string updatedQuantityMsg = "Perfect! Quantity of {0} has been updated to {1}";

            //Depending on the user's input, if condition is met it will enter and execute the block
            //else user did not input the correct number
            //formatted string to display the updatedQuantityMsg and the updated print size and unit price
            if (userInput == 1)
            {
                Write("Enter the new quantity for {0}: ", updateType1.SizeName);
                updateType1.NumPrints = int.Parse(ReadLine());
                string updatedPrintType1 = String.Format(updatedQuantityMsg, updateType1.SizeName, updateType1.NumPrints);
                WriteLine(updatedPrintType1);

            }else if(userInput == 2)
            {
                Write("Enter the new quantity for {0}: ", updateType2.SizeName);
                updateType2.NumPrints = int.Parse(ReadLine());
                string updatedPrintType2 = String.Format(updatedQuantityMsg, updateType2.SizeName, updateType2.NumPrints);
                WriteLine(updatedPrintType2);
            }
            else if(userInput == 3)
            {
                Write("Enter the new quantity for {0}: ", updateType3.SizeName);
                updateType3.NumPrints = int.Parse(ReadLine());
                string updatedPrintType3 = String.Format(updatedQuantityMsg, updateType3.SizeName, updateType3.NumPrints);
                WriteLine(updatedPrintType3);
            }
            else
            {
                WriteLine("Invalid input. Please try again");
            }
            //call to method ChooseAction() where user choose what action to do (View, Update, Quit)
            ChooseAction(updateType1, updateType2, updateType3);
        }
    }
}
