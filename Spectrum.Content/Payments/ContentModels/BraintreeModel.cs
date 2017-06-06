﻿namespace Spectrum.Content.Payments.ContentModels
{
    using Umbraco.Core.Models;
    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;

    public class BraintreeModel : PublishedContentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Umbraco.Core.Models.PublishedContent.PublishedContentModel" /> class with
        /// an original <see cref="T:Umbraco.Core.Models.IPublishedContent" /> instance.
        /// </summary>
        /// <param name="content">The original content.</param>
        public BraintreeModel(IPublishedContent content) : base(content)
        {
        }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        public string Environment => this.GetPropertyValue<string>("environment");

        /// <summary>
        /// Gets the merchant identifier.
        /// </summary>
        public string MerchantId => this.GetPropertyValue<string>("merchantId");

        /// <summary>
        /// Gets the public key.
        /// </summary>
        public string PublicKey => this.GetPropertyValue<string>("publicKey");

        /// <summary>
        /// Gets the private key.
        /// </summary>
        public string PrivateKey => this.GetPropertyValue<string>("privateKey");
    }
}
