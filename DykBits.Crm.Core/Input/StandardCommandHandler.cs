using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection;

namespace DykBits.Crm.Input
{
    public sealed class StandardCommandHandler
    {
        private static readonly Dictionary<Type, Dictionary<string, MethodInfo>> _handlerCache = new Dictionary<Type, Dictionary<string, MethodInfo>>();
        public static void HandleExecutedCommand(object target, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.None)
                {
                    Type targetType = target.GetType();
                    Dictionary<string, MethodInfo> handlers;
                    if (!_handlerCache.TryGetValue(targetType, out handlers))
                    {
                        handlers = InitializeCommandHandlers(targetType);
                        _handlerCache.Add(targetType, handlers);
                    }
                    MethodInfo method;
                    if (handlers.TryGetValue(command.Text, out method))
                    {
                        method.Invoke(target, new object[] { e });
                    }
                }
            }
        }

        private static Dictionary<string, MethodInfo> InitializeCommandHandlers(Type targetType)
        {
            Dictionary<string, MethodInfo> handlers = new Dictionary<string, MethodInfo>();

            var methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<CommandHandlerAttribute>();
                if (attribute != null)
                    handlers.Add(attribute.CommandText, method);
            }
            return handlers;
        }
    }
}
