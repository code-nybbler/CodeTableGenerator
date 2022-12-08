using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace CodeTableGenerator
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Code Table Generator"),
        ExportMetadata("Description", "Makes creating code tables a faster, more standardized process"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAMfSURBVFhHzZdLbE1BGMfP9Vh4NNGgtJ4lFdQzuQsSC4RgbaENCxuJxlpssBNshESESqQ2EhGJpQXpjogbiUci6pGGaC9azypS1O9/Zub09Obee+acRPgl/3zfzD09852Z+b6ZBv+anLWZqc9vmIPZjpajI72Fzhfq9yVzAAysv92KLqMa9Bs9JIBVWG/GWJuFdagdaXBxDXUQ2DTT9CNTAAxShzmHZocdhna+/iT2vWn6kRgAg421bpypSGutwQbQdzSEAoLQUnhT7uURDK4v7KhpaLw70NP9wfQy5w2N1gu60E10Bx2lv8hzD/SDL0kz8AatRBvD1ggH0De+9jA6jn8dTUF1BL0D603VAHi5pnUFauHFW9SHVXs3uqG25RF6hVajCzyzTJ0+JO4BgtAa70NXefEm7Gmknf4ZOZrRL6QgJ6L9yIuqe8DBuvazvtpcF9G8sDMIntJ/n6Dm4ysd9fWT9AM08/wJfg83ZjXSpOEp9NK4IecZ/CxW+b827BlhHNKsJJImgB8onuPjUSuai8pV1FnWVsU7AJvfvaYVoaCi9IyhZ5VBiaSZAVGw9ou12njOdzxDrQR8yzSrkzaAY+gMOhS2TPXrM27EuyAYvmL9RFIFwFcNIqWk8l6oBPcYN4KsyNVaP5G0M+CYYe0gKho3YiZaZNxksgaw0FrNwHPjRigjWoybTNYAFlurGVAJLmWbtYmkDoDiMwGj65dQOVZxUjbEaeK5ydavSpYZmG4lvqKPSOdFHC2D19UsSwBLkduEqowKIn4wOf5aAFpffaEK0CdrS4uR8DqSswSwGanM/kRvh83696NS8vX59eXOiFGkCoCNtQDThFT9VGz6ioVOYlD1C5HvIFVzbqkqknYGdiIdtcp/4Q4nNwO6GzruoTXGrYx3AHy9jtdd6DXSUayT0A2sTBDxk/EJ2mPcyqSZgSVIJfYS0rVcRcjtfnce6HBys6JrWy2Bu6pZljQB3EaaYk2t/jHR4EpB0W2t7uuPjRvWBl1eS8+KUSTu0lL4Il3T9yIFcJDTcYg+XcnbkJZC/yfk2I1ddoP+zwTBH3DbzE3ryrHUAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAk3SURBVHhe7Zx5jBRFFMZ7QAWPRSTq7qwKixfiTXYAL3R3RUU0eESjeAQV8UBJvKIhikbxD/7wSIhGjQYVE6MxGKNGkKiDhCDorhqNEkS5JOwKCiqHgEr7fV1VY09P9cz00FXdkP0lL6+qZ2dn59vXdbyqaqebbrrZnclIv1uQzbUeDHcVbBjsb9hTne357+ETY7cQEMKNgJsEGwk7iNd8TIaI02TZOqkWEML1hXsSdgOsB6+FMAgi/iDLVin3RyWKFG8O7CZYpb9zovTWSaWAEK8B7lXYcO9COMthX8Ku9WoJkDoBZeS9ARvjXQjnG9g50nbgfWfxom3SGIHXwShKJSah3VsD24zy67ATvKuWSVUngig6Cu5j2ADvQjgLIBx75gJ4bx9c+1NWrZGaCIQATXAfwSqJR7ZLXyAJ8UiabuF7YBSxGnZKnzipEBDRNxiO4i2CfQvbCCtHSQQmRewCQozDZLFqcPstgY2BnY7qdNhv3guO8z7sZVH0mCf9RnxOKtrvntLHAr7UFXDn1jUO7A1r3Lx25WrxSvXgfdfDjRY151jYENjvsIdgn8M4vDkFNhI/u6yWz4iTWP+LEHAU3LOwvWGrHddt6+yYt4OvVQLv7Q3HOe07MArEaDsZxlt7JqJzFX6GYnLg7OcV2BS8vkZU7RK3gJzsvw2r8y44zih8sQ9lOZSGXEvPjJN5DsWbYc14z1feCwHw+/eBY8TVexcEFG483jNXVO0SdxvI1BIjSXG49GWBeFfDUTxG64+8pgMi8fV2USswAbYI4k6DWR9MxyogvuBauAtgi70LjnOr9JW4F8a7YQ5+xybvSjiqIyELHdf5BP5+2AOwWfVD7XYusffCECAPOw1F9qBDERUveC+EgNfZYbBtI7z9K/Gd9GQ+ZD8efrKoOoN6uF7e0Bomx4HMkCyD3QKR5mab20o+C9d57W5R8wh2EDo4VlTMhgXTXY805FrZiVnBmICIQk6txomac56Tcedn0VnIuuIOGDsexTrpQ3EdZwsc0/ldsPUwDnv89MM9fJssG8dkBFLEz+BeEzXnTDRzbK+cbHNrBtHHcV0wFf+P9KFAHI41GWFvwh6FMf0VZCp+fx9ZNopRAT1cr5dUY7Sz8cUehwoUbwpsP++qAMHllP3SEL4XHKOWUMgrRbGEA2Eq+o1iXMDOjjznrTeKmseDsMdgHNP5Ye95iSiW0jgMvWvGe98Z4opTacp4n/RGMR+BALcy01QzRa0sd0lfgrvT6yyYsamW/oh2zmSMYkVA4ma8lTUmS8vRhC89G8Y5sAfbMhgH2k/A9vIuVk+b9MaINZlQDkz6mSjgsGa8uBLK0bCJ+Fn+PDsILi7dCfPPcKplKT6XK3vGsBaBkj+krwT/sexhmVg4lRdqhEsERrEtIMdtUeBYcpso1kRVc/FdwbaAFCNKNnklzD/ziEod2k+jc2PbAm6FcQZRLRxYc+ZRK9s5uDSJVQExnPmXTtSqggJWWh8px+qu9rxRDW1HIPlZ+mqg4IzaWuCC+9OiaI4kBIySemcEUoio/AIbi4g3nqVOQsAPpK8GCrhBFKtiBYyzmcEQj/lI41gXEA3Sp3BLRK1AB4xjviAUMEqbiQ7KnQ7xdqXdjIR1AdGoM5d3DYxrH3/BZsCYE+RyQBAKqNaIq2FAZ/s80x1vEUncwuyNv4Ydg2KT6zoTUOa6ry6LTIF1woZRn8217CvLVkhEQAWEW9fVkVf7XPy5QQUFjNLpYAqYGSTLVkhUwAAHSO+HMxeu0lW1OC+5SHorpElAbusNshUNGqOw0lKnn/Olt0IqBKxvbuF8NStqRWxFpxN19jKkIdeqaw6MkAoBe2QyzPvxEE0QNYiO0g7W4b9xqSwbJy23cCNMFzUqlRVFQOJfKjVKWgQMS3wqAZnWisJl2ebWqOn/mthdBOQULQp95ZYP46RFwLDVM9UGMjkQdYZxufRGSYuA3FCpQw1fOO2LmlnmiU7jJC6g3G0QtnbBKZ6D6R6z2FF35rfhdxv/fslHoGirDhGVErxVPEz3uI7yK8sR6IXfvecsrJfhSOl1+LPRUYcypEV6Y6RBwLB1X3Ya/gWlVdJHwXhPnAYBT5I+yDZI6I9AHm2NCs+dGCVRAbNizlp0aNDHZrRh/ixMxc2XGo7AvDi4CyxWko5ADl/6iWIJmxCBzF4roiRWFX0w9jG6OyFpAS+WXsemzv+TreQn6aPAsaPRow9JC3ih9Ar2tGrGETy+GmU92c+eKSDaP3Ye6niDggd11IwjuBGJ0zrmBqOSk94ISUbgidIrKJB/D2DRahzCkoPpWg5V78r2uIokKSA3ifvhES7mBRXeNE6RcVxmZmrpiZuyuZb9ZTl2EhGwobmVGyiDCQQ+hYO7UxVFAsr13ii7FBRcqQtGe2wkImAm4zXs/hygrm3TDVtqiUAS7KxiI6lbmA8Q88OEafDADHOAQXQRWG7DphqI8wCkEawLiN6XQo0VtQJfwILPitEJqNvz8jwsrHd+Cca2czA+l4dvYieJCOSK2UBRLMA1j+DjTnQb0nW7VTkdDNv1yodZvAujeEZW6qwKiM6DCz3qqJaCtyA3EfnhrVfUiUh0C+wUfqkolsAhzIui6NwufaxYFRCdB5+pEBzYzoc1i2KBDa6rjUDdLn8e+eKhRh181iCjm83BcNzGx/FinNi+hYPHUJnj477AoIDruzrywagkuqw0n59Q7imWHMK8JYreyfZYsSYg/vvcNRUcTrwH4xzX/xAJEnaeRHedUcYoVkugQThk4h5EMg5/R39ZjgWbEchza/7P4/mPZ2C6qVZY6konIAfl3NnFR+bpYAQyQrm/hp/PM3uxYVNAPqLO/5CcxZ3teTb+fL5CEO2AGVMRtmW6XfuM7uDTPBQ5fA47KkY7O6awDqcmrAmIL8FOIS9qHrPkmLBVVIvQpu+72vMcxui2/FLAsDUTngA9FJ6n40fj7+BJ99iwGYGEJzX5iBOeoORjnCiebktuueyzLrHKaaFuCxxvV/bSWyDcClhYb10zUVf7YwWRwajg816CjMCXXSDLReA9PMX5sKgVmAXjgeypXk0kZjtwyy9E1IZ1LrGQtIC8A/jcAzb0HBBzSsa2bAYE5M5ULXgfhz3cT6hyhMvx87qBdzfddNNNOI7zH0ndLvjm6uQdAAAAAElFTkSuQmCC"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class CodeTableGenerator : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new CodeTableGeneratorControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public CodeTableGenerator()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}