﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Auth.SettingsPolicy
{
    public class CategorieOwnerRequirement: IAuthorizationRequirement
    {
    }
}
