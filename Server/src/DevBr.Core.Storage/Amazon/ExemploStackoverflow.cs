namespace DevBr.Core.Storage.Amazon
{
    internal class ExemploStackoverflow
    {
    }

    public class AmazonS3Uploader
    {

        private string bucketName = "cartalkio-image-storage-dev";
        private string keyName = DateTime.Now.ToString() + ".png";


        public async void UploadFile()
        {
            /*
            byte[] bytes = System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==");

            Stream stream = new MemoryStream(bytes);

            var myAwsAccesskey = "*************";
            var myAwsSecret = "**************************";

            var client = new AmazonS3Client(myAwsAccesskey, myAwsSecret, Amazon.RegionEndpoint.EUWest2);

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    ContentType = "image/png",
                    InputStream = stream
                };

                PutObjectResponse response = await client.PutObjectAsync(putRequest);

                // Console.Write(response);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
            */
        }
    }
}