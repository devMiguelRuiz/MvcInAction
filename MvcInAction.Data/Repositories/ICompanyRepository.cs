using System;
using MvcInAction.Data.Entities;
using System.Collections.Generic;

namespace MvcInAction.Data.Repositories
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetAll();

        Contact Find(params object[] keyValues);

        void Add(Company contact);

        void Edit(Company contact);

        void Delete(Company contact);
    }
}