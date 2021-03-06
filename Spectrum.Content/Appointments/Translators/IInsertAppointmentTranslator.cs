﻿namespace Spectrum.Content.Appointments.Translators
{
    using Models;
    using ViewModels;

    public interface IInsertAppointmentTranslator
    {
        /// <summary>
        /// Translates the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        AppointmentModel Translate(InsertAppointmentViewModel viewModel);
    }
}
