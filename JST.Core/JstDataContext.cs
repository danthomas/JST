using System.Data.SqlClient;

namespace JST.Core
{
    public class JstDataContext: DataContext
    {
        public JstDataContext()
            : base("Jst")
        {
        }
    }
}