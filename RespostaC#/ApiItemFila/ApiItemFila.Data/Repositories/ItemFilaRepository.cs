using ApiItemFila.Data.Interfaces.Repositories;
using ApiItemFila.Domain.Entity;
using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ApiItemFila.Data.Repositories
{
    public class ItemFilaRepository : IRepository<Item>
    {
        private SqlConnection _conexaoBD;

        private string strConnection = ConfigurationManager.ConnectionStrings["WiProItemFila"].ConnectionString;
        public ItemFilaRepository()
        {
            _conexaoBD = new SqlConnection(strConnection);
        }

        public void Adicionar(Item entity)
        {
            try
            {
                _conexaoBD.Open();
                _conexaoBD.Query($@"INSERT INTO Fila (moeda, data_inicio, data_fim) 
                                    VALUES('{entity.moeda}', CONVERT(datetime, '{entity.data_inicio.ToString("yyyy-MM-dd h:mm tt")}'), CONVERT(datetime, '{entity.data_fim.ToString("yyyy-MM-dd h:mm tt")}'))");
                _conexaoBD.Close();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public void DeletarItem(int Id)
        {
            try
            {
                _conexaoBD.Query<Item>($@"DELETE Fila WHERE Id = {Id}");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Item GetProxItem()
        {
            Item item = null;
            try
            {
                _conexaoBD.Open();

                item = _conexaoBD.Query<Item>($@"SELECT TOP 1 * FROM Fila ORDER BY Id ASC").FirstOrDefault();

                if(item != null)
                {
                    DeletarItem(item.Id);
                }

                _conexaoBD.Close();

                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
