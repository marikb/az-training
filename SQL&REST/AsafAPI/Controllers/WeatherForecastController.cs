using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

namespace AsafAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List persons = new List();  
        
        using (var connection = new QC.SqlConnection(  
                "Server=tcp:server-asafsqldemo.database.windows.net,1433;Initial Catalog=database-AsafSqlDemo;Persist Security Info=False;User ID=asaf;Password=bogdanbogdan1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"  
                ))  
            {  
                connection.Open();  
                Console.WriteLine("Connected successfully.");  

                Console.WriteLine("Press any key to finish...");  
                Console.ReadKey(true);  
            }

        using (SqlCommand cmd = new SqlCommand("SELECT BusinessEntityID AS ID, FirstName, MiddleName, LastName FROM Person.Person", connection))
{
    connection.Open();
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        // Check is the reader has any rows at all before starting to read.
        if (reader.HasRows)
        {
            // Read advances to the next row.
            while (reader.Read())
            {
                Person p = new Person();
                // To avoid unexpected bugs access columns by name.
                p.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                int middleNameIndex = reader.GetOrdinal("MiddleName");
                // If a column is nullable always check for DBNull...
                if (!reader.IsDBNull(middleNameIndex))
                {
                    p.MiddleName = reader.GetString(middleNameIndex);
                }
                p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                persons.Add(p);
            }
        }
    }
}
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        
        public IEnumerable<WeatherForecast> GetAllPeople()
        {
            return people;
        }
        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            
        }
    }
}
