using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

public class User 
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Username { get; set; }
    public string Password { get; set; }
    public bool isActive { get; set; }
}
