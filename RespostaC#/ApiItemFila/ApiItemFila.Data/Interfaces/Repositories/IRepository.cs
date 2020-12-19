using System.Collections.Generic;

namespace ApiItemFila.Data.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entity);

        T GetProxItem();

        void DeletarItem(int Id);
    }
}
