using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hard_Skool
{
    using CsvHelper;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    namespace ProyectoNET.DataWrappers
    {
        

        public class CSVWrapper : IDataWrapper
        {
            private readonly string _csvFilePath;
            private readonly GlobalRepository _globalRepository;

            public CSVWrapper(string csvFilePath, GlobalRepository globalRepository)
            {
                _csvFilePath = csvFilePath;
                _globalRepository = globalRepository;
            }

            public async Task IngestDataAsync()
            {
                var records = ReadCSVFile();
                var jsonObjects = ConvertToJSON(records);
                await InsertIntoGlobalDatabase(jsonObjects);
            }

            private IEnumerable<dynamic> ReadCSVFile()
            {
                using var reader = new StreamReader(_csvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                // Assuming 'dynamic' for flexibility, but you should use a specific class that represents your CSV structure
                var records = csv.GetRecords<dynamic>().ToList();
                return records;
            }

            private IEnumerable<string> ConvertToJSON(IEnumerable<dynamic> records)
            {
                return records.Select(record => JsonConvert.SerializeObject(record));
            }

            private async Task InsertIntoGlobalDatabase(IEnumerable<string> jsonObjects)
            {
                foreach (var jsonObject in jsonObjects)
                {
                    // Convert JSON string to GlobalModel (assuming you have such a class to represent the global schema)
                    var globalModel = JsonConvert.DeserializeObject<GlobalModel>(jsonObject);
                    // Insert or update the globalModel in your global repository
                    await _globalRepository.InsertOrUpdateAsync(globalModel);
                }
            }
        }
    }


