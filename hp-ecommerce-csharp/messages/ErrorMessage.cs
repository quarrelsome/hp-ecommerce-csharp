using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HpEcommerce.messages
{
    [Serializable()]
    [XmlRootAttribute("error")]
    public class ErrorMessage
    {
        [XmlElement("reason")]
        public string Reason { get; set; }

        [XmlArray("details")]
        [XmlArrayItem("detail", typeof(string))]
        public string[] Details { get; set; }

        public ErrorMessage()
        {
        }

        public ErrorMessage(string reason, string[] details)
        {
            Reason = reason;
            Details = details;
        }

        public List<string> getDetails()
        {
            return Details.ToList();
        }
    }
}
