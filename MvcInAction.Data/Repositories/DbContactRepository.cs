using MvcInAction.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcInAction.Data.Repositories
{
    public class DbContactRepository: IContactRepository
    {
        private readonly RepositoryContext _db;

        public DbContactRepository()
        {
            _db = new RepositoryContext();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _db.Set<Contact>();
        }

        public Contact Find(params object[] keyValues)
        {
            return _db.Contacts.Find(keyValues);
        }

        public void Add(Contact contact)
        {
           _db.Contacts.Add(contact);
            _db.SaveChanges();
        }

        public void Edit(Contact contact)
        {
            _db.Entry(contact).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            _db.Contacts.Remove(contact);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}