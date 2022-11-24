using Core.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext _dataContext;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// If data context remain null then initialize new context 
        /// </summary>
        /// <returns>dataContext</returns>
        public IDatabaseContext Context()
        {
            return _dataContext ?? (_dataContext = new DatabaseContext(_configuration));
        }

        public DatabaseContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Dispose existing context
        /// </summary>
        public void Dispose()
        {
            //TODO Verify this object behavior
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }

}
