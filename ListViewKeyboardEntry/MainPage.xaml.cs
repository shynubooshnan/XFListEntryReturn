using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewKeyboardEntry
{
    public partial class MainPage : ContentPage
    {
        #region variables
        private int _nextIndex;

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

        private double _collectionViewHeight { get; set; }
        public double CollectionViewHeight
        {
            get => _collectionViewHeight;
            set
            {
                _collectionViewHeight = value;
                OnPropertyChanged("CollectionViewHeight");
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
                new Item{Title = "Quantity5", Quantity = "0", EntryId = 5},
                new Item{Title = "Quantity6", Quantity = "0", EntryId = 6},
                new Item{Title = "Quantity7", Quantity = "0", EntryId = 7},
                new Item{Title = "Quantity8", Quantity = "0", EntryId = 8},
                new Item{Title = "Quantity9", Quantity = "0", EntryId = 9},
                new Item{Title = "Quantity10", Quantity = "0", EntryId = 10},
                new Item{Title = "Quantity11", Quantity = "0", EntryId = 11},
                new Item{Title = "Quantity12", Quantity = "0", EntryId = 12},
                new Item{Title = "Quantity13", Quantity = "0", EntryId = 13},
                new Item{Title = "Quantity14", Quantity = "0", EntryId = 14},
                new Item{Title = "Quantity15", Quantity = "0", EntryId = 15}
            };

            //set collection view height
            CollectionViewHeight = QuantityList.Count * 40;
            BindingContext = this;
        }

        /// <summary>
        /// Text entry Completed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEntryCompleted(object sender, EventArgs e)
        {
            if (sender is Entry entry)
            {
                _nextIndex = 0;
                var list = (entry?.Parent?.Parent as CollectionView)?.LogicalChildren;
                if (list == null)
                    return;
                var index = Convert.ToInt32(entry.AutomationId);
                if ((index + 1) > list.Count)
                    return;
                _nextIndex = index + 1;
                //Entry is added as second element on view cell grid. So, select children of element 1
                var nextElement = list.FirstOrDefault(x => (x as Grid).Children.ElementAt(1).AutomationId ==
                _nextIndex.ToString());
                if(nextElement != null)
                {
                    var next = (nextElement as Grid).Children.ElementAt(1);
                    next?.Focus();
                }
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
