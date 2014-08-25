﻿using Caliburn.Micro;
using Frontend.Core.Helpers;
using Frontend.Core.Logging;
using Frontend.Core.Model;
using Frontend.Core.Model.Paths;
using Frontend.Core.Model.Paths.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Frontend.Core.Factories.TagReaders
{
    public class FolderTagReader : TagReaderBase
    {
        public FolderTagReader(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
        }

        public IRequiredFolder ReadFolder(XElement xmlElement)
        {
            var directoryTagName = XElementHelper.ReadStringValue(xmlElement, "tag");
            var friendlyName = XElementHelper.ReadStringValue(xmlElement, "friendlyName");
            var description = XElementHelper.ReadStringValue(xmlElement, "description");

            //var installationPath = string.IsNullOrEmpty(steamId) ? this.ReadWindowsUserFolderPath(xmlElement) : this.ReadSteamPath(xmlElement, steamId);
            var installationPath = this.ReadDefaultLocationPath(xmlElement);

            return this.BuildRequiredFolderObject(directoryTagName, installationPath, friendlyName, description);
        }

        /// <summary>
        /// Todo: Move this to a separate factory somehow.
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private IRequiredFolder BuildRequiredFolderObject(string tagName, string defaultValue, string friendlyName, string description)
        {
            return new RequiredFolder(tagName, friendlyName, description, defaultValue);
        }

        
    }
}
