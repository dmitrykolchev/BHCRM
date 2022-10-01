using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DykBits.Crm.Data;
using DykBits.Crm.Input;
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI
{
    public class CalculationDetailsEditorControlBase: UserControl, IDetailsControl
    {
        private GridControl grid;
        public CalculationDetailsEditorControlBase()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.grid = (GridControl)this.FindName("grid");
        }
        protected CalculationStatement Document
        {
            get { return (CalculationStatement)this.DataContext; }
        }

        private bool IsReadOnly
        {
            get { return this.Document == null || this.Document.IsReadOnly; }
        }
        void IDetailsControl.CanExecute(CanExecuteRoutedEventArgs e)
        {
            CanExecuteOverride(e);
            if (!e.Handled)
                CanExecuteInternal(e);
        }
        protected virtual void CanExecuteOverride(CanExecuteRoutedEventArgs e)
        {
        }
        private void CanExecuteInternal(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        e.CanExecute = this.grid != null && !IsReadOnly;
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is CalculationStatementItem)
                            {
                                CalculationStatementItem item = (CalculationStatementItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveUp && !IsReadOnly;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.MoveDown:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is CalculationStatementItem)
                            {
                                CalculationStatementItem item = (CalculationStatementItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveDown && !IsReadOnly;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.AddRow:
                    case UICommandId.AddEmptyRow:
                        if (this.grid != null)
                        {
                            CalculationStatementItem item = (CalculationStatementItem)this.grid.SelectedItem;
                            e.CanExecute = item != null && !item.SectionItem.ReadOnly && !IsReadOnly;
                        }
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        if (this.grid != null)
                        {
                            CalculationStatementItem item = this.grid.SelectedItem as CalculationStatementItem;
                            e.CanExecute = item != null && !item.ReadOnly && !IsReadOnly;
                        }
                        e.Handled = true;
                        break;
                }
            }
        }

        void IDetailsControl.Executed(ExecutedRoutedEventArgs e)
        {
            ExecutedOverride(e);
        }

        private void ExecutedOverride(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        AddGroup();
                        e.Handled = true;
                        break;
                    case UICommandId.AddRow:
                        AddList();
                        e.Handled = true;
                        break;
                    case UICommandId.AddEmptyRow:
                        AddItem();
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        DeleteItem();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        MoveUp();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveDown:
                        MoveDown();
                        e.Handled = true;
                        break;
                }
            }
        }

        protected virtual void AddGroup()
        {
            CalculationStatementSection section = new CalculationStatementSection();
            ModalWindow window = ModalWindow.Create("Добавить раздел калькуляции", new CalculationStatementTemplateAddSectionControl(), section, Window.GetWindow(this));
            if (window.ShowDialog() == true)
            {
                this.grid.BeginDataUpdate();
                CalculationStatementSectionItem sectionItem = null;
                try
                {
                    sectionItem = Document.Items.Add(section);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.RefreshData();
                    this.grid.SelectedItem = sectionItem;
                }
            }
            window.Close();
        }

        protected virtual void AddList()
        {
            throw new NotImplementedException();
        }

        protected virtual void AddItem()
        {
            CalculationStatementItem selectedItem = (CalculationStatementItem)this.grid.SelectedItem;
            CalculationStatementLine line = new CalculationStatementLine();
            CalculationStatementLineItem newItem = null;
            this.grid.BeginDataUpdate();
            try
            {
                newItem = Document.Items.Add(selectedItem.SectionItem, line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.SelectedItem = newItem;
            }
        }

        protected virtual void DeleteItem()
        {
            CalculationStatementItem selectedItem = (CalculationStatementItem)this.grid.SelectedItem;
            if (selectedItem is CalculationStatementLineItem)
            {
                this.grid.BeginDataUpdate();
                try
                {
                    Document.Items.Remove((CalculationStatementLineItem)selectedItem);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                }
            }
            else
            {
                if (ApplicationManager.ShowQuestion("Предпринимается попытка удалить раздел калькуляции. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.grid.BeginDataUpdate();
                    try
                    {
                        Document.Items.Remove(selectedItem.SectionItem);
                    }
                    finally
                    {
                        this.grid.EndDataUpdate();
                    }
                }
            }
        }

        protected virtual void MoveUp()
        {
            this.grid.BeginDataUpdate();
            CalculationStatementItem item = (CalculationStatementItem)grid.SelectedItem;
            try
            {
                if (item is CalculationStatementSectionItem)
                    Document.Items.MoveUp((CalculationStatementSectionItem)item);
                else if (item is CalculationStatementLineItem)
                    Document.Items.MoveUp((CalculationStatementLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }

        protected virtual void MoveDown()
        {
            this.grid.BeginDataUpdate();
            CalculationStatementItem item = (CalculationStatementItem)grid.SelectedItem;
            try
            {
                if (item is CalculationStatementSectionItem)
                    Document.Items.MoveDown((CalculationStatementSectionItem)item);
                else if (item is CalculationStatementLineItem)
                    Document.Items.MoveDown((CalculationStatementLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }
    }
}
