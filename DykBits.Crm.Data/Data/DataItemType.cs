using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DataItemType
    {
        private int _id;
        private Type _systemType;
        private DataItemType _baseType;
        private static Dictionary<Type, DataItemType> DataItemTypeFromClrType = new Dictionary<Type, DataItemType>();
        private static int DataItemTypeCount = 0;
        private static object _lock = new object();

        private DataItemType()
        {
        }

        public int Id
        {
            get { return this._id; }
        }

        public Type SystemType
        {
            get { return this._systemType; }
        }

        public DataItemType BaseType
        {
            get { return this._baseType; }
        }

        public string Name
        {
            get { return SystemType.Name; }
        }

        public static DataItemType FromSystemType(Type systemType)
        {
            if (systemType == null)
                throw new ArgumentNullException("systemType");
            if (!typeof(DataItemBase).IsAssignableFrom(systemType))
                throw new ArgumentException(systemType.Name);
            return FromSystemTypeInternal(systemType);
        }

        private static DataItemType FromSystemTypeInternal(Type systemType)
        {
            DataItemType result;
            lock (_lock)
            {
                result = FromSystemTypeRecursive(systemType);
            }
            return result;
        }

        private static DataItemType FromSystemTypeRecursive(Type systemType)
        {
            DataItemType dataItemType;
            if (!DataItemTypeFromClrType.TryGetValue(systemType, out dataItemType))
            {
                dataItemType = new DataItemType();
                dataItemType._systemType = systemType;
                DataItemTypeFromClrType.Add(systemType, dataItemType);
                if (systemType != typeof(DataItemBase))
                {
                    dataItemType._baseType = FromSystemTypeRecursive(systemType.BaseType);
                }
                dataItemType._id = DataItemTypeCount++;
            }
            return dataItemType;
        }

        public override int GetHashCode()
        {
            return this._id;
        }
    }
}
