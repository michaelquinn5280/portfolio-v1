using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using MongoDB.Bson.Serialization;

namespace Portfolio.Domain.DataContext
{
    /// <summary>
    /// http://www.primaryobjects.com/CMS/Article137
    /// </summary>
    public class MongoContext : IDataContext
    {
        protected MongoDatabase Database;

        public MongoContext()
            : this (ConfigurationManager.ConnectionStrings["MongoServer"].ToString(), ConfigurationManager.AppSettings["DbName"])
        { }

        public MongoContext(string connectionString, string dbName)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            var client = new MongoClient(settings);
            var server = client.GetServer();
            Database = server.GetDatabase(dbName);

            try
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(ProfileReference)))
                    BsonClassMap.RegisterClassMap<ProfileReference>(cm => cm.AutoMap());
                var profileReferenceCollection = Database.GetCollection<ProfileReference>(typeof(ProfileReference).Name);
                var profileReferenceIndexName = @"ReferenceValue_1";
                if (!profileReferenceCollection.IndexExistsByName(profileReferenceIndexName))
                    profileReferenceCollection.CreateIndex(new IndexKeysBuilder().Ascending("ReferenceValue"), IndexOptions.SetUnique(true).SetName(profileReferenceIndexName));

                if (!BsonClassMap.IsClassMapRegistered(typeof(Profile)))
                    BsonClassMap.RegisterClassMap<Profile>(cm => cm.AutoMap());
                var profileCollection = Database.GetCollection<Profile>(typeof(Profile).Name);
                var profileIndexName = @"ProfileId_1";
                if (!profileCollection.IndexExistsByName(profileIndexName))
                    profileCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(true).SetName(profileIndexName));


                if (!BsonClassMap.IsClassMapRegistered(typeof(Greeting)))
                    BsonClassMap.RegisterClassMap<Greeting>(cm => cm.AutoMap());
                var greetingCollection = Database.GetCollection<Greeting>(typeof(Greeting).Name);
                var greetingIndexName = @"ProfileId_1";
                if (!greetingCollection.IndexExistsByName(greetingIndexName))
                    greetingCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(true).SetName(greetingIndexName));

                if (!BsonClassMap.IsClassMapRegistered(typeof(Project)))
                    BsonClassMap.RegisterClassMap<Project>(cm => cm.AutoMap());
                var projectCollection = Database.GetCollection<Project>(typeof(Project).Name);
                var projectIndexName = @"ProfileId_1";
                if (!projectCollection.IndexExistsByName(projectIndexName))
                    projectCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(false).SetName(projectIndexName));

                if (!BsonClassMap.IsClassMapRegistered(typeof(ContactInfo)))
                    BsonClassMap.RegisterClassMap<ContactInfo>(cm => cm.AutoMap());
                var contactInfoCollection = Database.GetCollection<ContactInfo>(typeof(ContactInfo).Name);
                var contactInfoIndexName = @"ProfileId_1";
                if (!contactInfoCollection.IndexExistsByName(contactInfoIndexName))
                    contactInfoCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(true).SetName("contactInfoIndexName"));

                if (!BsonClassMap.IsClassMapRegistered(typeof(ContactAttempt)))
                    BsonClassMap.RegisterClassMap<ContactAttempt>(cm => cm.AutoMap());
                var contactAttemptCollection = Database.GetCollection<ContactAttempt>(typeof(ContactAttempt).Name);
                var contactAttemptIndexName = @"ProfileId_1";
                if (!contactAttemptCollection.IndexExistsByName(contactAttemptIndexName))
                    contactAttemptCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(false).SetName("contactAttemptIndexName"));

                if (!BsonClassMap.IsClassMapRegistered(typeof(SiteInfo)))
                    BsonClassMap.RegisterClassMap<SiteInfo>(cm => cm.AutoMap());
                var siteInfoCollection = Database.GetCollection<SiteInfo>(typeof(SiteInfo).Name);
                var siteInfoIndexName = @"ProfileId_1";
                if (!siteInfoCollection.IndexExistsByName(siteInfoIndexName))
                    siteInfoCollection.CreateIndex(new IndexKeysBuilder().Ascending("ProfileId"), IndexOptions.SetUnique(true).SetName("siteInfoIndexName"));
            }
            catch (Exception ex)
            {
                //todo: why is it throwing An item with the same key has already been added ex
                //swallow for now
            }
        }


        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new()
        {
            return All<T>().Where(expression).SingleOrDefault();
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return Database.GetCollection<T>(typeof(T).Name).AsQueryable();
        }


        public void Save<T>(T item) where T : class, new()
        {
            Database.GetCollection<T>(typeof(T).Name).Save(item);
        }

        public void Save<T>(List<T> items) where T : class, new()
        {
            items.ForEach(item => Save(item));
            //foreach (T item in items)
            //{
            //    Save(item);
            //}
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new()
        {
            Database.GetCollection<T>(typeof(T).Name).Remove(Query<T>.Where(expression));
        }
    }
}
