﻿namespace Spectrum.Content.ContentModels
{
    using Umbraco.Core.Models;
    using Umbraco.Web;

    public class MenuModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Umbraco.Core.Models.PublishedContent.PublishedContentModel" /> class with
        /// an original <see cref="T:Umbraco.Core.Models.IPublishedContent" /> instance.
        /// </summary>
        /// <param name="content">The original content.</param>
        public MenuModel(IPublishedContent content) : base(content)
        {
        }

        /// <summary>
        /// Gets the link.
        /// </summary>
        public string LandingPage => GetNiceUrl(this.GetPropertyValue<int>("landingPage"));
    }
}