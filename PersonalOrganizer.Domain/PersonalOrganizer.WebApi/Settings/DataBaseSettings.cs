namespace PersonalOrganizer.WebApi.Settings
{
    public class DataBaseSettings
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string PgConnectionString()
        {
            return $"Host={this.Host};Database={this.Database};Username={this.Username};Password={this.Password}";
        }
    }
}