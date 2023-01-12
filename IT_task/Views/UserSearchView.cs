using domain.Models;
using System.Text.Json.Serialization;
namespace IT_task.Views
{
    public class UserSearchView
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("fullname")]
        public string FullName { get; set; }
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
