﻿namespace Spectrum.Content.Appointments.Models
{
    using System.Net.Mime;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;
    
    // ReSharper disable once InconsistentNaming
    [TableName(Constants.Database.IcalAppointmentTableName)]
    [PrimaryKey("Id", autoIncrement = true)]
    public class ICalAppointmentModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1000)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the appointment identifier.
        /// </summary>
        public int AppointmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the serialized string.
        /// </summary>
        [Ignore]
        public string SerializedString { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        [Ignore]
        public ContentType ContentType { get; set; }
    }
}
