using Tracker.Data.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Api.Models
{
    public class AuthDto
    {
        [EmailAddress]
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}