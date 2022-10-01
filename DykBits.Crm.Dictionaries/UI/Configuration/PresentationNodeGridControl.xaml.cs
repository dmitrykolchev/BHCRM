using System;
using System.ComponentModel;
using System.Reflection;
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
using DevExpress.Xpf.Grid;
using DykBits.Crm.Input;
using DykBits.Crm.Data;
using PresentationNodeData = DykBits.Crm.Data.PresentationNode;

namespace DykBits.Crm.UI.Configuration
{
    /// <summary>
    /// Interaction logic for PresentationNodeGridControl.xaml
    /// </summary>
    public partial class PresentationNodeGridControl : DataGridControlBase
    {
        public PresentationNodeGridControl()
        {
            InitializeComponent();
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.None && command.Text == "GeneratePresentations")
                {
                    e.CanExecute = true;
                    e.Handled = true;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.None && command.Text == "GeneratePresentations")
                {
                    GeneratePresentations();
                    e.Handled = true;
                }
            }
        }

        protected override void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.Create && "CreateChild".Equals(e.Parameter))
                {
                    e.CanExecute = this.gridView.SelectedItem != null;
                    e.Handled = true;
                }
            }
            base.CanExecute(e);
        }

        protected override void Executed(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.Create && "CreateChild".Equals(e.Parameter))
                {
                    CreateChildNode();
                    e.Handled = true;
                }
            }
            base.Executed(e);
        }

        private void CreateChildNode()
        {
            var selectedItem = (PresentationNodeView)this.gridView.SelectedItem;
            var document = DocumentManager.CreateItem<PresentationNodeData>(null);
            document.ParentId = selectedItem.Id;
            WindowManager.OpenDocument(document);
        }

        private void GeneratePresentations()
        {
            using (new WaitCursor())
            {
                LockRefresh();
                try
                {
                    WindowManager windowManager = ServiceManager.GetService<WindowManager>();
                    CreatePresentationNodeCollection(null, windowManager.Windows);
                }
                finally
                {
                    UnlockRefresh();
                    this.RequeryData();
                }
            }
        }

        private List<PresentationNodeData> CreatePresentationNodeCollection(PresentationNodeData parent, IEnumerable nodes)
        {
            List<PresentationNodeData> created = new List<PresentationNodeData>();
            int ordinalPosition = 0;
            foreach (PresentationNode node in nodes)
            {
                var nodeData = CreatePresentationNode(parent, node, ++ordinalPosition);
                if (node.Views.Count > 0)
                {
                    var viewNodes = CreatePresentationNodeCollection(nodeData, node.Views);
                    foreach (var viewNode in viewNodes)
                    {
                        if (viewNode.Key == node.DefaultView)
                        {
                            nodeData.DefaultViewId = viewNode.Id;
                        }
                    }
                    if (!nodeData.DefaultViewId.HasValue && viewNodes.Count > 0)
                        nodeData.DefaultViewId = viewNodes[0].Id;
                    nodeData = DocumentManager.SaveItem<PresentationNodeData>(nodeData);
                }
                if (node.Children.Count > 0)
                {
                    CreatePresentationNodeCollection(nodeData, node.Children);
                }
                created.Add(nodeData);
            }
            return created;
        }

        private PresentationNodeData CreatePresentationNode(PresentationNodeData parent, PresentationNode node, int index)
        {
            PresentationNodeData item = new PresentationNodeData();
            string guid = Guid.NewGuid().ToString();
            item.FileAs = node.Caption;
            item.OrdinalPosition = index;
            if ((parent == null) || (parent != null && parent.NodeType == PresentationNodeType.PresentationSet) || (parent != null && parent.Key == WindowManager.SelectorsNode))
                item.Key = node.Key;
            else
                item.Key = null;
            item.SmallImage = node.SmallImage as BitmapSource;
            item.LargeImage = node.LargeImage as BitmapSource;
            if (node.ViewControlType != null)
            {
                string typeName = node.ViewControlType.AssemblyQualifiedName;
                int versionIndex = typeName.IndexOf(", Version=");
                if (versionIndex >= 0)
                    item.ViewControlTypeName = typeName.Substring(0, versionIndex);
                else
                    item.ViewControlTypeName = typeName;
            }
            item.Parameter = node.Parameter;
            item.DefaultViewId = null;
            if (node.Views.Count > 0)
                item.NodeType = PresentationNodeType.PresentationSet;
            else if (node.ViewControlType != null)
                item.NodeType = PresentationNodeType.Presentation;
            else
                item.NodeType = PresentationNodeType.Folder;
            if (parent != null)
            {
                item.ParentId = parent.Id;
            }
            if (node is PresentationManager)
            {
                string className = ((PresentationManager)node).ClassName;
                if (!string.IsNullOrEmpty(className))
                {
                    var metadata = DocumentManager.GetMetadata(className);
                    item.DocumentTypeId = metadata.Id;
                    item.FileAs = metadata.Caption;
                    item.SmallImageData = metadata.SmallImageData;
                    item.LargeImageData = metadata.LargeImageData;
                }
            }
            return DocumentManager.SaveItem<PresentationNodeData>(item);
        }
    }
}
