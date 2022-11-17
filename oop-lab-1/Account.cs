namespace oop_lab_1
{
    internal class Account
    {
        public string Login { get; private set; }
        public Password Password { get; private set; }
        public string Email { get; private set; }
        public long Balance { get; private set; }
        public Role Role { get; private set; }

        public Account(string login, Password pass, string email, long balance, Role role)
        {
            Login = login;
            Password = pass;
            Email = email;
            Balance = balance;
            Role = role;
        }

        public override string ToString()
        {
            return $"Account(Login: {Login}, Password: {Password}, Email: {Email}, Balance: {Balance}, Role: {Role})";
        }
    }
}
