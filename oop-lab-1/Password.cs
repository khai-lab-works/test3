namespace oop_lab_1
{
    internal class Password
    {
        public string Pass { get; private set; }

        public Password(string pass)
        {
            Pass = pass;
        }

        public override string ToString()
        {
            return $"{Pass}";
        }
    }
}
