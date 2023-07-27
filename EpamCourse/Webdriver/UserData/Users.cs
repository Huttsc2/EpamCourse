using System.Text.Json.Serialization;

namespace EpamCourse.Webdriver.UserData
{
    public class Users
    {
        [JsonPropertyName("googleMailData")]
        public User GoogleMailData { get; set; }

        [JsonPropertyName("yandexMailData")]
        public User YandexMailData { get; set; }
    }
}
