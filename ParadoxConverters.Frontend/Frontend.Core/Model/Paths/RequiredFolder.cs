﻿using Frontend.Core.Model.Paths.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Core.Model.Paths
{
    public class RequiredFolder : RequiredItemBase, IRequiredFolder
    {
        public RequiredFolder(string tagName, string friendlyName, string description, string defaultValue)
            : base(tagName, friendlyName, description, defaultValue)
        {
        }
    }
}
