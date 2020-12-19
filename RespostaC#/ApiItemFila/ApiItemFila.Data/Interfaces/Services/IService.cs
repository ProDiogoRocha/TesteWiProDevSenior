using System.Collections.Generic;

namespace ApiItemFila.Data.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        void Adicionar(T entity);
        T GetProxItem();
    }
}
