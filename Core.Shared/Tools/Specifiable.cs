namespace Core.Database.Tools
{
    public abstract class Specifiable
    {
        public bool IsSpecified { get; protected set; } = false;

        public virtual void Unspecify()
        {
            IsSpecified = false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Specifiable)
            {
                var other = (Specifiable)obj;
                return IsSpecified == other.IsSpecified;
            }

            return IsSpecified && obj == null;
        }

        public override int GetHashCode() => IsSpecified ? 0 : -1;

        public override string? ToString() => null;

        public static bool operator ==(Specifiable left, Specifiable right) => left.Equals(right);
        public static bool operator !=(Specifiable left, Specifiable right) => !(left == right);
    }

    public sealed class Specifiable<T> : Specifiable
    {
        private T? _value = default;
        public T? Value
        {
            get => _value;
            set
            {
                _value = value;
                IsSpecified = true;
            }
        }

        public override void Unspecify()
        {
            base.Unspecify();
            _value = default;
        }

        public static Specifiable<T> Unspecified { get; } = new Specifiable<T>();
        public static Specifiable<T> Specified { get; } = new Specifiable<T>() { IsSpecified = true };

        public static implicit operator Specifiable<T>(T t) => new Specifiable<T>() { Value = t };

        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj))
                return false;

            if (obj is Specifiable<T>)
            {
                var otherSpecifiable = (Specifiable<T>)obj;
                return Value!.Equals(otherSpecifiable.Value);
            }
            
            return false;
        }

        public override int GetHashCode() => IsSpecified ? (Value?.GetHashCode() ?? 0) : -1;

        public override string? ToString() => IsSpecified ? (Value?.ToString() ?? null) : null;

        public static bool operator ==(Specifiable<T> left, Specifiable<T> right) => left.Equals(right);
        public static bool operator !=(Specifiable<T> left, Specifiable<T> right) => !(left == right);

        public static bool operator ==(Specifiable<T> left, Specifiable right) => left.Equals(right);
        public static bool operator !=(Specifiable<T> left, Specifiable right) => !(left == right);

        public static bool operator ==(Specifiable left, Specifiable<T> right) => left.Equals(right);
        public static bool operator !=(Specifiable left, Specifiable<T> right) => !(left == right);
    }
}