﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.ItemAdapter.Extensions;

namespace Sitecore.ItemAdapter.FieldTypes
{
    public class ItemAdapterFileUrlFieldAttribute : ItemAdapterTextFieldAttribute
    {
        public ItemAdapterFileUrlFieldAttribute(string fieldId) : base(fieldId)
        {
        }

        protected override object GetValue(Item item, Type propertyType, int depth)
        {
            return item.GetFileUrl(FieldId);
        }
    }
}