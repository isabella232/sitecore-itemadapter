﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.ItemAdapter.Extensions;

namespace Sitecore.ItemAdapter.FieldTypes
{
    public class ItemAdapterIntegerFieldAttribute : ItemAdapterFieldAttribute
    {
        public ItemAdapterIntegerFieldAttribute(string fieldId) : base(fieldId)
        {
        }

        protected override object GetValue(Item item, Type propertyType, int depth)
        {
            return new Nullable<int>(item.GetIntegerFieldValue(FieldId));
        }

        public override bool CheckType(Type propertyType)
        {
            if (propertyType.IsEquivalentTo(typeof(int))
                || propertyType.Equals(ExpectedType())
                || (propertyType.IsGenericType
                   && typeof(int) == propertyType.GetGenericArguments().FirstOrDefault()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Type ExpectedType()
        {
            return typeof(Nullable<int>);
        }

        protected override object SetValue(Item item, Type propertyType, object propertyValue)
        {
            throw new NotImplementedException();
        }
    }
}
