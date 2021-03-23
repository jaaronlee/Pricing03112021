using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing03112021.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pricing03112021.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var columnItems = new List<ColumnBreakEntry>
            {
             new ColumnBreakEntry{Column=0},
             new ColumnBreakEntry{Column=1},
             new ColumnBreakEntry{Column=2},
             new ColumnBreakEntry{Column=3},
             new ColumnBreakEntry{Column=4},
             new ColumnBreakEntry{Column=5},
             new ColumnBreakEntry{Column=6},
             new ColumnBreakEntry{Column=7},
             new ColumnBreakEntry{Column=8},
            };
            columnList.ItemsSource = columnItems;
        }

        async void Columns_SelectionChanged(object s, SelectionChangedEventArgs e)
        {
            var column = (ColumnBreakEntry)e.CurrentSelection.FirstOrDefault();
            if (column != null)
            {
                await Navigation.PushAsync(new ItemPage(column), true);
            }
            columnList.SelectedItem = null;
        }
    }
}