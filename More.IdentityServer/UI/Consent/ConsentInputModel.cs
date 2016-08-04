﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace More.IdentityServer.UI.Consent
{
    public class ConsentInputModel
    {
        public IEnumerable<string> ScopesConsented { get; set; }
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; }
    }
}
