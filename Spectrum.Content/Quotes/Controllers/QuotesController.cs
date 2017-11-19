﻿namespace Spectrum.Content.Quotes.Controllers
{
    using Services;
    using System.Web.Mvc;
    using Umbraco.Web;

    public class QuotesController : BaseController
    {
        /// <summary>
        /// The rules engine service.
        /// </summary>
        private readonly IRulesEngineService rulesEngineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Spectrum.Content.BaseController" /> class.
        /// </summary>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="rulesEngineService">The rules engine service.</param>
        /// <inheritdoc />
        public QuotesController(
            ILoggingService loggingService,
            IRulesEngineService rulesEngineService) 
            : base(loggingService)
        {
            this.rulesEngineService = rulesEngineService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Spectrum.Content.BaseController" /> class.
        /// </summary>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <param name="rulesEngineService">The rules engine service.</param>
        /// <inheritdoc />
        public QuotesController(
            ILoggingService loggingService, 
            UmbracoContext umbracoContext,
            IRulesEngineService rulesEngineService) 
            : base(loggingService, umbracoContext)
        {
            this.rulesEngineService = rulesEngineService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Spectrum.Content.BaseController" /> class.
        /// </summary>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="umbracoContext">The umbraco context.</param>
        /// <param name="umbracoHelper">The umbraco helper.</param>
        /// <param name="rulesEngineService">The rules engine service.</param>
        /// <inheritdoc />
        public QuotesController(
            ILoggingService loggingService, 
            UmbracoContext umbracoContext, 
            UmbracoHelper umbracoHelper,
            IRulesEngineService rulesEngineService) 
            : base(loggingService, umbracoContext, umbracoHelper)
        {
            this.rulesEngineService = rulesEngineService;
        }

        /// <summary>
        /// Gets the quotes.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult GetQuotes()
        {
            LoggingService.Info(GetType());

            if (rulesEngineService.IsCustomerQuotesEnabled(UmbracoContext))
            {
                return PartialView("Partials/Spectrum/Quotes/Quotes");
            }

            return default(PartialViewResult);
        }

        /// <summary>
        /// Create a Quote.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult CreateQuote()
        {
            LoggingService.Info(GetType());

            if (rulesEngineService.IsCustomerQuotesEnabled(UmbracoContext))
            {
                return PartialView("Partials/Spectrum/Quotes/CreateQuote");
            }

            return default(PartialViewResult);
        }
    }
}
