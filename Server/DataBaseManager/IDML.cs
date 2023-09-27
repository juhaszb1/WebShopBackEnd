using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DataBaseManager
{
    internal interface IDML
    {
        List<Record> Select();
    }
}
