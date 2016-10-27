using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure;

namespace CreateClusterARM_Console
{
    //public class DataFactory
    //{
    //    string subscriptionId = "e4337d44-53e5-48eb-b1ba-6652656b470e";

    //    TokenCloudCredentials aadTokenCredentials = new TokenCloudCredentials(subscriptionId, GetAuthorizationHeader());

    //    Uri resourceManagerUri = new Uri("");

    //    DataFactoryManagementClient client = new DataFactoryManagementClient(aadTokenCredentials, resourceManagerUri);
    //}

    //public  string GetAuthorizationHeader()
    //{
    //    AuthenticationResult result = null;
    //    var thread = new Thread(() =>
    //    {
    //        try
    //        {
    //            var context = new AuthenticationContext(ConfigurationManager.AppSettings["ActiveDirectoryEndpoint"] + ConfigurationManager.AppSettings["ActiveDirectoryTenantId"]);

    //            result = context.AcquireToken(
    //                resource: ConfigurationManager.AppSettings["WindowsManagementUri"],
    //                clientId: ConfigurationManager.AppSettings["AdfClientId"],
    //                redirectUri: new Uri(ConfigurationManager.AppSettings["RedirectUri"]),
    //                promptBehavior: PromptBehavior.Always);
    //        }
    //        catch (Exception threadEx)
    //        {
    //            Console.WriteLine(threadEx.Message);
    //        }
    //    });

    //    thread.SetApartmentState(ApartmentState.STA);
    //    thread.Name = "AcquireTokenThread";
    //    thread.Start();
    //    thread.Join();

    //    if (result != null)
    //    {
    //        return result.AccessToken;
    //    }

    //    throw new InvalidOperationException("Failed to acquire token");
    //}

    //public static void DataFactoryClient()
    //{
    //    string groupName = "ExampleResourceGroup";
    //    string storageName = "clustercreatetemplate";
    //    string location = "East US";
    //    string subscriptionId = "e4337d44-53e5-48eb-b1ba-6652656b470e";
    //    string deploymentName = "createlinuxclustertestdhee";

    //    var token = GetAccessTokenAsync();
    //    var credential = new TokenCredentials(token.Result.AccessToken);


    //    TokenCloudCredentials aadTokenCredentials = new TokenCloudCredentials(subscriptionId, token.Result.AccessToken);
    //    DataFactoryManagementClient client = new DataFactoryManagementClient();


    //    //Creating LinkedService Resource to for onDemand HDinsight cluster

    //    Console.WriteLine("Creating a linked service");



    //    //var linkedServiceParams = new LinkedServiceCreateOrUpdateParameters()
    //    //{
    //    //    LinkedService = new LinkedService()
    //    //    {
    //    //        Name = "",

    //    //        Properties = new LinkedServiceProperties(new AzureStorageLinkedService());





    //    //};
    //    //client.LinkedServices.CreateOrUpdate("", "", linkedServiceParams);



    //    // Creatign the Activity Pipe
    //    var pipeParams = new PipelineCreateOrUpdateParameters()
    //    {
    //        Pipeline = new Pipeline()
    //        {
    //            Name = "Pipeline Name",

    //            Properties = new PipelineProperties()
    //            {

    //                Activities = new List<Activity>()
    //                {
    //                    new Activity()
    //                    {
    //                        Name="",
    //                        TypeProperties= new HDInsightPigActivity()
    //                        {


    //                        }
    //                    }
    //                }
    //            }


    //        }

    //    };


    //    client.Pipelines.CreateOrUpdate("", "", pipeParams);



    //}
}
