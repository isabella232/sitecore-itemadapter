﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ItemAdapter.Extensions;
using Sitecore.ItemAdapter.Model;

namespace Sitecore.ItemAdapter.FieldTypes.NestedModel
{
    public class ItemAdapterNameLookupListFieldAttribute : ItemAdapterNestedModelFieldAttribute
    {
        public ItemAdapterNameLookupListFieldAttribute(string fieldId, Type adapterType) : base(fieldId, adapterType)
        {
        }

        protected override object GetValue(Item item, Type propertyType, int depth)
        {
            SortedList<string,Item> items = item.GetNameLookupList(FieldId);
            SortedList<string, IItemAdapterModel> result = new SortedList<string, IItemAdapterModel>();
            foreach (var kvp in items)
            {
                result.Add(kvp.Key, (IItemAdapterModel)GetModel(kvp.Value, NestedModelType, depth));
            }
            return result;
        }

        public override bool CheckType(Type propertyType)
        {
            if (propertyType.IsGenericType)
            {
                var genericUnderlyingType = propertyType.GetGenericArguments().ElementAt(1);
                if (genericUnderlyingType != null
                    && (genericUnderlyingType == ExpectedInterface()
                        || genericUnderlyingType.GetInterfaces().Any(i => i == ExpectedInterface()))
                )
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        protected override object SetValue(Item item, Type propertyType, object propertyValue)
        {
            throw new NotImplementedException();
        }

        //public override Type ExpectedType()
        //{
        //    return typeof(SortedList<string, IItemAdapterModel>);
        //}
    }
}
