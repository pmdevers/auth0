using Microsoft.Extensions.Primitives;

namespace Auth0.Management
{
    public struct MultifactorProvider
    {
        public string Value { get; }
        public static MultifactorProvider Duo = "duo";
        public static MultifactorProvider GoogleAuthenticator = "google-authenticator";

        public static implicit operator MultifactorProvider(string i)
        {
            return new MultifactorProvider(i);
        }

        public static bool operator ==(MultifactorProvider left, MultifactorProvider right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MultifactorProvider left, MultifactorProvider right)
        {
            return !left.Equals(right);
        }

        private MultifactorProvider(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(MultifactorProvider other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is MultifactorProvider provider && Equals(provider);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}