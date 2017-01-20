﻿namespace Spectrum.Model.Correspondence
{
    using NPoco;
    using System;

    /// <summary>
    /// The Event Model
    /// </summary>
    [TableName("Event")]
    public class EventModel 
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Guid { get; }

        /// <summary>
        /// Gets the event.
        /// </summary>
        public Event Event { get; }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventModel" /> class.
        /// </summary>
        /// <param name="guid">The identifier.</param>
        /// <param name="userEvent">The user event.</param>
        public EventModel(
            Guid guid,
            Event userEvent)
            : this(guid, userEvent, DateTime.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventModel" /> class.
        /// </summary>
        /// <param name="guid">The identifier.</param>
        /// <param name="userEvent">The user event.</param>
        /// <param name="dateTime">The date time.</param>
        public EventModel(
            Guid guid,
            Event userEvent,
            DateTime dateTime)
        {
            Guid = guid;
            Event = userEvent;
            DateTime = dateTime;
        }
    }
}
