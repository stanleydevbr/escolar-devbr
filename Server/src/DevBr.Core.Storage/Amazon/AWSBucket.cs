using Amazon.S3;

namespace DevBr.Core.Storage.Amazon
{
    public class AWSBucket
    {
        public readonly IAmazonS3 client;
        public readonly AWSCredentials crededentials;
    }
}
