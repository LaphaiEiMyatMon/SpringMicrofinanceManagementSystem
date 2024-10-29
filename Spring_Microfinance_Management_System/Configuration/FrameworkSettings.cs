// =============================================================================
// <summary>
// Framework 
// </summary>
// <copyright file="FrameworkSettings.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Spring_Microfinance_Management_System.Framework.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Xml;
    using System.Xml.Serialization;

    
    [Serializable]
    [XmlRoot("FrameworkSettings")]
    public class FrameworkSettings
    {
        
        [XmlIgnore]
        public const string AppConfigKey = "Framework.Config";

        
        [XmlIgnore]
        private static object lockObject = new object();

        
        [XmlIgnore]
        private static FrameworkSettings instance;

        
        [XmlIgnore]
        public static FrameworkSettings Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FrameworkSettings();

                       
                        var path = ConfigurationManager.AppSettings[AppConfigKey];
                        instance.LoadSettings(path);
                    }
                }

                return instance;
            }
        }

        
        [XmlElement("Framework.Core.ProductName")]
        public SimpleValueSetting ProductName { get; set; }

        
        [XmlElement("Framework.Core.ProductLogicalName")]
        public SimpleValueSetting ProductLogicalName { get; set; }

     
        [XmlElement("Framework.Data.SqlConnectionSettings")]
        public SqlConnectionSettings SqlConnectionSettings { get; set; }

       
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "Just")]
        public void SaveSettings(
            string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(
                    "app.config に Framework.config ",
                    "path");
            }

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException(
                    "Framework.config " + Environment.NewLine + path,
                    "path");
            }

            using (var sw = new StreamWriter(path))
            {
                var xs = new XmlSerializer(FrameworkSettings.Default.GetType());
                xs.Serialize(sw, FrameworkSettings.Default);
            }
        }

        
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "Just")]
        public string GetFilePath(
            string pathOnConfig)
        {
            if (string.IsNullOrWhiteSpace(pathOnConfig))
            {
                return string.Empty;
            }

            var path = pathOnConfig;

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            return path;
        }

        
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "Just")]
        public void LoadSettings(
            string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(
                    "app.config  Framework.config ",
                    "path");
            }

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException(
                    "Framework.config " + Environment.NewLine + path,
                    "path");
            }

            using (var sr = new StreamReader(path))
            {
                var xs = new XmlSerializer(FrameworkSettings.Default.GetType());
                FrameworkSettings.instance = xs.Deserialize(sr) as FrameworkSettings;
            }
        }
    }
}
