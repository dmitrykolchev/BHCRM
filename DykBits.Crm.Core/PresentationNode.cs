using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using DykBits.Crm.Data;
using DykBits.Crm.UI;

namespace DykBits.Crm
{
    [ContentProperty("Children")]
    public class PresentationNode
    {
        private const string GeneralCaption = "Общие";

        private PresentationNodeCollection _children;
        private PresentationNodeCollection _views;

        private PresentationNode _parent;
        private ImageSource _smallImage;
        private ImageSource _largeImage;
        private string _caption;
        private PresentationExtensionTypeCollection _extensionTypes;
        public PresentationNode()
        {
        }

        public int Id { get; set; }
        public int NodeType { get; set; }
        [DefaultValue(GeneralCaption)]
        public string Caption
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._caption))
                    return GeneralCaption;
                return this._caption;
            }
            set
            {
                this._caption = value;
            }
        }
        public PresentationNode Parent
        {
            get { return this._parent; }
            internal set { this._parent = value; }
        }
        [DefaultValue(null)]
        public string Parameter
        {
            get;
            set;
        }
        public string DefaultView { get; set; }
        public virtual string Key { get; set; }
        [DefaultValue(null)]
        public ImageSource SmallImage
        {
            get
            {
                if (this._smallImage == null)
                {
                    this._smallImage = GetDefaultImage(true);
                }
                return this._smallImage;
            }
            set
            {
                this._smallImage = value;
            }
        }

        private static readonly BitmapImage FolderImageSmall = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Folder.png", UriKind.Absolute));
        private static readonly BitmapImage ViewImageSmall = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/View.png", UriKind.Absolute));
        private static readonly BitmapImage CalendarImageSmall = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Calendar.png", UriKind.Absolute));
        private static readonly BitmapImage ViewCollectionImageSmall = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/ViewCollection.png", UriKind.Absolute));
        private static readonly BitmapImage DataFormImageSmall = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/DataForm.png", UriKind.Absolute));

        private static readonly BitmapImage FolderImageLarge = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/32x32/Folder.png", UriKind.Absolute));
        private static readonly BitmapImage ViewImageLarge = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/32x32/View.png", UriKind.Absolute));
        private static readonly BitmapImage CalendarImageLarge = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/32x32/Calendar.png", UriKind.Absolute));
        private static readonly BitmapImage ViewCollectionImageLarge = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/32x32/ViewCollection.png", UriKind.Absolute));
        private static readonly BitmapImage DataFormImageLarge = new BitmapImage(new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/32x32/DataForm.png", UriKind.Absolute));
        private ImageSource GetDefaultImage(bool small)
        {
            if (typeof(DataGridControlBase).IsAssignableFrom(ViewControlType))
                return small ? ViewImageSmall : ViewImageLarge;
            if(typeof(SchedulerControlBase).IsAssignableFrom(ViewControlType))
                return small ? CalendarImageSmall : CalendarImageLarge;
            if (typeof(EditorControlBase).IsAssignableFrom(ViewControlType))
                return small ? DataFormImageSmall : DataFormImageLarge;
            if (this.Views.Count > 0)
                return small ? ViewCollectionImageSmall : ViewCollectionImageLarge;
            return small ? FolderImageSmall : FolderImageLarge;
        }

        [DefaultValue(null)]
        public ImageSource LargeImage
        {
            get
            {
                if (this._largeImage == null)
                {
                    this._largeImage = GetDefaultImage(false);
                }
                return this._largeImage;
            }
            set
            {
                this._largeImage = value;
            }
        }
        private Type _viewControlType;
        public Type ViewControlType
        {
            get
            {
                if (this._viewControlType == null)
                {
                    if (string.IsNullOrEmpty(this.ViewControlTypeName))
                        return null;
                    ITypeResolver typeResolver = ServiceManager.GetService<ITypeResolver>();
                    this._viewControlType = typeResolver.ResolveType(this.ViewControlTypeName);
                }
                return this._viewControlType;
            }
            set
            {
                this._viewControlType = value;
                if (value != null)
                    ViewControlTypeName = value.AssemblyQualifiedName;
                else
                    ViewControlTypeName = null;
            }
        }
        private string _viewControlTypeName;
        public string ViewControlTypeName
        {
            get
            {
                return this._viewControlTypeName;
            }
            set
            {
                this._viewControlTypeName = value;
                this._viewControlType = null;
            }
        }
        public Control CreateViewControl()
        {
            if (ViewControlType == null)
                throw new InvalidOperationException("ViewControlType is undefined");
            Control control = (Control)Activator.CreateInstance(ViewControlType);
            IDataView dataView = control as IDataView;
            if (dataView != null)
                dataView.Node = this;
            return control;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PresentationNodeCollection Children
        {
            get
            {
                if (this._children == null)
                    this._children = new PresentationNodeCollection(this);
                return this._children;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PresentationNodeCollection Views
        {
            get
            {
                if (this._views == null)
                    this._views = new PresentationNodeCollection(this);
                return this._views;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PresentationExtensionTypeCollection ExtensionTypes
        {
            get
            {
                if (this._extensionTypes == null)
                    this._extensionTypes = new PresentationExtensionTypeCollection(this);
                return this._extensionTypes;
            }
        }
    }
}
