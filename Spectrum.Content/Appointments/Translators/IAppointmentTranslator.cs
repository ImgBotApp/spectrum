﻿namespace Spectrum.Content.Appointments.Translators
{
    using Models;
    using ViewModels;

    public interface IAppointmentTranslator
    {
        /// <summary>
        /// Translates the specified view model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        AppointmentViewModel Translate(AppointmentModel model);
    }
}
