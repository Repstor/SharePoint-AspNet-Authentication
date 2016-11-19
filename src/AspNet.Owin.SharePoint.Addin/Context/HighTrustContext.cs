﻿using System;
using System.Security.Claims;
using AspNet.Owin.SharePoint.Addin.Common;

namespace AspNet.Owin.SharePoint.Addin.Context
{
	public class HighTrustContext : SPContext
	{
		private readonly string _userId;

		public HighTrustContext(ClaimsPrincipal claimsPrincipal) : base(claimsPrincipal)
		{
			_userId = claimsPrincipal.FindFirst(c => c.Type.Equals(CustomClaimTypes.ADUserId)).Value;
		}

		protected override AccessToken CreateAppOnlyAccessToken(Uri host)
		{
			var s2sToken = AuthHelper.GetS2SAccessToken(host, null);

			return new AccessToken
			{
				Value = s2sToken,
				ExpiredOn = DateTime.UtcNow.Add(TokenHelper.HighTrustAccessTokenLifetime).AddMinutes(-5)
			};
		}

		protected override AccessToken CreateUserAccessToken(Uri host)
		{
			var s2sToken = AuthHelper.GetS2SAccessToken(host, _userId);

			return new AccessToken
			{
				Value = s2sToken,
				ExpiredOn = DateTime.UtcNow.Add(TokenHelper.HighTrustAccessTokenLifetime).AddMinutes(-5)
			};
		}
	}
}