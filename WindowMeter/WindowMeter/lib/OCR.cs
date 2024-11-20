using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;

namespace WindowMeter
{
    public class OCR
    {
        public static string ocrInstallDir = null;

        public static bool IsOCRAvailable() {
            return ocrInstallDir != null;
        }

        public static string FindTesseractInstallationPath()
        {
            // 1. Check common installation directories
            string[] commonPaths = {
                @"C:\Program Files\Tesseract-OCR",
                @"C:\Program Files (x86)\Tesseract-OCR",
            };

            foreach (string path in commonPaths)
            {
                if (File.Exists(Path.Combine(path, "tesseract.exe")) || File.Exists(Path.Combine(path, "tesseract")))
                {
                    return path;
                }
            }

            // 2. Check PATH environment variable
            string pathEnv = Environment.GetEnvironmentVariable("PATH");
            if (pathEnv != null)
            {
                foreach (string path in pathEnv.Split(Path.PathSeparator))
                {
                    if (File.Exists(Path.Combine(path, "tesseract.exe")) || File.Exists(Path.Combine(path, "tesseract")))
                    {
                        return path;
                    }
                }
            }

            // 3. Check Windows registry (Windows-specific)
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
                {
                    if (key != null)
                    {
                        foreach (string subkeyName in key.GetSubKeyNames())
                        {
                            using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                            {
                                object displayName = subkey?.GetValue("DisplayName");
                                object installLocation = subkey?.GetValue("InstallLocation");

                                if (displayName != null && installLocation != null &&
                                    displayName.ToString().Contains("Tesseract"))
                                {
                                    return installLocation.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // If Tesseract was not found
            return null;
        }

        public static TesseractEngine engine = null;
        public static void init() {
            ocrInstallDir = FindTesseractInstallationPath();

            if (ocrInstallDir == null)
            {
                return;
            }

            try
            {
                var tessDataPath = Path.Combine(ocrInstallDir, "tessdata");

                engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default);
            }
            catch (Exception)
            {

                ocrInstallDir = null;
                engine = null;
            }
            
        }

        public static string ImageToText(Bitmap bitmap)
        {
            try
            {
                if (engine == null)
                {
                    return null;
                }

                using (var img = PixConverter.ToPix(bitmap))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        return text;
                    }
                } 
                
            }
            catch (Exception)
            {
                return null;
            }

            
        }
    }
}
