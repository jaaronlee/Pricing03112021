using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Pricing03112021.Models;
using Pricing03112021.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pricing03112021.Resources;

namespace Pricing03112021.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        private int passingColumn;


        public ItemPage(ColumnBreakEntry entry)
        {
           InitializeComponent();
            ColumnBreakEntry columnForSheets = entry;
            passingColumn = columnForSheets.Column;  
            productList.ItemsSource = ItemDataService.detailsItems;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            productList.ItemsSource = ItemDataService.GetSearchResults(e.NewTextValue);
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CustomPage(passingColumn));
        }

        async void Items_SelectionChanged(object s, SelectionChangedEventArgs e)
        {
            ItemEntry itemSelected = (ItemEntry)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new SheetEntryPage(itemSelected, passingColumn));
        }
    }
}