using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aeneas.DataController.LiteDB
{
    public static class Database
    {
        public static void Initialize(string databasePath)
        {
            if(_initialized)
            {
                throw new Exception("already intialized");
            }
            MainDatabase = new LiteDatabase(databasePath);
            ProductDataCollection = MainDatabase.GetCollection<ProductData>();
        }
        private static bool _initialized = false;
        internal static LiteDatabase MainDatabase;
        internal static LiteCollection<ProductData> ProductDataCollection;
    }
}
