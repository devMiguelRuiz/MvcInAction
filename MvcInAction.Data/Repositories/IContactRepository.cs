using System;
using MvcInAction.Data.Entities;
using System.Collections.Generic;

namespace MvcInAction.Data.Repositories
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetAll();

        Contact Find(int id);

        void Add(Contact contact);

        void Edit(Contact contact);

        void Delete(Contact contact);
    }
}