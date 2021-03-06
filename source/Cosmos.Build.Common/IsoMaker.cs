using System;
using System.IO;
using System.Text;

namespace Cosmos.Build.Common
{
    public class IsoMaker
    {
        static public void Generate(string imageFile, string isoFilename)
        {
            var destinationDirectory = Path.GetDirectoryName(imageFile);

            string isoDirectory = Path.Combine(destinationDirectory, "iso");

            if (Directory.Exists(isoDirectory))
            {
                Directory.Delete(isoDirectory, true);
            }

            Directory.CreateDirectory(isoDirectory);

            var buildISO = Path.Combine(CosmosPaths.Build, "ISO");

            File.Copy(Path.Combine(buildISO, "isolinux.bin"), Path.Combine(isoDirectory, "isolinux.bin"));
            File.Copy(Path.Combine(buildISO, "mboot.c32"), Path.Combine(isoDirectory, "mboot.c32"));
            File.Copy(Path.Combine(buildISO, "syslinux.cfg"), Path.Combine(isoDirectory, "syslinux.cfg"));
            File.Copy(imageFile, Path.Combine(isoDirectory, "Cosmos.bin"));

            string arg =
                "-relaxed-filenames" +
                " -J -R" +
                " -o " + Quote(isoFilename) +
                " -b isolinux.bin" +
                " -no-emul-boot" +
                " -boot-load-size 4" +
                " -boot-info-table " +
                Quote(isoDirectory);

            var output = ProcessExtension.LaunchApplication(
                Path.Combine(Path.Combine(CosmosPaths.Tools, "mkisofs"), "mkisofs.exe"),
                arg,
                true
            );

        }

        protected static string Quote(string location)
        {
            return '"' + location + '"';
        }

    }
}