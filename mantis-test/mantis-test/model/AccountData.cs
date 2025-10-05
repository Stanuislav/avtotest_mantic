namespace mantis_test
{
    public class AccountData
    {

        public AccountData(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public AccountData() { }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}