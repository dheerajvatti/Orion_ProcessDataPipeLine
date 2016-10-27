using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CreateClusterARM_Console
{
    public class Program
    {
        public static object CloudConfigurationManager { get; private set; }

        static void Main(string[] args)
        {

            string groupName = "ExampleResourceGroup";
            string storageName = "clustercreatetemplate";
            string location = "East US";
            string subscriptionId = "e4337d44-53e5-48eb-b1ba-6652656b470e";
            string deploymentName = "createlinuxclustertestdhee";


            GetLogsStorageContainer();
            //SubmitPigJob();
            //var token = GetAccessTokenAsync();
            // var credential = new TokenCredentials(token.Result.AccessToken);


            //TokenCloudCredentials aadTokenCredentials = new TokenCloudCredentials(subscriptionId, token.Result.AccessToken);
            //DataFactoryManagementClient client = new DataFactoryManagementClient()


            //var rgResult = CreateResourceGroupAsync(credential, groupName, subscriptionId, location);
            //Console.WriteLine(rgResult.Result.Properties.ProvisioningState);
            ////Console.ReadLine();

            //var dpResult = CreateTemplateDeploymentAsync(credential, groupName, storageName, deploymentName, subscriptionId);
            //Console.WriteLine(dpResult.Result.Properties.ProvisioningState);
            //Console.ReadLine();


            // DeleteResourceGroupAsync(credential, groupName, subscriptionId);
            // Console.ReadLine();

            //var dpResult = DeleteResourceGroupAsync(credential, groupName, storageName, deploymentName, subscriptionId);
            //Console.WriteLine(dpResult.Result.Properties.ProvisioningState);
            //Console.ReadLine();


        }



        private static async Task<AuthenticationResult> GetAccessTokenAsync()
        {
            var cc = new ClientCredential("055c54b8-5b6f-4bc9-8a59-028d3f70f9b6", "PErJ/G/wvg+UGBUR6W8zQgkq1taS1mGRmVViM5oSXhg=");
            var context = new AuthenticationContext("https://login.windows.net/15b79de4-baff-453e-8df8-6865beac9b8c");
            var token = await context.AcquireTokenAsync("https://management.azure.com/", cc);
            if (token == null)
            {
                throw new InvalidOperationException("Could not get the token.");
            }
            return token;
        }

        public static void GetLogsStorageContainer()
        {
            var storageConnstring = "DefaultEndpointsProtocol=https;AccountName=clustercreatetemplate;AccountKey=Doo5F7Bw9gPdFDAdJtq9UMeuh9VZ+3C4TPEK8I2ZwR9Dud3fw6jJkoLMhWF26+2l5gb8iTxc4K+Fr0YSFPNK2w==";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnstring);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            var containername = "fromelk";
            CloudBlobContainer container = blobClient.GetContainerReference(containername);
            
            foreach(IListBlobItem blob in container.ListBlobs())
            {
               // Logic 1 ! TODO:: the logic to spinning up a cluster and submit the pig job.
            }

            //getting the count of blobs in the Azure container
            var count = container.ListBlobs().Count();

            if(count > 1)
            {
                // Logic 2 //TODO:: the logic to spinning up a cluster and submit the pig job.
            }




        }


        public static async Task<ResourceGroup> CreateResourceGroupAsync(TokenCredentials credential, string groupName, string subscriptionId, string location)
        {
            Console.WriteLine("Creating the resource group...");
            var resourceManagementClient = new ResourceManagementClient(credential)
            { SubscriptionId = subscriptionId };
            var resourceGroup = new ResourceGroup { Location = location };
            return await resourceManagementClient.ResourceGroups.CreateOrUpdateAsync(groupName, resourceGroup);
        }

        public static async void DeleteResourceGroupAsync(TokenCredentials credential, string groupName, string subscriptionId)
        {
            Console.WriteLine("Deleting resource group...");
            var resourceManagementClient = new ResourceManagementClient(credential)
            { SubscriptionId = subscriptionId };
            await resourceManagementClient.ResourceGroups.DeleteAsync(groupName);
        }

        public static async Task<DeploymentExtended> CreateTemplateDeploymentAsync(TokenCredentials credential, string groupName, string storageName,
                                                    string deploymentName, string subscriptionId)
        {
            Console.WriteLine("Creating the template deployment...");
            var deployment = new Deployment();
            deployment.Properties = new DeploymentProperties
            {
                Mode = DeploymentMode.Incremental,
                TemplateLink = new TemplateLink
                {

                    //https://clustercreatetemplate.blob.core.windows.net/resourcetemplate/template.json
                    Uri = "https://" + storageName + ".blob.core.windows.net/resourcetemplate/template.json"

                },
                ParametersLink = new ParametersLink
                {
                    //https://clustercreatetemplate.blob.core.windows.net/resourcetemplate/parameters.json
                    Uri = "https://" + storageName + ".blob.core.windows.net/resourcetemplate/parameters.json"
                    //".blob.core.windows.net/templates/Parameters.json"
                }
            };
            var resourceManagementClient = new ResourceManagementClient(credential)
            { SubscriptionId = subscriptionId };
            return await resourceManagementClient.Deployments.CreateOrUpdateAsync(groupName, deploymentName, deployment);
        }       


        public static void SubmitPigJob()
        {

                  const string ExistingClusterName = "sparkdheetest";
                  const string ExistingClusterUri = ExistingClusterName + ".azurehdinsight.net";
                  const string ExistingClusterUsername = "admin";
                  const string ExistingClusterPassword = "Welcome123456!";

        var clusterCredentials = new BasicAuthenticationCloudCredentials { Username = ExistingClusterUsername, Password = ExistingClusterPassword };
        HDInsightJobManagementClient _hdiJobManagementClient = new HDInsightJobManagementClient(ExistingClusterUri, clusterCredentials);

            ////SubmitPigJob();


            var parameters = new PigJobSubmissionParameters
            {
                //A = LOAD 'wasb://clustercreatetemplate.blob.core.windows.net/clustercreatetemplate/information.txt' using PigStorage (‘\t’) as (FName: chararray, LName: chararray, MobileNo: chararray, City: chararray, Profession: chararray);
                // B = FOREACH A generate FName,MobileNo,Profession;
                //DUMP B;
                //wasb://clustercreatetemplate.blob.core.windows.net/clustercreatetemplate/sample.pig
                //Query = @"PigSampleIn = LOAD 'wasb://clustercreatetemplate.blob.core.windows.net/clustercreatetemplate/input.txt' USIG PigStorage(',') AS (ProfileID:chararray, SessionStart:chararray, Duration:int, SrcIPAddress:chararray, GameType:chararray);
                //        GroupProfile = Group PigSampleIn all;
                //        PigSampleOut = Foreach GroupProfile Generate PigSampleIn.ProfileID, SUM(PigSampleIn.Duration);
                //        Store PigSampleOut into 'wasb://clustercreatetemplate.blob.core.windows.net/clustercreatetemplate/output.txt' USING PigStorage (',');"
               // File = 
            };

            Console.WriteLine("Submitting the Pig job to the cluster...");
            var response = _hdiJobManagementClient.JobManagement.SubmitPigJob(parameters);
            Console.WriteLine("Validating that the response is as expected...");
            Console.WriteLine("Response status code is " + response.StatusCode);
            Console.WriteLine("Validating the response object...");
            Console.WriteLine("JobId is " + response.JobSubmissionJsonResponse.Id);

            var jobs = _hdiJobManagementClient.JobManagement.ListJobs();
            foreach(var job in jobs)
            {
                //var deails = _hdiJobManagementClient.JobManagement.GetJobOutput(job.Id)
            }

            Console.WriteLine("Press ENTER to continue ...");
            Console.ReadLine();

        }
}


}




    



