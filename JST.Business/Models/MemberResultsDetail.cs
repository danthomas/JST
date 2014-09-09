using System;
using System.Collections.Generic;
using System.Linq;

namespace JST.Business.Models
{
    public class MemberResultsDetail
    {
        public MemberResultsDetail(DateTime date, IEnumerable<Result> results)
        {
            Date = date;
            Results = results.ToList();
        }

        public List<Result> Results { get; set; }

        public DateTime Date { get; set; }

        public class Result
        {
            public Result(int resultId, bool isCurrentAccount, string accountDisplayName, string resultDetail)
            {
                ResultId = resultId;
                IsCurrentAccount = isCurrentAccount;
                AccountDisplayName = accountDisplayName;
                ResultDetail = resultDetail;
            }

            public int ResultId { get; set; }
            public bool IsCurrentAccount { get; set; }
            public string AccountDisplayName { get; set; }
            public string ResultDetail { get; set; }
        }
    }
}
