using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewKeyboardEntry
{
    public partial class MainPage : ContentPage
    {
        #region variables
        private List<Cell> _collectionListCell { get; set; }

        private List<Item> _quantityList { get; set; }
        public List<Item> QuantityList
        {
            get => _quantityList;
            set
            {
                _quantityList = value;
                OnPropertyChanged("QuantityList");
            }
        }

        #endregion

        public MainPage()
        {
            InitializeComponent();

            QuantityList = new List<Item>
            {
                new Item{Title = "Quantity1", Quantity = "0", EntryId = 1},
                new Item{Title = "Quantity2", Quantity = "0", EntryId = 2},
                new Item{Title = "Quantity3", Quantity = "0", EntryId = 3},
                new Item{Title = "Quantity4", Quantity = "0", EntryId = 4},
                new Item{Title = "Quantity5", Quantity = "0", EntryId = 5}
            };
            this.BindingContext = this;
        }


        /// <summary>
        /// Text entry Completed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEntryCompleted(object sender, EventArgs e)
        {
            var entry = sender as Entry; 
            if(entry != null)
            {
                var list = EntryListView.TemplatedItems.ToList();
                var index = Convert.ToInt32(entry.AutomationId) - 1;
                if ((index + 1) >= list.Count)
                    return;
                var nextIndex = index + 1;
                //Entry is added as second element on view cell grid. So, select children of element 1
                var next = ((list[nextIndex] as ViewCell).View as Grid).Children.ElementAt(1);
                next?.Focus();
            }
            
        }
    }


    /// <summary>
    /// Item class
    /// </summary>
    public class Item
    {
        public string Title { get; set; }
        public string Quantity { get; set; }
        public int EntryId { get; set; }
    }


}
