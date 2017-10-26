using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MvcInAction.Data.Entities;

namespace MvcInAction.Data.Repositories
{
    public class DbCompanyRepository : ICompanyRepository
    {
        private readonly RepositoryContext _db;

        public DbCompanyRepository()
        {
            _db = new RepositoryContext();
        }

        public IEnumerable<Company> GetAll()
        {
            return _db.Set<Company>().ToList();
        }

        public Company Find(params object[] keyValues)
        {
            return _db.Companies.Find(keyValues);
        }

        public void Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
        }

        public void Edit(Company company)
        {
            _db.Entry(company).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Company company)
        {
            _db.Companies.Remove(company);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}