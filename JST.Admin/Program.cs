using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JST.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            new TransferBackupFile(new SendEmail()).Execute();
        }
    }
}
