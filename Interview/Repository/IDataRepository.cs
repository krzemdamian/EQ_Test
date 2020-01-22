using System;
using Interview.Models;

namespace Interview.Repository
{
    public interface IDataRepository
    {
        DataModel Get(Guid id);
        void Update(DataModel model);
        void Delete(Guid id);
        void Add(DataModel model);
    }
}
