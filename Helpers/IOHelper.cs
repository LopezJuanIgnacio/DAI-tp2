using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Dapper;
using TP1.Utils;
using TP1.Models;
using TP1.Helpers;
using TP1.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TP1.Helpers{
    public static class IOHelper{
        public static async Task AppendInFile(string fullFileName, string data){
            await File.WriteAllTextAsync(fullFileName, data);
        }
    }
}