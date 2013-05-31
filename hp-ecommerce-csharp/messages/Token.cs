using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HpEcommerce.messages
{
    [Serializable()]
    [XmlRootAttribute("tokenStore")]
    public class Token
    {
        [XmlElement("token")]
        public string TokenName { get; set; }
        [XmlElement("maskedCardNumber")]
        public string MaskedCardNumber { get; set; }
        [XmlElement("expiryDateMMYY")]
        public string ExpiryDateMMYY { get; set; }
        [XmlElement("cardTypeName")]
        public string CardTypeName { get; set; }

        public Token() { }
    }

    [Serializable()]
    [XmlRootAttribute("tokenStore")]
    public class TokenRequest
    {
        [XmlElement("cardNumber")]
        public string CardNumber { get; set; }

        [XmlElement("expiryDateMMYY")]
        public string ExpiryDateMMYY { get; set; }

        public TokenRequest() { }
    }
}
