﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using EntityUniProjectTrain.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace EntityUniProjectTrain.Droid
{
    // Реалізація IPath для отримання шляху до БД
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
        }
    }
}