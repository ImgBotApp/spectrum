﻿namespace Spectrum.Content.Appointments.Managers
{
    using Application.Services;
    using Content.Services;
    using ContentModels;
    using Customer.Providers;
    using Messages;
    using Models;
    using Providers;
    using System;
    
    public class PaymentMadeManager : IPaymentMadeManager
    {
        /// <summary>
        /// The logging service.
        /// </summary>
        private readonly ILoggingService loggingService;

        /// <summary>
        /// The customer provider.
        /// </summary>
        private readonly ICustomerProvider customerProvider;

        /// <summary>
        /// The database provider.
        /// </summary>
        private readonly IDatabaseProvider databaseProvider;

        /// <summary>
        /// The encryption service.
        /// </summary>
        private readonly IEncryptionService encryptionService;

        /// <summary>
        /// The cookie service.
        /// </summary>
        private readonly ICookieService cookieService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMadeManager" /> class.
        /// </summary>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="customerProvider">The customer provider.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="encryptionService">The encryption service.</param>
        /// <param name="cookieService">The cookie service.</param>
        public PaymentMadeManager(
            ILoggingService loggingService,
            ICustomerProvider customerProvider,
            IDatabaseProvider databaseProvider,
            IEncryptionService encryptionService,
            ICookieService cookieService)
        {
            this.loggingService = loggingService;
            this.customerProvider = customerProvider;
            this.databaseProvider = databaseProvider;
            this.encryptionService = encryptionService;
            this.cookieService = cookieService;
        }

        /// <inheritdoc />
        /// <summary>
        /// Handles the specified payment made message.
        /// </summary>
        /// <param name="paymentMadeMessage">The payment made message.</param>
        public void Handle(TransactionMadeMessage paymentMadeMessage)
        {
            string paymentId = paymentMadeMessage.Transaction.Id;
            string autoAllocate = paymentMadeMessage.PaymentViewModel.AutoAllocate;
            string appointmentId = paymentMadeMessage.PaymentViewModel.AppointmentId;

            string message = "PaymentMadeMessage " +
                             "PaymentId=" + paymentId + " " +
                             "AutoAllocate=" + autoAllocate + " " +
                             "AppointmentId=" + appointmentId;

            loggingService.Info(GetType(), message);

            int? id = GetAppointmentId(autoAllocate, appointmentId);

            if (id.HasValue == false)
            {
                loggingService.Info(GetType(), "Payment not handled");
                return;
            }

            CustomerModel customerModel = customerProvider.GetCustomerModel(paymentMadeMessage.UmbracoContext);

            int customerId = customerModel.Id;

            UpdateAppointment(id.Value, customerId, paymentId);
        }
        
        /// <summary>
        /// Gets the appointment identifier.
        /// </summary>
        /// <param name="autoAllocate">The automatic allocate.</param>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns></returns>
        internal int? GetAppointmentId(
            string autoAllocate,
            string appointmentId)
        {
            int? id = null;

            if (string.IsNullOrEmpty(appointmentId) == false)
            {
                string appId = encryptionService.DecryptString(appointmentId);

                id = Convert.ToInt32(appId);
            }

            else if (string.IsNullOrEmpty(autoAllocate) == false &&
                     autoAllocate.ToLower() == "y")
            {
                id = cookieService.GetValue<int>(AppointmentConstants.LastAppointmentIdCookie);
            }

            //// remove the cookie so it doesnt get allocated to the next payment.
            cookieService.Expire(AppointmentConstants.LastAppointmentIdCookie);

            return id;
        }

        /// <summary>
        /// Updates the appointment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="paymentId">The payment identifier.</param>
        internal void UpdateAppointment(
            int id,
            int customerId,
            string paymentId)
        {
            AppointmentModel model = databaseProvider.GetAppointment(id, customerId);

            if (model != null)
            {
                loggingService.Info(GetType(), "Appointment Found");

                model.PaymentId = paymentId;

                databaseProvider.UpdateAppointment(model);

                loggingService.Info(GetType(), "Appointment updated with PaymentId=" + paymentId);
            }
        }
    }
}
