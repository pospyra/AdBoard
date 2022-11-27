﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    public class UserLogin
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
