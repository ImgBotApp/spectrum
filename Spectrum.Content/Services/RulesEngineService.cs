﻿namespace Spectrum.Content.Services
{
    using ContentModels;
    using Umbraco.Core.Models;
    using Umbraco.Web;

    public class RulesEngineService : IRulesEngineService
    {
        private readonly ISettingsService settingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineService"/> class.
        /// </summary>
        /// <param name="settingsService">The settings service.</param>
        public RulesEngineService(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer appointments enabled].
        /// </summary>
        public bool IsCustomerAppointmentsEnabled(UmbracoContext umbracoContext)
        {
            AppointmentSettingsModel model = GetAppointmentSettingsModel(umbracoContext);

            return model != null && model.AppointmentsEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer payments enabled].
        /// </summary>
        public bool IsCustomerPaymentsEnabled(UmbracoContext umbracoContext)
        {
            PaymentSettingsModel model = GetPaymentsSettingsModel(umbracoContext);

            return model != null && model.PaymentsEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer dashboard enabled].
        /// </summary>
        public bool IsCustomerDashboardEnabled(UmbracoContext umbracoContext)
        {
            return IsCustomerQuotesEnabled(umbracoContext) ||
                   IsCustomerInvoicesEnabled(umbracoContext) ||
                   IsCustomerAppointmentsEnabled(umbracoContext) ||
                   IsCustomerPaymentsEnabled(umbracoContext);
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer google calendar enabled].
        /// </summary>
        public bool IsCustomerGoogleCalendarEnabled(UmbracoContext umbracoContext)
        {
            AppointmentSettingsModel model = GetAppointmentSettingsModel(umbracoContext);

            return model != null && model.GoogleCalendarEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer quotes enabled] [the specified umbraco context].
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        public bool IsCustomerQuotesEnabled(UmbracoContext umbracoContext)
        {
            QuoteSettingsModel model = GetQuoteSettingsModel(umbracoContext);

            return model != null && model.QuotesEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether [is customer invoices enabled] [the specified umbraco context].
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        public bool IsCustomerInvoicesEnabled(UmbracoContext umbracoContext)
        {
            InvoiceSettingsModel model = GetInvoiceSettingsModel(umbracoContext);

            return model != null && model.InvoicesEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public bool Execute(
            UmbracoContext umbracoContext,
            string query)
        {
            switch (query)
            {
                case Constants.Rules.IsCustomerQuotesEnabled:
                    return IsCustomerQuotesEnabled(umbracoContext);

                case Constants.Rules.IsCustomerInvoicesEnabled:
                    return IsCustomerInvoicesEnabled(umbracoContext);

                case Constants.Rules.IsCustomerAppointmentsEnabled:
                    return IsCustomerAppointmentsEnabled(umbracoContext);

                case Constants.Rules.IsCustomerPaymentsEnabled:
                    return IsCustomerPaymentsEnabled(umbracoContext);

                case Constants.Rules.IsCustomerDashboardEnabled:
                    return IsCustomerDashboardEnabled(umbracoContext);

                case Constants.Rules.IsCustomerGoogleCalendarEnabled:
                    return IsCustomerGoogleCalendarEnabled(umbracoContext);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets the quote settings model.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        internal QuoteSettingsModel GetQuoteSettingsModel(UmbracoContext umbracoContext)
        {
            IPublishedContent quoteNode = settingsService.GetQuotesNode(umbracoContext);

            return quoteNode != null ? new QuoteSettingsModel(quoteNode) : null;
        }

        /// <summary>
        /// Gets the invoice settings model.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        internal InvoiceSettingsModel GetInvoiceSettingsModel(UmbracoContext umbracoContext)
        {
            IPublishedContent invoiceNode = settingsService.GetInvoicesNode(umbracoContext);

            return invoiceNode != null ? new InvoiceSettingsModel(invoiceNode) : null;
        }

        /// <summary>
        /// Gets the appointment settings model.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        internal AppointmentSettingsModel GetAppointmentSettingsModel(UmbracoContext umbracoContext)
        {
            IPublishedContent appointmentsNode = settingsService.GetAppointmentsNode(umbracoContext);

            return appointmentsNode != null ? new AppointmentSettingsModel(appointmentsNode) : null;
        }

        /// <summary>
        /// Gets the payments settings model.
        /// </summary>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <returns></returns>
        internal PaymentSettingsModel GetPaymentsSettingsModel(UmbracoContext umbracoContext)
        {
            IPublishedContent paymentsNode = settingsService.GetPaymentsNode(umbracoContext);

            return paymentsNode != null ? new PaymentSettingsModel(paymentsNode) : null;
        }
    }
}
