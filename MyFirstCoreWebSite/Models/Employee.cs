﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstCoreWebSite.Models;


public partial class Employee
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address123 { get; set; }

    public string? MyAddress { get; set; }
}
