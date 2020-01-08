﻿using System;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Services;
using Umbraco.Core.Strings;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// CUstom value editor so we can serialize with the correct date format (excluding time)
    /// and includes the date validator
    /// </summary>
    internal class DateValueEditor : DataValueEditor
    {
        public DateValueEditor(IDataTypeService dataTypeService, ILocalizationService localizationService, IShortStringHelper shortStringHelper, DataEditorAttribute attribute)
            : base(dataTypeService, localizationService, Current.Services.TextService, shortStringHelper, attribute)
        {
            Validators.Add(new DateTimeValidator());
        }

        public override object ToEditor(IProperty property, string culture= null, string segment = null)
        {
            var date = property.GetValue(culture, segment).TryConvertTo<DateTime?>();
            if (date.Success == false || date.Result == null)
            {
                return String.Empty;
            }
            //Dates will be formatted as yyyy-MM-dd
            return date.Result.Value.ToString("yyyy-MM-dd");
        }
    }
}
