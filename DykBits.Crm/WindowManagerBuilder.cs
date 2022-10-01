// Copyright (c) 2014-2015 Dmitry Kolchev
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.Data;
using DykBits.Crm.UI;
using PresentationNodeData = DykBits.Crm.Data.PresentationNode;

namespace DykBits.Crm
{
    class WindowManagerBuilder
    {
        public static WindowManager CreateInstance()
        {
            WindowManagerBuilder builder = new WindowManagerBuilder();
            builder.CreateWindowManager();
            return builder._windowManager;
        }

        List<PresentationNodeView> _nodes;
        Dictionary<int, PresentationNodeApplicationRole> _accessibleNodes;

        WindowManager _windowManager;
        private void CreateWindowManager()
        {
            this._windowManager = new WindowManager();
            IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<PresentationNodeData>();
            var filter = (PresentationNodeFilter)dataAdapter.CreateFilter(null, null);
            filter.States = new byte[] { (byte)PresentationNodeState.Active };
            filter.AllNodeTypes = true;
            filter.AllNodes = true;
            this._nodes = dataAdapter.Browse(filter.ToXml()).OfType<PresentationNodeView>().OrderBy(t=>t.OrdinalPosition).ToList();
            this._accessibleNodes = GetAccessibleNodes();
            CreatePresentationManagerNodes(this._nodes.Where(t => !t.ParentId.HasValue));
        }

        private Dictionary<int, PresentationNodeApplicationRole> GetAccessibleNodes()
        {
            PresentationNodeApplicationRoleDataAdapterProxy dataAdapter = new PresentationNodeApplicationRoleDataAdapterProxy();
            return dataAdapter.Browse(Filter.EmptyXml).ToDictionary(t => t.PresentationNodeId);
        }
        public IEnumerable<PresentationNodeView> GetChildren(int parentId)
        {
            return this._nodes.Where(t => t.ParentId == parentId);
        }
        public bool IsAccessible(PresentationNodeView node)
        {
            return this._accessibleNodes.ContainsKey(node.Id);
        }
        private void CreatePresentationManagerNodes(IEnumerable<PresentationNodeView> rootNodes)
        {
            foreach (var node in rootNodes)
            {
                if (IsAccessible(node))
                {
                    var item = CreatePresentationManager(node);
                    _windowManager.Windows.Add(item);
                    AddChildren(item);
                }
            }
        }
        private PresentationManager CreatePresentationManager(PresentationNodeView node)
        {
            string className = null;
            if (node.DocumentTypeId.HasValue)
            {
                DocumentMetadata metadata = DocumentManager.GetMetadata(node.DocumentTypeId.Value);
                className = metadata.ClassName;
            }
            string defaultView = null;
            if (node.DefaultViewId.HasValue)
            {
                defaultView = _nodes.Where(t => t.Id == node.DefaultViewId.Value).Single().Key;
            }
            PresentationManager item = new PresentationManager
            {
                Id = node.Id,
                NodeType = node.NodeType,
                Caption = node.FileAs,
                Key = node.Key,
                ClassName = className,
                DefaultView = defaultView,
                LargeImage = node.LargeImage,
                SmallImage = node.SmallImage,
                Parameter = node.Parameter,
                ViewControlTypeName = node.ViewControlTypeName,
            };
            return item;
        }
        private PresentationNode CreatePresentationNode(PresentationNodeView node)
        {
            string defaultView = null;
            if (node.DefaultViewId.HasValue)
            {
                defaultView = _nodes.Where(t => t.Id == node.DefaultViewId.Value).Single().Key;
            }
            PresentationManager item = new PresentationManager
            {
                Id = node.Id,
                NodeType = node.NodeType,
                Caption = node.FileAs,
                DefaultView = defaultView,
                Key = node.Key,
                LargeImage = node.LargeImage,
                SmallImage = node.SmallImage,
                Parameter = node.Parameter,
                ViewControlTypeName = node.ViewControlTypeName,
            };
            return item;
        }
        private void AddChildren(PresentationNode parent)
        {
            var childNodes = GetChildren(parent.Id);
            foreach (var node in childNodes)
            {
                if (IsAccessible(node))
                {
                    if (parent.NodeType == PresentationNodeType.PresentationSet)
                    {
                        PresentationNode child = CreatePresentationNode(node);
                        parent.Views.Add(child);
                        AddChildren(child);
                    }
                    else if (parent.NodeType == PresentationNodeType.Folder)
                    {
                        PresentationNode child = CreatePresentationNode(node);
                        parent.Children.Add(child);
                        AddChildren(child);
                    }
                }
            }
        }
    }
}
