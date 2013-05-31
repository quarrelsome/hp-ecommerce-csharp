using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HpEcommerce.messages
{
    [Serializable()]
    [XmlRootAttribute("reversal")]
    public class Reversal
    {
        [XmlElement("reversalGuid")]
        public string ReversalGuid { get; set; }
        [XmlElement("refundGuid")]
        public string RefundGuid { get; set; }
        [XmlElement("paymentGuid")]
        public string PaymentGuid { get; set; }
        [XmlElement("authorizationGuid")]
        public string AuthorizationGuid { get; set; }
        [XmlElement("amount")]
        public string Amount { get; set; }
        [XmlElement("currency")]
        public string Currency { get; set; }
        [XmlElement("cardTypeName")]
        public string CardTypeName { get; set; }
        [XmlElement("maskedCardNumber")]
        public string MaskedCardNumber { get; set; }
        [XmlElement("expiryDateMMYY")]
        public string ExpiryDateMMYY { get; set; }
        [XmlElement("customerReference")]
        public string CustomerReference { get; set; }
        [XmlElement("approvalCode")]
        public string ApprovalCode { get; set; }
        [XmlElement("issuerResponseText")]
        public string IssuerResponseText { get; set; }
        [XmlElement("serverDateTime")]
        public string ServerDateTime { get; set; }
        [XmlElement("terminalDateTime")]
        public string TerminalDateTime { get; set; }
        [XmlElement("agreementNumber")]
        public string AgreementNumber { get; set; }
        [XmlElement("cardAcceptorName")]
        public string CardAcceptorName { get; set; }
        [XmlElement("cardAcceptorAddress")]
        public string CardAcceptorAddress;

        public Reversal() { }
    }

    [Serializable()]
    [XmlRootAttribute("reversal")]
    public class ReversalRequest
    {
        [XmlElement("paymentGuid")]
        public string PaymentGuid { get; set; }
        [XmlElement("authorizationGuid")]
        public string AuthorizationGuid { get; set; }
        [XmlElement("refundGuid")]
        public string RefundGuid { get; set; }
        [XmlElement("customerReference")]
        public string CustomerReference { get; set; }

        public ReversalRequest() { }
    }
}
