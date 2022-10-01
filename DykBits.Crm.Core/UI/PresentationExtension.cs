using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection;

namespace DykBits.Crm.UI
{
    public abstract class PresentationExtension
    {
        private Control _owner;
        private bool _initialized;
        private PresentationExtensionType _extensionType;
        protected PresentationExtension()
        {
        }

        private void InvokeInitialize(PresentationExtensionType extensionType, Control owner)
        {
            this._extensionType = extensionType;
            this._owner = owner;
            Initialize(extensionType.Parameter);
            this._initialized = true;
        }

        public bool IsInitialized
        {
            get { return this._initialized; }
        }
        protected virtual void Initialize(object parameter)
        {
        }

        public Control Owner
        {
            get { return this._owner; }
        }

        internal void InvokeCanExecute(CanExecuteRoutedEventArgs e)
        {
            CanExecute(e);
        }

        protected virtual void CanExecute(CanExecuteRoutedEventArgs e)
        {
        }

        internal void InvokeExecute(ExecutedRoutedEventArgs e)
        {
            Execute(e);
        }
        protected virtual void Execute(ExecutedRoutedEventArgs e)
        {
        }

        public static PresentationExtension Create(PresentationExtensionType extensionType, Control owner)
        {
            if (extensionType == null)
                throw new ArgumentNullException("extensionType");
            if (!typeof(PresentationExtension).IsAssignableFrom(extensionType.ExtensionType))
                throw new ArgumentException("invalid extension type");
            PresentationExtension viewExtension = (PresentationExtension)Activator.CreateInstance(extensionType.ExtensionType);
            viewExtension.InvokeInitialize(extensionType, owner);
            return viewExtension;
        }
    }
}
