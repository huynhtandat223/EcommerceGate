﻿using EcommerceGate.Infrastructures.Models;

namespace EcommerceGate.Core.Models
{
    public class AppSetting : EntityBaseWithTypedId<string>
    {
        public AppSetting(string id)
        {
            Id = id;
        }

        public string Value { get; set; }

        public string Module { get; set; }

        public bool IsVisibleInCommonSettingPage { get; set; }
    }
}
