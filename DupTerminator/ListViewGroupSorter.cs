using System;
//using System.Collections;
//using System.Text.RegularExpressions;	
using System.Windows.Forms;
using System.Collections.Generic; //IComparer<ListViewGroup>

namespace DupTerminator
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    //public class ListViewGroupSorter : IComparer
    public class ListViewGroupSorter : IComparer<ListViewGroup>
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewGroupSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            //OrderOfSort = SortOrder.None;
            OrderOfSort = SortOrder.Ascending;
        }

        /// <summary>
        /// Comparer in group
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        //public int Compare(object x, object y)
        public int Compare(ListViewGroup x, ListViewGroup y)
        {
            int compareResult = 0;
            //ListViewItem listviewX, listviewY;
            long X = 0;
            long Y = 0;

            //ListViewItem x2 = (ListViewItem)x;
            // Cast the objects to be compared to ListViewGroup objects
            ListViewGroup listGroupX = (ListViewGroup)x;
            ListViewGroup listGroupY = (ListViewGroup)y;


            int coun = Math.Min(listGroupX.Items.Count, listGroupY.Items.Count);
            if (coun > 0)
            {
                for (int i = 0; i < coun; i++)
                {
                    //System.Windows.Forms.ListViewItem listItemX = listGroupX.Items[i];
                    //System.Windows.Forms.ListViewItem listItemY = listGroupY.Items[i];

                    if (ColumnToSort == 2) //Size
                    {
                        //X = long.Parse(listItemX.SubItems[ColumnToSort].Text.Replace(" ", string.Empty));
                        //Y = long.Parse(listItemY.SubItems[ColumnToSort].Text.Replace(" ", string.Empty));
                        X = long.Parse(listGroupX.Items[i].SubItems[ColumnToSort].Text.Replace(" ", string.Empty));
                        Y = long.Parse(listGroupY.Items[i].SubItems[ColumnToSort].Text.Replace(" ", string.Empty));
                        //compareResult = (X > Y ? 1 : -1);
                        if (X > Y)
                            compareResult = 1;
                        else if (X < Y)
                        {
                            compareResult = -1;
                        }
                    }
                    else
                    {
                        //compareResult = String.Compare(listItemX.SubItems[ColumnToSort].Text,
                        //                             listItemY.SubItems[ColumnToSort].Text);
                        compareResult = String.Compare(listGroupX.Items[i].SubItems[ColumnToSort].Text,
                            listGroupY.Items[i].SubItems[ColumnToSort].Text);
                    }

                    if (compareResult != 0)
                    {
                        break;
                    }
                }

            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
