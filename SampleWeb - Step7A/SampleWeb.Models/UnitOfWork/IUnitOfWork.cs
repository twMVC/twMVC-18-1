using System;
using System.Data.Entity;

namespace SampleWeb.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        int SaveChange();
    }
}