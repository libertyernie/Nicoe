using System.Xml.Serialization;

namespace Nicoe.HBC {
    [XmlRoot(ElementName = "app")]
    public class MetaXml {
        [XmlAttribute("version")]
        public int Version;

        [XmlElement("name")]
        public string Name;

        [XmlElement("coder")]
        public string Coder;

        [XmlElement("short_description")]
        public string ShortDescription;

        [XmlElement("long_description")]
        public string LongDescription;

        [XmlIgnore]
        public bool NoIosReload;

        [XmlElement("no_ios_reload")]
        public string NoIosReloadStr {
            get {
                return NoIosReload ? "" : null;
            }
            set {
                NoIosReload = value != null;
            }
        }

        public bool ShouldSerializeNoIosReloadStr() {
            return NoIosReload;
        }

        [XmlIgnore]
        public bool AhbAccess;

        [XmlElement("ahb_access")]
        public string AhbAccessStr {
            get {
                return AhbAccess ? "" : null;
            }
            set {
                AhbAccess = value != null;
            }
        }

        public bool ShouldSerializeAhbAccessStr() {
            return AhbAccess;
        }

        [XmlArray("arguments"), XmlArrayItem("arg")]
        public string[] Arguments;
    }
}
