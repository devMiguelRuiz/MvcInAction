using System;
using MvcInAction.Data.Entities;
using System.Collections.Generic;

namespace MvcInAction.Data.Repositories
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetAll();

        Company Find(int id);

        void Add(Company company);

        void Edit(Company company);

        void Delete(Company company);
    }
}