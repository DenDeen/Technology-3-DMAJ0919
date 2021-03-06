﻿using Microsoft.Owin.Security; /* Added */
using Microsoft.Owin.Security.Cookies; /* Added */
using Microsoft.Owin.Security.OpenIdConnect; /* Added */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleSignOnWIthAzureAD.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType
                    );
            }
        }

        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType
                );
        }
    }
}
