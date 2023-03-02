using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using GraphQLPractice.Data;

namespace GraphQLPractice.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
