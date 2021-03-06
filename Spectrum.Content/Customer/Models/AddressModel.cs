﻿using System;

namespace Spectrum.Content.Customer.Models
{
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Persistence.DatabaseAnnotations;

    [TableName(Constants.Database.AddressTableName)]
    [PrimaryKey("Id", autoIncrement = true)]
    public class AddressModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1000)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        public DateTime LasteUpdatedTime { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        public string LastedUpdatedUser { get; set; }
        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the building number.
        /// </summary>
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the full address.
        /// </summary>
        public string FullAddress { get; set; }
    }
}
