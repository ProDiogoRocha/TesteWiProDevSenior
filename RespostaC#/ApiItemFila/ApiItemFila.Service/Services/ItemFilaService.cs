using ApiItemFila.Data.Interfaces.Repositories;
using ApiItemFila.Data.Interfaces.Services;
using ApiItemFila.Domain.Entity;
using System.Collections.Generic;

namespace ApiItemFila.Service.Services
{
    public class ItemFilaService : BaseService<Item>, IService<Item>
    {
        public ItemFilaService(IRepository<Item> repositorio) : base(repositorio)
        {
        }
    }
}
