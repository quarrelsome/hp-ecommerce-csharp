using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HpEcommerce.messages;
using System.IO;
using HpEcommerce.exceptions;

namespace HpEcommerce.core
{
    public class BixbyClient
    {
        public string SharedSecret { get; set; }
        public string CardAcceptor { get; set; }
        public HpEnvironment Environment { get; set; }
        public HttpClient client { get; set; }


        public BixbyClient(string cardAcceptor, string sharedSecret, HpEnvironment environment)
        {
            SharedSecret = sharedSecret;
            Environment = environment;
            CardAcceptor = cardAcceptor;
            client = new HttpClient();
        }

        internal HpEcommerce.messages.Authorization sendAuthorizationRequest(AuthorizationRequest request)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getAuthorizationUrl(CardAcceptor, Environment), HpXmlSerializer.getMessage(typeof(AuthorizationRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return HpXmlSerializer.convertAuthorization(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("Authorization declined.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Payment sendPaymentRequest(PaymentRequest request)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getPaymentUrl(CardAcceptor, Environment), HpXmlSerializer.getMessage(typeof(PaymentRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return HpXmlSerializer.convertPayment(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("Payment declined.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Refund sendRefundRequest(RefundRequest request)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getRefundUrl(CardAcceptor, Environment), HpXmlSerializer.getMessage(typeof(RefundRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return HpXmlSerializer.convertRefund(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("Refund declined.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Reversal sendReversalRequest(ReversalRequest request)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getReversalUrl(CardAcceptor, Environment), HpXmlSerializer.getMessage(typeof(ReversalRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return HpXmlSerializer.convertReversal(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("Reversal declined.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Cancellation sendCancellationRequest(CancellationRequest request)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getCancellationUrl(CardAcceptor, Environment), HpXmlSerializer.getMessage(typeof(CancellationRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HpXmlSerializer.convertCancellation(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("Cancellation declined.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }


        internal HpEcommerce.messages.Token sendPutToken(TokenRequest request, string token)
        {
            HttpWebResponse response = client.sendPutRequest(UrlGenerator.getTokenizationUrl(CardAcceptor, token, Environment), HpXmlSerializer.getMessage(typeof(TokenRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return HpXmlSerializer.convertToken(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("PUT (create) token failed.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Token sendPostToken(TokenRequest request, string token)
        {
            HttpWebResponse response = client.sendPostRequest(UrlGenerator.getTokenizationUrl(CardAcceptor, token, Environment), HpXmlSerializer.getMessage(typeof(TokenRequest), request), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HpXmlSerializer.convertToken(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("POST (edit) token failed.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Token sendGetToken(string token)
        {
            HttpWebResponse response = client.sendGetRequest(UrlGenerator.getTokenizationUrl(CardAcceptor, token, Environment), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HpXmlSerializer.convertToken(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("GET Token failed.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        internal HpEcommerce.messages.Token sendDelete(string token)
        {
            HttpWebResponse response = client.sendDeleteRequest(UrlGenerator.getTokenizationUrl(CardAcceptor, token, Environment), SharedSecret);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HpXmlSerializer.convertToken(getResponsestring(response));
            }
            else
            {
                throw new HpServerError("DELETE token failed.", HpXmlSerializer.convertErrorMessage(getResponsestring(response)));
            }
        }

        private string getResponsestring(HttpWebResponse response)
        {
            var responseValue = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
            }
            return responseValue;
        }
    }
}
