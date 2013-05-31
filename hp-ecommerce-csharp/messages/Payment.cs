using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HpEcommerce.messages
{
    [Serializable()]
    [XmlRootAttribute("payment")]
    public class Payment
    {
        [XmlElement("paymentGuid")]
        public string PaymentGuid { get; set; }
        [XmlElement("reason")]
        public string Reason { get; set; }
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
        public string CardAcceptorAddress { get; set; }
        [XmlElement("transNumber")]
        public string TransNumber { get; set; }
        [XmlElement("batchNumber")]
        public string BatchNumber { get; set; }
        [XmlElement("f25")]
        public string F25 { get; set; }

        public Payment() { }
    }

    [Serializable()]
    [XmlRootAttribute("payment")]
    public class PaymentRequest : FinancialRequest
    {
        [XmlElement("authorizationGuid")]
        public string AuthorizationGuid { get; set; }

        [XmlElement("paymentScenario")]
        public string PaymentScenario { get; set; }

        [XmlElement("currency")]
        public string Currency { get; set; }

        [XmlElement("amount")]
        public string Amount { get; set; }

        [XmlElement("token")]
        public string Token { get; set; }

        [XmlElement("cardNumber")]
        public string CardNumber { get; set; }

        [XmlElement("expiryDateMMYY")]
        public string ExpiryDateMMYY { get; set; }

        [XmlElement("cardVerificationCode")]
        public string CardVerificationCode { get; set; }

        [XmlElement("customerReference")]
        public string CustomerReference { get; set; }

        public PaymentRequest() { }

        public string getCurrency()
        {
            return Currency;
        }

        public string getAmount()
        {
            return Amount;
        }
        public string getPaymentScenario()
        {
            return PaymentScenario;
        }
    }
}
