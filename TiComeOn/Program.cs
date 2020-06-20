using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiCome
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var loadedAssemblies = new Dictionary<string, Assembly>();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "TiCome.Include." +
                new AssemblyName(args.Name).Name + ".dll";

                //Must return the EXACT same assembly, do not reload from a new stream
                if (loadedAssemblies.TryGetValue(resourceName, out Assembly loadedAssembly))
                {
                    return loadedAssembly;
                }

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        return null;
                    byte[] assemblyData = new byte[stream.Length];

                    stream.Read(assemblyData, 0, assemblyData.Length);

                    var assembly = Assembly.Load(assemblyData);
                    loadedAssemblies[resourceName] = assembly;
                    return assembly;
                }
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LicenseForm());
        }
    }
}
