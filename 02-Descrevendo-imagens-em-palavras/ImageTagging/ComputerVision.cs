//-----------------------------------------------------------------------
// <copyright file="ComputerVision.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Instituto de Pesquisas Eldorado</author>
//-----------------------------------------------------------------------

namespace ImageTagging
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.ProjectOxford.Vision;

    /// <summary>
    /// Class responsible for requests to the cognitive services
    /// </summary>
    public class ComputerVision
    {
        /// <summary>
        /// Method responsible for getting categories of image
        /// </summary>
        /// <param name="fileURL">file URL</param>
        /// <returns>Categories array</returns>
        public async static Task<string[]> GetCategories(string fileURL)
        {
            try
            {
                string subscriptionKey = ConfigurationManager.AppSettings["CognitiveServiceSubscriptionKey"];

                var visionServiceClient = new VisionServiceClient(subscriptionKey);                
                var info = await visionServiceClient.GetTagsAsync(fileURL);

                List<string> tags = new List<string>();

                foreach (var tag in info.Tags)
                {
                    tags.Add(tag.Name);
                }

                return tags.ToArray();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}