﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecore.ItemAdapter.FieldTypes
{
    public class SitecoreRichTextFieldAttribute : SitecoreFieldModelAttribute
    {
        public SitecoreRichTextFieldAttribute(string fieldId) : base(fieldId)
        {
        }

        protected override object GetValue(Item item, Type propertyType)
        {
            if (propertyType.IsEquivalentTo(typeof(string)))
            {
                return item[FieldId];
            }
            else
            {
                return null;
            }
        }
    }

}
