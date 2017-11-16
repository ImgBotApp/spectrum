﻿namespace Spectrum.Content.Payments.Factories
{
    using Umbraco.Web;

    public interface IPaymentProviderFactory
    {
        /// <summary>
        /// Gets the transactions partial view.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        string GetTransactionsPartialView(UmbracoContext umbracoContext);

        /// <summary>
        /// Gets the transaction partial view.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        string GetTransactionPartialView(UmbracoContext umbracoContext);

        /// <summary>
        /// Gets the payment partial view.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        string GetPaymentPartialView(UmbracoContext umbracoContext);
    }
}