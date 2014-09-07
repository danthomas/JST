using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JST.DataAccess;

namespace JST.Business
{
    public class ResultBusiness
    {
        private readonly ResultDataService _resultDataService;

        public ResultBusiness(ResultDataService resultDataService)
        {
            _resultDataService = resultDataService;
        }

        public DataSet SelectForMemberHomeByDate(DateTime date)
        {
            return _resultDataService.SelectForMemberHomeByDate(date);
        }
    }
}
