using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValidateDataChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hash;
        bool discardChanges;

        public MainWindow()
        {
            InitializeComponent();

            discardChanges = false;

            var contact = new Contact("Abel", "abel.o.d@outlook.com", "designcomwpf");
            hash = contact.GetHashCode();

            this.DataContext = contact;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(this.DataContext.GetHashCode() != hash && !discardChanges)
            {
                SnackbarUnsavedChanges.IsActive = true;
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save Data
        }

        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            SnackbarUnsavedChanges.IsActive = false;
            discardChanges = true;
            this.Close();
        }
    }
}
