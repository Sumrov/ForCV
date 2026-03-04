using Ardalis.Specification;

namespace EslOnline.Domain.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class;
