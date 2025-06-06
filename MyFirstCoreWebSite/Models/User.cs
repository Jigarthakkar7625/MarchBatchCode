﻿using System;
using System.Collections.Generic;

namespace MyFirstCoreWebSite.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
