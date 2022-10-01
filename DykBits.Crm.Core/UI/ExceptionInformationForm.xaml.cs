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
using System.Windows.Shapes;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ExceptionInformationForm.xaml
    /// </summary>
    public partial class ExceptionInformationForm : DevExpress.Xpf.Core.DXWindow
    {
        public ExceptionInformationForm()
        {
            InitializeComponent();
            this.Loaded += ExceptionInformationForm_Loaded;
        }

        void ExceptionInformationForm_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var overflowGrid = toolbar.Template.FindName("OverflowGrid", toolbar) as FrameworkElement;
                if (overflowGrid != null)
                {
                    overflowGrid.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExceptionInformationDetailsForm dialog = new ExceptionInformationDetailsForm();
                dialog.DataContext = this.DataContext;
                dialog.Owner = this;
                dialog.ShowDialog();
                dialog.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ExceptionInformation exceptionInformation = (ExceptionInformation)this.DataContext;
                Clipboard.SetText(exceptionInformation.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
