using System;
using System.Collections;
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
using Microsoft.Win32;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI;assembly=DykBits.Crm.UI"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:AttachmentList/>
    ///
    /// </summary>
    public class AttachmentList : Control
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(AttachmentList),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AttachmentList control = (AttachmentList)d;
            control.SetItemsSource((IEnumerable)e.NewValue);
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        static AttachmentList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AttachmentList), new FrameworkPropertyMetadata(typeof(AttachmentList)));
        }

        private ListBox _listBox;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._listBox = (ListBox)GetTemplateChild("ListBox_Part");
            this._listBox.MouseDown += _listBox_MouseDown;
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.OpenAttachment, OnCommandExecuted, OnCommandCanExecute));
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.SaveAttachment, OnCommandExecuted, OnCommandCanExecute));
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.DeleteAttachment, OnCommandExecuted, OnCommandCanExecute));
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.Paste, OnCommandExecuted, OnCommandCanExecute));
            InputBindings.Add(new KeyBinding(CrmApplicationCommands.Paste, Key.V, ModifierKeys.Control));
            InputBindings.Add(new KeyBinding(CrmApplicationCommands.OpenAttachment, Key.Enter, ModifierKeys.None));
            InputBindings.Add(new KeyBinding(CrmApplicationCommands.DeleteAttachment, Key.Delete, ModifierKeys.None));
            SetItemsSource(ItemsSource);
        }

        void _listBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.FocusedElement != this._listBox)
                Keyboard.Focus(this._listBox);
        }

        protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDoubleClick(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CrmApplicationCommands.OpenAttachment.CanExecute(null, this))
                {
                    CrmApplicationCommands.OpenAttachment.Execute(null, this);
                    e.Handled = true;
                }
            }
        }

        private AttachmentItem SelectedAttachment
        {
            get
            {
                if (this._listBox != null)
                    return this._listBox.SelectedItem as AttachmentItem;
                return null;
            }
        }

        private void OnCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Paste:
                        PasteAttachment();
                        e.Handled = true;
                        break;
                    case UICommandId.OpenAttachment:
                        OpenAttachment();
                        e.Handled = true;
                        break;
                    case UICommandId.SaveAttachment:
                        SaveAttachment();
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteAttachment:
                        DeleteAttachment();
                        e.Handled = true;
                        break;
                }
            }
        }

        private DataItem DataSource
        {
            get
            {
                EditorControlBase editor = Utils.FindVisualParent<EditorControlBase>(this);
                if (editor != null)
                    return editor.SelectedDataItem as DataItem;
                return null;
            }
        }

        private void PasteAttachment()
        {
            

            using (WaitCursor cursor = new WaitCursor())
            {
                if (Clipboard.ContainsData("FileGroupDescriptorW") || Clipboard.ContainsData("FileGroupDescriptor"))
                {
                    IDataObject data = Clipboard.GetDataObject();
                    FileGroupDescriptorHelper fgdh = new FileGroupDescriptorHelper(data);
                    for (int index = 0; index < fgdh.GetFileCount(); ++index)
                    {
                        FileGroupDescriptorHelper.FileContent content = fgdh.ReadFileContent(index);
                        AttachmentItem item = AttachmentItem.CreateInstance(content.FileName, content.Stream);
                        DataItem dataItem = this.DataSource as DataItem;
                        if (dataItem != null)
                            dataItem.Attachments.Add(item);
                    }
                }
                else if (Clipboard.ContainsFileDropList())
                {
                    var files = Clipboard.GetFileDropList();
                    if (files.Count > 0)
                    {
                        foreach (string file in files)
                        {
                            AttachmentItem item = AttachmentItem.CreateInstance(file);
                            DataItem dataItem = this.DataSource as DataItem;
                            if (dataItem != null)
                                dataItem.Attachments.Add(item);
                        }
                    }
                }
            }
        }

        private void OpenAttachment()
        {
            SelectedAttachment.Open();
        }

        private void SaveAttachment()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = SelectedAttachment.Name;
            dialog.Filter = "Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                SelectedAttachment.Download(dialog.FileName);
            }
        }

        private void DeleteAttachment()
        {
            ((IList)this.ItemsSource).Remove(this.SelectedAttachment);
        }

        private void OnCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.OpenAttachment:
                    case UICommandId.SaveAttachment:
                    case UICommandId.DeleteAttachment:
                        e.CanExecute = this.SelectedAttachment != null;
                        e.Handled = true;
                        break;
                    case UICommandId.Paste:
                        e.CanExecute = (Clipboard.ContainsFileDropList() || Clipboard.ContainsData("FileGroupDescriptorW") || Clipboard.ContainsData("FileGroupDescriptor")) && DataSource != null;
                        e.Handled = true;
                        break;
                }
            }
        }

        private void SetItemsSource(IEnumerable itemsSource)
        {
            if (this._listBox != null)
                this._listBox.ItemsSource = itemsSource;
        }
    }
}
