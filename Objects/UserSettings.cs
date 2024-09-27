using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;

namespace EveHelperWF.Objects
{
    public class MyUserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public Color BackgroundColor
        {
            get
            {
                return ((Color)this["BackgroundColor"]);
            }
            set
            {
                this["BackgroundColor"] = (Color)value;
            }
        }
    }
}
