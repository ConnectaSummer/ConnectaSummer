namespace ConnectaSummer.Domain
{
    public class BrokenRoles
    {
        public BrokenRoles(string property, string description, TypeValidator type)
        {
            Property = property;
            Description = description;
            Type = type;
        }

        public string Property { get; protected set; }

        public string Description { get; protected set; }

        public TypeValidator Type { get; protected set; }
    }

    public enum TypeValidator
    {
        ERROR,
        WARNING
    }
}
