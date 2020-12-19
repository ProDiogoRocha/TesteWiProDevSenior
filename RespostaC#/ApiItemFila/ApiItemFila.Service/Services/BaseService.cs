using ApiItemFila.Data.Interfaces.Repositories;
using ApiItemFila.Data.Interfaces.Services;
using System.Collections.Generic;

namespace ApiItemFila.Service.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        private IRepository<T> _repositorio;
        public BaseService(IRepository<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(T entity)
        {
            _repositorio.Adicionar(entity);
        }

        public T GetProxItem()
        {
            return _repositorio.GetProxItem();
        }
    }
}
