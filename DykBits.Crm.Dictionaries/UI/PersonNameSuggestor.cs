using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DykBits.Crm.UI
{
    class PersonNameSuggestor
    {
        private PersonNameBox _personNameControl;
        private DocumentPicker _accountControl;
        private TextBox _accountNameControl;
        private ComboBox _fileAsControl;
        private ObservableCollection<string> _fileAsItems = new ObservableCollection<string>();

        public PersonNameSuggestor(ComboBox fileAsControl, PersonNameBox personNameControl, TextBox accountNameControl)
        {
            this._personNameControl = personNameControl;
            this._accountNameControl = accountNameControl;
            this._fileAsControl = fileAsControl;
            personNameControl.PersonNameChanged += personNameControl_PersonNameChanged;
            accountNameControl.TextChanged += accountNameControl_TextChanged;
            fileAsControl.KeyDown += fileAsControl_KeyDown;
            fileAsControl.ItemsSource = _fileAsItems;
            UpdateFileAsCombo();
        }
        public PersonNameSuggestor(ComboBox fileAsControl, PersonNameBox personNameControl, DocumentPicker accountControl)
        {
            this._personNameControl = personNameControl;
            this._accountControl = accountControl;
            this._fileAsControl = fileAsControl;
            personNameControl.PersonNameChanged += personNameControl_PersonNameChanged;
            accountControl.SelectionChanged += accountControl_SelectionChanged;
            fileAsControl.KeyDown += fileAsControl_KeyDown;
            fileAsControl.ItemsSource = _fileAsItems;
            UpdateFileAsCombo();
        }

        void accountControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UpdateFileAsCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        public bool CanUpdateFileAsValue { get; set; }

        private bool _fileAsValueChanged;

        void fileAsControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _fileAsValueChanged = true;            
        }

        void accountNameControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UpdateFileAsCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        void personNameControl_PersonNameChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateFileAsCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
        public void UpdateFileAsCombo()
        {
            this._fileAsItems.Clear();
            string[] sugestedNames = GetSuggestedNames();
            if (sugestedNames.Length > 0)
            {
                foreach (var name in sugestedNames)
                    this._fileAsItems.Add(name);
                if (CanUpdateFileAsValue && !this._fileAsValueChanged)
                {
                    if(this._fileAsControl.Text != sugestedNames[0])
                        this._fileAsControl.SetCurrentValue(ComboBox.TextProperty, sugestedNames[0]);
                }
            }
            else
            {
                if (CanUpdateFileAsValue && !this._fileAsValueChanged)
                {
                    if(!string.IsNullOrWhiteSpace(this._fileAsControl.Text))
                        this._fileAsControl.SetCurrentValue(ComboBox.TextProperty, string.Empty);
                }
            }
        }

        private string[] GetSuggestedNames()
        {
            string[] suggestedNames = this._personNameControl.GetSuggestedNames();
            List<string> items = new List<string>(suggestedNames);
            string accountName = AccountName;
            if (!string.IsNullOrWhiteSpace(accountName))
            {
                foreach (var name in suggestedNames)
                {
                    items.Add(string.Format("{0} ({1})", name, accountName));
                }
            }
            return items.ToArray();
        }

        private string AccountName
        {
            get
            {
                if (this._accountNameControl != null)
                    return this._accountNameControl.Text;
                if (this._accountControl != null && this._accountControl.SelectedItem != null)
                    return this._accountControl.SelectedItem.FileAs;
                return string.Empty;
            }
        }
    }
}
