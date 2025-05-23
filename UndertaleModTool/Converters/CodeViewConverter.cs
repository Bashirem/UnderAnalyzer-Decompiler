﻿using System;
using System.ComponentModel;
using System.Windows.Data;
using UndertaleModLib.Models;

namespace UndertaleModTool
{
    [ValueConversion(typeof(object), typeof(ICollectionView))]
    public class CodeViewConverter : FilteredViewConverter
    {
        protected override Predicate<object> CreateFilter()
        {
            Predicate<object> baseFilter = base.CreateFilter();
            return (obj) =>
            {
                if (obj is UndertaleCode code &&
                    code.ParentEntry is not null &&
                    SettingsWindow.HideChildCodeEntries)
                    return false;
                return baseFilter(obj);
            };
        }
    }
}