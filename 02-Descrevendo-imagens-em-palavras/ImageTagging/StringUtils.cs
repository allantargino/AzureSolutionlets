//-----------------------------------------------------------------------
// <copyright file="StringUtils.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Instituto de Pesquisas Eldorado</author>
//-----------------------------------------------------------------------

namespace ImageTagging
{
    using System.Text;

    internal class StringUtils
    {
        /// <summary>
        /// Method responsible for converting a string array to unique string
        /// </summary>
        /// <param name="array">Array of string</param>
        /// <returns>String with all array items</returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(" ");
            }

            return builder.ToString();
        }
    }
}