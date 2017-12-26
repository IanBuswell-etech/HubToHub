using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using System.Linq.Expressions;

namespace MiniHub.Data.LiteDb
{
    public class DatabaseContext : IDisposable
    {
        private const string DBName = @"localDB.db";

        private readonly LiteDatabase db;

        public DatabaseContext()
        {
            db = new LiteDatabase(DBName);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool PushSomethingIntoDb<T>(T thingie)
        {
            var collectionName = GetCollectionName<T>();
            var collection = db.GetCollection<T>(collectionName);

            var result = collection.Insert(thingie);
            
            return true;
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = GetCollection<T>();

            var items = collection.Find(predicate);

            return items;
        }

        public IEnumerable<T> GetList<T>()
        {
            var collection = GetCollection<T>();

            var outCollection = collection.FindAll();

            return outCollection;
        }

        public void DeleteFromDb<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = GetCollection<T>();

            collection.Delete(predicate);
        }

        public bool UdpdateSomethingInDb<T>(T thingie)
        {
            var collectionName = GetCollectionName<T>();
            var collection = db.GetCollection<T>(collectionName);

            var result = collection.Update(thingie);

            return result;
        }

        private string GetCollectionName<T>()
        {
            return typeof(T).Name;
        }

        private LiteCollection<T> GetCollection<T>()
        {
            LiteCollection<T> foundCollection = null;

            var collectionName = GetCollectionName<T>();

            foundCollection = db.GetCollection<T>(collectionName);

            return foundCollection;
        }
    }
}
