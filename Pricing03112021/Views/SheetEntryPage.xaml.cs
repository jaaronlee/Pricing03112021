using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing03112021.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pricing03112021.PricingCode;
using Xamarin.Essentials;

namespace Pricing03112021.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SheetEntryPage : ContentPage
    {
        private string itemCode;
        private string itemDescription;
        private string unitOfMeasure;
        private string itemMaterial;
        private double itemWeight;
        private double itemBasePrice;
        private double quantity;
        private string itemColor;
        private string itemSurface;

        private int column;
        string pricingString = "dog";
        double price = 0;

        public SheetEntryPage(ItemEntry entry, int passingColumn)
        {
            InitializeComponent();
            //passing variables
            column = passingColumn;
            itemCode = entry.ItemCode;
            itemDescription = entry.ItemDescription;
            unitOfMeasure = entry.UnitOfMeasure;
            itemMaterial = entry.ItemMaterial;
            itemWeight = entry.ItemWeight;
            itemBasePrice = entry.ItemBasePrice;
            itemSurface = entry.ItemSurface;
            itemColor = entry.ItemColor;
            //Bindings
            itemBinding.Text = entry.ItemDescription.ToString();  
        }

        void Entry_Completed(object sender, EventArgs e)
        {
            string quantityString = ((Entry)sender).Text;
            quantity = Convert.ToDouble(quantityString);
            double vinylBase = 1.3;
            double styreneBase = 1.38;
            double vinylClearUp = -.02;
            double vinylGlossUp = -.01;
            double vinylVelvetUp = .2;
            double vinylColorUp = .3;
         //Standard styrene and vinyl pricing
            if (itemBasePrice == 0)
            {//VINYL
                if ((itemMaterial == "Vinyl")|(itemMaterial == "APET"))
                    {if (!((itemColor == "White")|(itemColor == "Clear")))//COLORS
                        {vinylBase = vinylBase + vinylColorUp;}
                    if (itemColor == "Clear")
                        { vinylBase = vinylBase + vinylClearUp; }
                    if (itemSurface == "Gloss/Gloss")   
                        { vinylBase = vinylBase + vinylGlossUp; }
                    if (itemSurface == "Velvet/Gloss")
                        { vinylBase = vinylBase + vinylVelvetUp; }
                    itemBasePrice = vinylBase * itemWeight;
                    }
                if (itemMaterial == "Styrene")
                    {if (itemColor == "Dead White")
                        { styreneBase = styreneBase + .11; }
                    if (itemColor == "Translucent White")
                        { styreneBase = styreneBase - .05; }
                    itemBasePrice = styreneBase * itemWeight * .95;//allowance for downgauge
                    if ((quantity * itemWeight) > 999) { column = column + 16; }
                }
            }
        //Send to stockPricing Code
            price = StockPricingCode.StockPricing(column, itemWeight, itemBasePrice, quantity);
        //RETURN
            if (pricingString == "dog")
            {
                pricingString = quantity + " sheets " + itemDescription + " "+ price.ToString("C2") + " per sheet delivered";
            }
            else
            {
                pricingString = pricingString + "\r" + quantity + " sheets " + itemDescription + " " + price.ToString("C2") + " per sheet delivered";
            }

            testingBinding1.Text = pricingString;
            pageQuantity.Text = "";
            pageQuantity.Focus();
            copyClicked.IsVisible = true;
            emailClicked.IsVisible = true;
        }

        void CopyClick(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(pricingString);
        }

        void EmailClick(object sender, EventArgs e)
        {
            var message = new EmailMessage
            {
                Subject = "Quote: " +itemDescription,
                Body = pricingString
            };
            Email.ComposeAsync(message);
        }

    }
}