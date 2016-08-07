using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfCursus
{
    /// <summary>
    /// Interaction logic for OpleidingenWindow.xaml
    /// </summary>
    public partial class OpleidingenWindow : Window
    {
        // to keep up which listbox we are dragging from.
        ListBox draglist;

        public OpleidingenWindow()
        {
            InitializeComponent();
            AddItemsToListbox();
        }       

        private ListBoxItem FindListBoxItem(object dragItem)
        {
            //cast the dependencyobject.
            DependencyObject choice = (DependencyObject)dragItem;
            while (choice != null)
            {
                // If choice is not of type listboxitem, 
                // ask for the parent with visualtreehelper.Getparent function.
                if (choice is ListBoxItem)
                    return (ListBoxItem)choice;
                choice = VisualTreeHelper.GetParent(choice);
            }
            return null;
        }
        private void DragListBox_Mousemove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                draglist = (ListBox)sender;
                // Original source contains the object that you drag
                // and uses that as parameter to find the corresponding listbox.
                ListBoxItem programItem = FindListBoxItem(e.OriginalSource);
                if (draglist.SelectedIndex >= 0 && programItem != null)
                {
                    DataObject dragData = new DataObject("myprogram", programItem.Content);
                    DragDrop.DoDragDrop(programItem, dragData, DragDropEffects.Move);
                }
            }
        }
        private void DropListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myprogram"))
            {
                OfficePrograms dragProgram = (OfficePrograms)e.Data.GetData("myprogram");
                ListBox droplist = (ListBox)sender;
                if (draglist != droplist)
                {
                    droplist.Items.Add(dragProgram);
                    draglist.Items.Remove(draglist.SelectedItem);
                }

            }
        }
        private void AddItemsToListbox()
        {
            ListBoxPrograms.Items.Add(new OfficePrograms("Access", new BitmapImage(new Uri(@"Resources\access.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Excel", new BitmapImage(new Uri(@"Resources\excel.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Groove", new BitmapImage(new Uri(@"Resources\groove.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("InfoPath", new BitmapImage(new Uri(@"Resources\infopath.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("OneNote", new BitmapImage(new Uri(@"Resources\onenote.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Outlook", new BitmapImage(new Uri(@"Resources\outlook.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Powerpoint", new BitmapImage(new Uri(@"Resources\powerpoint.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Publisher", new BitmapImage(new Uri(@"Resources\publisher.png", UriKind.Relative))));
            ListBoxPrograms.Items.Add(new OfficePrograms("Word", new BitmapImage(new Uri(@"Resources\word.png", UriKind.Relative))));
            ListBoxPrograms.SelectedIndex = 0;
        }
    }

}

