﻿namespace Spectrum.Content.ContentModels
{
    using Umbraco.Core.Models;
    using Umbraco.Web;

    public class MailTemplateModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailTemplateModel"/> class.
        /// </summary>
        /// <param name="content">The original content.</param>
        public MailTemplateModel(IPublishedContent content)
          : base(content)
        {
        }

        /// <summary>
        /// Gets the blind copy.
        /// </summary>
        public string BlindCopy => this.GetPropertyValue<string>("blindCopy");

        /// <summary>
        /// Gets a value indicating whether [surpress send email].
        /// </summary>
        public bool SurpressSendEmail => this.GetPropertyValue<bool>("surpressSendEmail");

        /// <summary>
        /// Gets the subject.
        /// </summary>
        public string Subject => this.GetPropertyValue<string>("subject");

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text => this.GetPropertyValue<string>("text");

        /// <summary>
        /// Gets or sets the tokenized text.
        /// </summary>
        public string TokenizedText { get; set; }
    }
}
