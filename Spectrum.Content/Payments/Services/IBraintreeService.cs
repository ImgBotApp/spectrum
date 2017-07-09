﻿namespace Spectrum.Content.Payments.Services
{
    using Braintree;
    using ContentModels;
    using ViewModels;

    public interface IBraintreeService
    {
        /// <summary>
        /// Gets the gateway.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        IBraintreeGateway GetGateway(BraintreeModel model);

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The token.</returns>
        string GetAuthToken(BraintreeModel model);

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns>Payment Id</returns>
        string MakePayment(
            BraintreeModel model,
            PaymentViewModel viewModel);

        /// <summary>
        /// Gets the transactions.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        ResourceCollection<Transaction> GetTransactions(BraintreeModel model);
    }
}
