using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Foundation;
using UIKit;

using EntityUniProjectTrain.iOS;
using Xamarin.Forms;


[assembly: Dependency(typeof(IosDbPath))]
namespace EntityUniProjectTrain.iOS
{
    // Реалізація IPath для отримання шляху до БД
    public class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqltFilename)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Library", sqltFilename);
        }
    }
}