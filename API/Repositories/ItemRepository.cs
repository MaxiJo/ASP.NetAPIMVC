using API.Models;
using API.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class ItemRepository : IItemRepositories
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConection"].ConnectionString);
        public int Create(Item item)
        {
            var SP_Insert = "SP_InsertItem";
            parameters.Add("@Nama", item.nama);
            parameters.Add("@quantity", item.quantity);
            parameters.Add("@price", item.price);
            parameters.Add("@supplierId", item.supplierId);
            var Create = connection.Execute(SP_Insert, parameters, commandType: CommandType.StoredProcedure);
            return Create;
        }

        public int Delete( int id)
        {
            var SP_Delete = "SP_DeleteItem";
            parameters.Add("@Id",id);
            var Delete = connection.Execute(SP_Delete, parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }

        public IEnumerable<SupplierItem> Get()
        {
            var SP_RetrieveAll = "SP_RetrieveAllItem";
            var GetAll = connection.Query<SupplierItem>(SP_RetrieveAll, commandType: CommandType.StoredProcedure);
            return GetAll;
        }

        public async Task<IEnumerable<SupplierItem>> Get(int id)
        {
            var SP_RetrieveById = "SP_RetrieveItemById";
            parameters.Add("@Id", id);
            var GetById = await connection.QueryAsync<SupplierItem>(SP_RetrieveById, parameters, commandType: CommandType.StoredProcedure);
            return GetById;
        }

        public int Update(Item item, int id)
        {
            var SP_UpdateSupplier = "SP_UpdateItem";
            parameters.Add("@Id", item.id);
            parameters.Add("@Nama", item.nama);
            parameters.Add("@quantity", item.quantity);
            parameters.Add("@price", item.price);
            parameters.Add("@supplierId", item.supplierId);
            var Update = connection.Execute(SP_UpdateSupplier, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
    }
}