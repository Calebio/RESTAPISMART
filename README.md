# RESTAPISMART Setting up the RestApi
The purpose of this project is the connect a REST API to an aws elasticsearch domain mainly to retrieve data through search.


1. Create the appsettings.json files and include the evironment variables as follows
```
"AWS": {
  "AccessKey": "Insert AWS Access Key",
  "SecretKey": "Insert AWS Secret Key",
  "Region": "us-east-1",
  "ElasticUrl": "https://search-smart-apartment-data-test-shhsba3ijh7273p2dkt5hre5e4.us-east-1.es.amazonaws.com/"
  }
  ```
 2. In the visual studio package manager run the following commands to install the needed dependencies.
   ```
   Install-Package Elasticsearch.Net
   Install-Package Elasticsearch.Net.Aws
   Install-Package NEST
   Newtonsoft.json
   ```
 3. The ConsoleUpload consoleApp was intended to push the data to elasticsearch domain and the following dependencies will be needed.
  ```
  Install-Package Elasticsearch.Net
   Install-Package Elasticsearch.Net.Aws
   Install-Package NEST
   Newtonsoft.json
   Microsoft.Extensions.Configuration
   MSTest.TestAdapter
   MSTest.TestFramework
   ```
