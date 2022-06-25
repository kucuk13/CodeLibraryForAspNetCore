namespace MiddlewareExample
{
    public class PermissionAttribute : Attribute
    {
        public string Type { get; set; }

        public PermissionAttribute(string Type)
        {
            this.Type = Type;
        }
    }
}
