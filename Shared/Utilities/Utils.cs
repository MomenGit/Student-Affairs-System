using System.Reflection;

namespace Shared.Utilities;

public static class Utils
{
    public static ICollection<Assembly> ProjectAssemblies { get; } = LoadAssemblies();

    private static ICollection<Assembly> LoadAssemblies()
    {
        // Define the base directory where the DLLs are located
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;


        ICollection<Assembly> domainAssemblies = new List<Assembly>();

        // Ensure the directory exists
        if (Directory.Exists(baseDirectory))
        {
            // Get all DLL files that match the pattern '*.dll'
            string[] dllFiles = Directory.GetFiles(baseDirectory, "*.dll");

            // Filter DLLs with no dots in the filename, except for the one before .dll
            List<string> domainDlls = dllFiles
                .Where(dll => Path.GetFileNameWithoutExtension(dll).All(c => c != '.')) // No internal dots
                .ToList();

            // Iterate over each DLL and load the assembly
            foreach (string dllPath in domainDlls)
                try
                {
                    // Load the assembly from the DLL file
                    Assembly assembly = Assembly.LoadFrom(dllPath);
                    Console.WriteLine($"Successfully loaded: {Path.GetFileName(dllPath)}");
                    domainAssemblies.Add(assembly);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load: {Path.GetFileName(dllPath)}. Error: {ex.Message}");
                }
        }
        else
        {
            Console.WriteLine($"The directory '{baseDirectory}' does not exist.");
        }

        return domainAssemblies;
    }

    // Custom validation to check if a string is a valid URL
    public static bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) &&
               (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}