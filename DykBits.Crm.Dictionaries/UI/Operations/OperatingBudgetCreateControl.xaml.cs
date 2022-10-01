﻿using System;
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
using DykBits.Crm.Input;

namespace DykBits.Crm.UI.Operations
{
    /// <summary>
    /// Interaction logic for OperatingBudgetCreateControl.xaml
    /// </summary>
    public partial class OperatingBudgetCreateControl : UserControl, ICommandTarget
    {
        public OperatingBudgetCreateControl()
        {
            InitializeComponent();
        }
        public void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.CanExecute = this.docOrganization.SelectedValue != null;
                e.Handled = true;
            }
        }
        public void Executed(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.Handled = true;
            }
        }
    }
}
