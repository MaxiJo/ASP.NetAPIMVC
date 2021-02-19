using API.Context;
using API.Models;
using API.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class SupplierRepository : ISupplierRepositories
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConection"].ConnectionString);
        public int Create(Supplier supplier)
        {
            var SP_Insert = "SP_InsertSupplier";
            parameters.Add("@Nama",supplier.Nama);
            var Create = connection.Execute(SP_Insert, parameters, commandType:CommandType.StoredProcedure);
            return Create;
        }

        public int Delete( int id)
        {
            var SP_Delete = "SP_DeleteSupplier";
            parameters.Add("@Id", id);
            var Delete = connection.Execute(SP_Delete,parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }
        
        public IEnumerable<Supplier> Get()
        {
            var SP_RetrieveAll = "SP_RetrieveAllSupplier";
            var GetAll = connection.Query<Supplier>(SP_RetrieveAll, commandType: CommandType.StoredProcedure);
            return GetAll;
        }

        public async Task<IEnumerable<Supplier>> Get( int id)
        {
            var SP_RetrieveById = "SP_RetrieveSupplierById";
            parameters.Add("@Id", id);
            var GetById = await connection.QueryAsync<Supplier>(SP_RetrieveById, parameters, commandType: CommandType.StoredProcedure);
            return GetById;
        }

        public int Update(Supplier supplier, int id)
        {
            var SP_UpdateSupplier = "SP_UpdateSupplier";
            parameters.Add("@Id", supplier.id);
            parameters.Add("@Nama", supplier.Nama);
            var Update = connection.Execute(SP_UpdateSupplier, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
    }
}