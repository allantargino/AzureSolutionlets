using System;

namespace ImageTagging
{
    /// <summary>
    /// Item class
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// Gets or sets image URL
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets image tag words
        /// </summary>
        public string Words { get; set; }
    }
}