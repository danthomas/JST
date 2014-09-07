using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JST.Business.Models
{
    public class ResultListItem
    {
        public int ResultId { get; set; }
        public string DisplayName { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
    }
}
