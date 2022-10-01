using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DykBits.Crm.UI
{
    public class CommandLocker
    {
        private ICommand _command;
        public CommandLocker(ICommand command)
        {
            this._command = command;
        }

        public ICommand Command
        {
            get { return this._command; }
        }

        private int _lockCount;
        public void Lock()
        {
            System.Threading.Interlocked.Increment(ref _lockCount);
        }

        public void Unlock()
        {
            if (this._lockCount == 0)
                throw new InvalidOperationException();
            System.Threading.Interlocked.Decrement(ref _lockCount);
        }
        internal int LockCount
        {
            get { return this._lockCount; }
        }
    }

    public class CommandLockerCollection: Collection<CommandLocker>
    {
        public Dictionary<ICommand, CommandLocker> _items = new Dictionary<ICommand, CommandLocker>();
        public CommandLockerCollection()
        {
        }
        public bool IsLocked(ICommand command)
        {
            CommandLocker value;
            if (_items.TryGetValue(command, out value))
                return value.LockCount > 0;
            return false;
        }
        protected override void InsertItem(int index, CommandLocker item)
        {
            this._items.Add(item.Command, item);
            base.InsertItem(index, item);
        }

        protected override void ClearItems()
        {
            while (this.Count > 0)
                RemoveAt(0);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            _items.Remove(item.Command);
            base.RemoveItem(index);
        }

        public CommandLocker this[ICommand command]
        {
            get
            {
                CommandLocker value;
                if (!this._items.TryGetValue(command, out value))
                {
                    value = new CommandLocker(command);
                    this.Add(value);
                }
                return value;
            }
        }
    }
}
