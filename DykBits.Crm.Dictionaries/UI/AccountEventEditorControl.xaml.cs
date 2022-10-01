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
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for AccountEventEditorControl.xaml
    /// </summary>
    public partial class AccountEventEditorControl : EditorControlBase
    {
        public AccountEventEditorControl()
        {
            InitializeComponent();
        }

        private AccountEvent Document
        {
            get { return (AccountEvent)this.DataContext; }
        }

        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);

            AccountEvent document = (AccountEvent)e.OldDataSource;
            if(document != null)
                document.PropertyChanged -= document_PropertyChanged;
            document = (AccountEvent)e.NewDataSource;
            if (document != null)
                document.PropertyChanged += document_PropertyChanged;
        }

        private bool _recursive;

        void document_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (e.PropertyName == AccountEvent.ContactIdProperty)
                    {
                        if (Document.ContactId != 0 && Document.AccountId == 0)
                        {
                            Document.AccountId = ((ContactView)this.documentContact.SelectedItem).AccountId;
                        }
                    }
                    else if (e.PropertyName == AccountEvent.ServiceRequestIdProperty)
                    {
                        if (Document.ServiceRequestId != null && Document.AccountId == 0)
                        {
                            Document.AccountId = ((ServiceRequestView)this.documentServiceRequest.SelectedItem).AccountId;
                        }
                    }
                    else if (e.PropertyName == AccountEvent.AccountIdProperty)
                    {
                        Document.ContactId = 0;
                        Document.ServiceRequestId = null;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        private void comboAccountEventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListManager listManager = ServiceManager.GetService<ListManager>();
                if (comboAccountEventType.SelectedValue == null)
                {
                    comboSubject.ItemsSource = null;
                }
                else
                {
                    int accountEventType = (int)comboAccountEventType.SelectedValue;
                    comboSubject.ItemsSource = listManager.GetList("AccountEventTemplate", (t) => ((AccountEventTemplateView)t).AccountEventTypeId == accountEventType);
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void comboSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDataItem dataItem = comboSubject.SelectedItem as IDataItem;
            if (dataItem != null)
            {
                dataItem = DocumentManager.GetItem<AccountEventTemplate>(dataItem.Id);
                if (dataItem != null && this.Comments != dataItem.Comments)
                {
                    if (!string.IsNullOrWhiteSpace(this.Comments))
                    {
                        if (ApplicationManager.ShowQuestion("Описание события уже заполнено. Обновить?"))
                            SetCurrentValue(CommentsProperty, dataItem.Comments);
                    }
                    else
                    {
                        SetCurrentValue(CommentsProperty, dataItem.Comments);
                    }
                }
            }
        }

        private void documentContact_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            if(Document.AccountId != 0)
                ((ContactFilter)e.DataSourceFilter).AccountId = Document.AccountId;
            else
                ((ContactFilter)e.DataSourceFilter).AccountId = null;
        }

        private void documentServiceRequest_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            if (Document.AccountId != 0)
                ((ServiceRequestFilter)e.DataSourceFilter).AccountId = Document.AccountId;
            else
                ((ServiceRequestFilter)e.DataSourceFilter).AccountId = null;
        }
    }
}
