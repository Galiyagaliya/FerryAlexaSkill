namespace Ferry.Model
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class WsdotModelAttribute : System.Attribute
    {
        public WsdotModelAttribute(string path, string method)
        {
            this.Path = path;
            this.Method = method;
        }

        public string Path { get; }

        public string Method { get; }
    }
}