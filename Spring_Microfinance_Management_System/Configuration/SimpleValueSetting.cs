namespace Spring_Microfinance_Management_System.Framework.Configuration
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    
    [Serializable]
    public class SimpleValueSetting
    {
        
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
