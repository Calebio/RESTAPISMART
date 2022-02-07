using Nest;

namespace Elasticsearch.Net
{
    internal class AwsHttpConnection : Aws.AwsHttpConnection
    {
        private ConnectionSettings settings;

        public AwsHttpConnection(ConnectionSettings settings)
        {
            this.settings = settings;
        }
    }
}