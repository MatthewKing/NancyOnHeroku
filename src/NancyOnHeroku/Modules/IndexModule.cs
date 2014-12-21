namespace NancyOnHeroku.Modules
{
    using System.Reflection;
    using Nancy;
    using NancyOnHeroku.Models;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = p =>
            {
                var model = new IndexModel();
                model.NancyVersion = GetNancyVersion();

                return View["Index", model];
            };
        }

        private static string GetNancyVersion()
        {
            var assembly = Assembly.GetAssembly(typeof(NancyModule));
            if (assembly == null)
                return null;

            var attributeType = typeof(AssemblyInformationalVersionAttribute);
            var attribute = assembly.GetCustomAttribute(attributeType);
            if (attribute == null)
                return null;

            return ((AssemblyInformationalVersionAttribute)attribute).InformationalVersion;
        }
    }
}
