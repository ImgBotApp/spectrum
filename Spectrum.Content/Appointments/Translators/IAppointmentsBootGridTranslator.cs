﻿namespace Spectrum.Content.Appointments.Translators
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IAppointmentsBootGridTranslator
    {
        /// <summary>
        /// Translates the specified view models.
        /// </summary>
        /// <param name="viewModels">The view models.</param>
        /// <param name="current">The current.</param>
        /// <param name="rowCount">The row count.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        BootGridViewModel<AppointmentViewModel> Translate(
            List<AppointmentViewModel> viewModels,
            int current,
            int rowCount,
            string searchString);
    }
}