﻿using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Strings;

namespace Umbraco.Web.PropertyEditors
{
    [DataEditor(
        Constants.PropertyEditors.Aliases.UserPicker,
        "User picker",
        "entitypicker",
        ValueType = ValueTypes.Integer,
        Group = Constants.PropertyEditors.Groups.People,
        Icon = Constants.Icons.User)]
    public class UserPickerPropertyEditor : DataEditor
    {
        public UserPickerPropertyEditor(ILogger logger, IShortStringHelper shortStringHelper)
            : base(logger, Current.Services.DataTypeService, Current.Services.LocalizationService, Current.Services.TextService, shortStringHelper)
        { }

        protected override IConfigurationEditor CreateConfigurationEditor() => new UserPickerConfiguration();
    }
}
