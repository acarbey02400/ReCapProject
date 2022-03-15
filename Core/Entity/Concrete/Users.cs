﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
        public class User : IEntity
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EMail { get; set; }
            public string Password { get; set; }

        }
}
