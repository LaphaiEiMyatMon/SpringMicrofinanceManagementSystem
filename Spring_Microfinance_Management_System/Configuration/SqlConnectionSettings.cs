// =============================================================================
// <summary>
// SQLServer 
// </summary>
// <copyright file="SqlConnectionSettings.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Spring_Microfinance_Management_System.Framework.Configuration
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SQLServer 
    /// </summary>
    [Serializable]
    public class SqlConnectionSettings
    {
        /// <summary>
        /// SQLServer 
        /// </summary>
        [XmlArray("SqlConnectionSettings")]
        [XmlArrayItem("SqlConnectionSetting")]
        [SuppressMessage("Microsoft.Performance", "CA1819", Justification = "Just")]
        public SqlConnectionSetting[] Settings { get; set; }

        /// <summary>
        /// <see cref="SqlCommand"/> の <see cref="SqlCommand.CommandTimeout"/>
      
        /// </summary>
        [XmlElement("SqlCommandTimeoutSeconds")]
        public SimpleValueSetting SqlCommandTimeoutSeconds { get; set; }
    }
}
