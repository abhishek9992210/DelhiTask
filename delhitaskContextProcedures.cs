﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DelhiTask.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DelhiTask
{
    public partial class delhitaskContext
    {
        private IdelhitaskContextProcedures _procedures;

        public virtual IdelhitaskContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new delhitaskContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IdelhitaskContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchProductsResult>().HasNoKey().ToView(null);
        }
    }

    public partial class delhitaskContextProcedures : IdelhitaskContextProcedures
    {
        private readonly delhitaskContext _context;

        public delhitaskContextProcedures(delhitaskContext context)
        {
            _context = context;
        }

        public virtual async Task<List<SearchProductsResult>> SearchProductsAsync(string ProductName, string Size, decimal? Price, DateTime? MfgDate, string Category, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProductName",
                    Size = 255,
                    Value = ProductName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Size",
                    Size = 3,
                    Value = Size ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                new SqlParameter
                {
                    ParameterName = "Price",
                    Precision = 10,
                    Scale = 2,
                    Value = Price ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "MfgDate",
                    Value = MfgDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "Category",
                    Size = 50,
                    Value = Category ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SearchProductsResult>("EXEC @returnValue = [dbo].[SearchProducts] @ProductName, @Size, @Price, @MfgDate, @Category", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
