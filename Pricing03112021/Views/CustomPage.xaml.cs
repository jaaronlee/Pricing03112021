using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pricing03112021.PricingCode;

namespace Pricing03112021.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPage : ContentPage
    {
        private int column;
        string matSelected;
        string pricingString = "dog";
        string quantity;

        public CustomPage(int passingColumn)
        {
            InitializeComponent();
            //Material
            column = passingColumn;
            var pickerListMaterial = new List<string>();
            pickerListMaterial.Add("Vinyl");
            pickerListMaterial.Add("Styrene");
            pickerListMaterial.Add("APET");
            var pickerSource = new Picker { Title = "Material", TitleColor = Color.Red, };
            pickerMaterial.ItemsSource = pickerListMaterial;
            pickerMaterial.SelectedIndex = 0;
        }

        void MaterialPicked(object sender, EventArgs args)
        {
            int defaultColor = 0;
            int defaultSurface = 0;
            matSelected = pickerMaterial.SelectedItem.ToString();
            var pickerListColor = new List<string>();
            var pickerListSurface = new List<string>();
            if (matSelected == "Vinyl")
            {
                pickerListColor.Add("White");
                pickerListColor.Add("Clear");
                pickerListColor.Add("Stock Color");
                defaultColor = 0;
                pickerListSurface.Add("Matte/Matte");
                pickerListSurface.Add("Gloss/Gloss");
                pickerListSurface.Add("Gloss/Matte");
                pickerListSurface.Add("Velvet One Side");
                defaultSurface = 0;
            }
            if (matSelected == "Styrene")
            {
                pickerListColor.Add("Translucent White");
                pickerListColor.Add("White");
                pickerListColor.Add("Dead White");
                defaultColor = 1;
                pickerListSurface.Add("Matte/Matte");
                pickerListSurface.Add("Gloss/Matte");
                defaultSurface = 0;
            }
            if (matSelected == "APET")
            {
                pickerListColor.Add("Clear");
                defaultColor = 0;
                pickerListSurface.Add("Gloss/Gloss");
                defaultSurface = 0;
            }
            //var pickerSource1 = new Picker { Title = "Color", TitleColor = Color.Red, };
            pickerColor.ItemsSource = pickerListColor;
            pickerColor.IsVisible = true;
            pickerColor.SelectedIndex = defaultColor;

            pickerSurface.ItemsSource = pickerListSurface;
            pickerSurface.IsVisible = true;
            pickerSurface.SelectedIndex = defaultSurface;
            pageGauge.IsVisible = true;
            pageWidth.IsVisible = true;
            pageLength.IsVisible = true;
            pageSheets.IsVisible = true;
            //quoteButton.IsVisible = true;
        }
//PRICING
        void Entry_Completed(object sender, EventArgs e)
        {
            double gauge = Convert.ToDouble(pageGauge.Text.ToString());
            double width = Convert.ToDouble(pageWidth.Text.ToString());
            double length = Convert.ToDouble(pageLength.Text.ToString());
            double sheets = Convert.ToDouble(pageSheets.Text.ToString());
            quantity = pageSheets.Text.ToString();
            matSelected = pickerMaterial.SelectedItem.ToString();
            string surfSelected = pickerSurface.SelectedItem.ToString();
            string colorSelected = pickerColor.SelectedItem.ToString();
            double price;
            //Validation
            if (!(sheets > 0)) { warningLabel.Text = "You must enter a valid quantity!"; }
            if ((matSelected == "Vinyl") | (matSelected == "APET"))
            {
                if ((gauge < .009) | (gauge > .030)) { warningLabel.Text = "You must enter a gauge between .009 and .030!"; warningLabel.IsVisible = true; goto GaugeFix; }
                if ((width < 20) | (width > 50)) { warningLabel.Text = "You must enter a width between 20 and 50 inches!"; warningLabel.IsVisible = true; goto WidthFix; }
                if ((length < 20) | (length > 70)) { warningLabel.Text = "You must enter a length between 20 and 70 inches!"; warningLabel.IsVisible = true; goto LengthFix; }
                double vinylWeight = .05 * gauge * width * length;
                double vinylTotalWeight = vinylWeight * sheets;
                if (!(vinylTotalWeight > 1999)) { warningLabel.Text = "You must enter a quantity above the minimum of 2000 pounds!"; warningLabel.IsVisible = true; goto WeightFix; }
                //Vinyl Price
                double vinylBase = 1.3;
                double vinylClearUp = -.02;
                double vinylGlossUp = -.01;
                double vinylVelvetUp = .1;
                double vinylColorUp = .2;
                if (surfSelected == "Gloss/Gloss") { vinylBase = vinylBase + vinylGlossUp; }
                if (surfSelected == "Velvet One Side") { vinylBase = vinylBase + vinylVelvetUp; }
                if (colorSelected == "Clear") { vinylBase = vinylBase + vinylClearUp; }
                if (colorSelected == "Stock Color") { vinylBase = vinylBase + vinylColorUp; }
                vinylBase = vinylBase * vinylWeight;
                price = StockPricingCode.StockPricing(column, vinylWeight, vinylBase, sheets);
            }
            else//Styrene
            {
                if ((gauge < .009) | (gauge > .250)) { warningLabel.Text = "You must enter a gauge between .009 and .250!"; warningLabel.IsVisible = true; goto GaugeFix; }
                if ((width < 12) | (width > 68)) { warningLabel.Text = "You must enter a width between 20 and 130 inches!"; warningLabel.IsVisible = true; goto WidthFix; }
                if ((length < 20) | (length > 130)) { warningLabel.Text = "You must enter a length between 20 and 130 inches!"; warningLabel.IsVisible = true; goto LengthFix; }
                double styreneWeight = .04 * gauge * width * length;
                double styreneTotalWeight = styreneWeight * sheets;
                if (!(styreneTotalWeight > 1999)) { warningLabel.Text = "You must enter a quantity above the minimum of 2000 pounds!"; warningLabel.IsVisible = true; goto WeightFix; }
                //Styrene Price
                double styreneBase = 1.35;
                double transUp = -.02;
                double deadUp = -.1;
                double glossUp = .05;
                if (colorSelected == "Translucent White") { styreneBase = styreneBase + transUp; }
                if (colorSelected == "Dean White") { styreneBase = styreneBase + deadUp; }
                if (surfSelected == "Gloss/Matte") { styreneBase = styreneBase + glossUp; }
                styreneBase = styreneBase * styreneWeight;
                price = StockPricingCode.StockPricing(column, styreneWeight, styreneBase, sheets);
            }
            warningLabel.IsVisible = true;
            if (pricingString == "dog")
            {
                pricingString = quantity + " sheets " + gauge.ToString("N3") + " " + colorSelected + " " + surfSelected + " " + matSelected + " " + width.ToString() + "x" + length.ToString() + " sheets " + price.ToString("C2") + " per sheet delivered";
            }
            else
            {
                pricingString = pricingString + "\r" + quantity + " sheets " + gauge.ToString("N3") + " " + colorSelected + " " + surfSelected + " " + matSelected + " " + width.ToString() + "x" + length.ToString() + " sheets " + price.ToString("C2") + " per sheet delivered";
            }
            warningLabel.Text = pricingString;
            copyClicked.IsVisible = true;
            emailClicked.IsVisible = true;

            goto WeightFix;

        GaugeFix: pageGauge.Text = ""; pageGauge.Focus();
        WidthFix: pageWidth.Text = ""; pageGauge.Focus();
        LengthFix: pageLength.Text = ""; pageGauge.Focus();
        WeightFix: pageSheets.Text = ""; pageSheets.Focus();
        }
//BUTTONS
        void CopyClick(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(pricingString);
        }

        void EmailClick(object sender, EventArgs e)
        {
            var message = new EmailMessage
            {
                Subject = matSelected + " Quote",
                Body = pricingString
            };
            Email.ComposeAsync(message);
        }
//ENTRY VALIDATION
        void Gauge_Completed(object sender, EventArgs e)
        { 
            try
            {
                if ((matSelected == "Vinyl") | (matSelected == "APET"))
                {
                    if ((Convert.ToDouble(pageGauge.Text) < .009) | (Convert.ToDouble(pageGauge.Text) > .030))
                    {
                        warningLabel.Text = "You must enter a gauge between .009 and .030!"; warningLabel.IsVisible = true; pageGauge.Text = ""; pageGauge.Focus();
                    }
                }
                else if ((Convert.ToDouble(pageGauge.Text) < .009) | (Convert.ToDouble(pageGauge.Text) > .250))
                {
                    warningLabel.Text = "You must enter a gauge between .009 and .250!"; warningLabel.IsVisible = true; pageGauge.Text = ""; pageGauge.Focus();
                }
            }
            catch
            {
                warningLabel.Text = "You must enter a gauge between .009 and .030!"; warningLabel.IsVisible = true; pageGauge.Text = ""; pageGauge.Focus();
            }
        }

        void Width_Completed(object sender, EventArgs e)
        {
            try
            {
                if ((matSelected == "Vinyl") | (matSelected == "APET"))
                {
                    if ((Convert.ToDouble(pageWidth.Text) < 20) | (Convert.ToDouble(pageWidth.Text) > 50))
                    {
                        warningLabel.Text = "You must enter width between 20 and 50 inches!"; warningLabel.IsVisible = true; pageWidth.Text = ""; pageWidth.Focus();
                    }
                }
                else if ((Convert.ToDouble(pageWidth.Text) < 20) | (Convert.ToDouble(pageWidth.Text) > 65))
                {
                    warningLabel.Text = "You must enter a width between 65 and 130 inches!"; warningLabel.IsVisible = true; pageWidth.Text = ""; pageWidth.Focus();
                }
            }
            catch
            {
                warningLabel.Text = "You must enter width between 20 and 50 inches!"; warningLabel.IsVisible = true; pageWidth.Text = ""; pageWidth.Focus();
            }
        }

        void Length_Completed(object sender, EventArgs e)
        {
            try
            {
                if ((matSelected == "Vinyl") | (matSelected == "APET"))
                {
                    if ((Convert.ToDouble(pageLength.Text) < 20) | (Convert.ToDouble(pageLength.Text) > 70))
                    {
                        warningLabel.Text = "You must enter width between 20 and 70 inches!"; warningLabel.IsVisible = true; pageLength.Text = ""; pageLength.Focus();
                    }
                }
                else if ((Convert.ToDouble(pageLength.Text) < 20) | (Convert.ToDouble(pageLength.Text) > 130))
                {
                    warningLabel.Text = "You must enter a width between 20 and 130 inches!"; warningLabel.IsVisible = true; pageLength.Text = ""; pageLength.Focus();
                }
            }
            catch
            {
                warningLabel.Text = "You must enter width between 20 and 70 inches!"; warningLabel.IsVisible = true; pageLength.Text = ""; pageLength.Focus();
            }
        }
    }
}
