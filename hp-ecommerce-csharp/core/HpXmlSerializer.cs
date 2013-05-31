using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HpEcommerce.messages;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HpEcommerce.core
{
    class HpXmlSerializer
    {
        public static Authorization convertAuthorization(string message) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Authorization));
            return (Authorization) serializer.Deserialize(new StringReader(message));
        }

        public static Payment convertPayment(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Payment));
            return (Payment)serializer.Deserialize(new StringReader(message));
        }


        public static Refund convertRefund(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Refund));
            return (Refund)serializer.Deserialize(new StringReader(message));
        }

        public static Reversal convertReversal(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Reversal));
            return (Reversal)serializer.Deserialize(new StringReader(message));
        }

        public static Cancellation convertCancellation(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Cancellation));
            return (Cancellation)serializer.Deserialize(new StringReader(message));
        }

        public static Token convertToken(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Token));
            return (Token)serializer.Deserialize(new StringReader(message));
        }

        public static ErrorMessage convertErrorMessage(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessage));
            return (ErrorMessage) serializer.Deserialize(new StringReader(message));
        }

        public static string getMessage(Type type, Object obj)
        {
            StringWriter textWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(textWriter, obj);

            UTF8Encoding encoding = new UTF8Encoding();
            return textWriter.ToString();
        }


        public static XmlWriterSettings getXmlWriterSettings()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.CloseOutput = false;
            return settings;
        }
    }
}
