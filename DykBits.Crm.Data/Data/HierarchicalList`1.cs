using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IHierarchicalListNode
    {
        int Level { get; }
    }

    public class HierarchicalList<T>: ObservableCollection<T> where T: IHierarchicalListNode
    {
        public HierarchicalList()
        {
        }

        public void AppendChild(T parent, T child)
        {
            int parentIndex = this.IndexOf(parent);
            for (int index = parentIndex + 1; index < this.Count; ++index)
            {
                if (parent.Level >= this[index].Level)
                {
                    this.Insert(index, child);
                    return;
                }
            }
            this.Add(child);
        }

        public void DeleteNode(T node)
        {
            int nodeIndex = this.IndexOf(node);
            int index = nodeIndex + 1;
            for (; index < this.Count; ++index)
            {
                if (node.Level >= this[index].Level)
                    break;
            }
            while (nodeIndex < index)
            {
                this.RemoveAt(--index);
            }
        }

        public T GetParent(T node)
        {
            int nodeIndex = this.IndexOf(node);
            int parentIndex = GetParentIndex(nodeIndex);
            if (parentIndex < 0)
                return default(T);
            return this[parentIndex];
        }

        public int GetParentIndex(int nodeIndex)
        {
            if (nodeIndex < 0 || nodeIndex >= this.Count)
                throw new ArgumentOutOfRangeException("nodeIndex");
            T node = this[nodeIndex];
            for (int index = nodeIndex - 1; index >= 0; --index)
            {
                if (node.Level > this[index].Level)
                    return index;
            }
            return -1;
        }

        public IEnumerable<T> GetChildren(T node)
        {
            int nodeIndex = this.IndexOf(node);
            int childLevel = node.Level + 1;
            for (int index = nodeIndex + 1; index < this.Count; ++index)
            {
                T currentNode = this[index];
                if (currentNode.Level == childLevel)
                    yield return currentNode;
                else if (currentNode.Level < childLevel)
                    break;
            }
            yield break;
        }

    }
}
