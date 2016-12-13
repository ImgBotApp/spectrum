﻿namespace Spectrum.Content.Services
{
    using System;
    using System.Net;
    using Umbraco.Core.Models;
    using Umbraco.Core.Services;
    using Umbraco.Web.Security;

    /// <summary>
    /// The UserService class.
    /// </summary>
    /// <seealso cref="Spectrum.Content.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The membership helper.
        /// </summary>
        private MembershipHelper membershipHelper;

        /// <summary>
        /// Gets or sets the member service.
        /// </summary>
        public IMemberService MemberService { get; set; }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="memberType">Type of the member.</param>
        /// <returns>An IMember.</returns>
        public IMember CreateUser(
            string name,
            string password,
            string emailAddress,
            string memberType)
        {
            Guid guid = Guid.NewGuid();

            if (MemberService.GetByEmail(emailAddress) != null)
            {
                return null;
            }

            IMember member = MemberService.CreateMemberWithIdentity(emailAddress, emailAddress, name, memberType);

            member.IsApproved = false;
            member.SetValue(UserConstants.HasVerifiedEmail, false);
            member.SetValue(UserConstants.ProfileUrl, member.Id);
            member.SetValue(UserConstants.Guid, guid.ToString());
            member.SetValue(UserConstants.RegistrationDate, DateTime.Now.ToString("dd/MM/yyyy @ HH:mm:ss"));

            MemberService.Save(member);
            MemberService.SavePassword(member, password);

            return member;
        }

        /// <summary>
        /// Determines whether [is user logged in].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is user logged in]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsUserLoggedIn()
        {
            return GetMembershipHelper().IsLoggedIn();
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>True or False.</returns>
        public bool Login(
            string userName,
            string password)
        {
            return GetMembershipHelper().Login(userName, password);
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            GetMembershipHelper().Logout();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>An IMember.</returns>
        public IMember GetUser(string userName)
        {
            return MemberService.GetByUsername(userName);
        }

        /// <summary>
        /// Updates the login status.
        /// </summary>
        /// <param name="member">The member.</param>
        public void UpdateLoginStatus(IMember member)
        {
            string hostName = Dns.GetHostName();
            string ipAddress = Dns.GetHostAddresses(hostName).GetValue(0).ToString();

            int noLogins = member.GetValue<int>(UserConstants.NumberOfLogins);

            member.SetValue(UserConstants.NumberOfLogins, noLogins + 1);
            member.SetValue(UserConstants.LastLoggedInDateTime, DateTime.Now.ToString("dd/MM/yyyy @ HH:mm:ss"));
            member.SetValue(UserConstants.HostNameOfLastLogin, hostName);
            member.SetValue(UserConstants.IpAddressOfLastLogin, ipAddress);

            MemberService.Save(member);
        }

        /// <summary>
        /// Gets the user unique identifier.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns> The Guid.</returns>
        public Guid GetUserGuid(IMember member)
        {
            return member.GetValue<Guid>(UserConstants.Guid);
        }

        /// <summary>
        /// Gets the membership helper.
        /// </summary>
        /// <returns>the MembershipHelper.</returns>
        internal MembershipHelper GetMembershipHelper()
        {
            if (membershipHelper == null)
            {
                membershipHelper = new MembershipHelper(Umbraco.Web.UmbracoContext.Current);
            }

            return membershipHelper;
        }
    }
}
