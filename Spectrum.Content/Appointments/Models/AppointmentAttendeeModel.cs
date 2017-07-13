﻿namespace Spectrum.Content.Appointments.Models
{
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;

    [TableName(AppointmentConstants.AppointmentAttendeeTableName)]
    [PrimaryKey("Id")]
    public class AppointmentAttendeeModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("Id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the appointment identifier.
        /// </summary>
        public int AppointmentId { get; set; }
    }
}
