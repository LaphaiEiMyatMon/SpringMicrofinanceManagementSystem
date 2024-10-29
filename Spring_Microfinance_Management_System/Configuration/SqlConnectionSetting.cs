// =============================================================================
// <summary>
// SQLServer 
// </summary>
// <copyright file="SqlConnectionSetting.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Spring_Microfinance_Management_System.Framework.Configuration
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    
    [Serializable]
    public class SqlConnectionSetting
    {
        
        [XmlAttribute("settingName")]
        public string SettingName { get; set; }

        /// <summary>
        /// <see cref="System.Data.SqlClient.SqlConnection"/> の <see cref="System.Data.SqlClient.SqlConnection.ConnectionString"/> です。
        /// </summary>
        [XmlAttribute("sqlConnectionString")]
        public string SqlConnectionString { get; set; }

        /// <summary>
     
        /// </summary>
        [XmlAttribute("isDefault")]
        public bool IsDefault { get; set; }
    }
}
