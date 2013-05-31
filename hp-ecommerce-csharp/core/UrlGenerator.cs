using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HpEcommerce.core
{
    class UrlGenerator
    {
        const string ECOMMERCE_PATH = "/web/";
        const string TOKENIZATION_PATH = "/tokenstore/";

        public static string getAuthorizationUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getECommerceBaseUrl(cardAcceptor, environment));
            builder.Append("/authorization/");
            return builder.ToString();
        }

        public static string getPaymentUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getECommerceBaseUrl(cardAcceptor, environment));
            builder.Append("/payment/");
            return builder.ToString();
        }

        public static string getRefundUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getECommerceBaseUrl(cardAcceptor, environment));
            builder.Append("/refund/");
            return builder.ToString();
        }

        public static string getReversalUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getECommerceBaseUrl(cardAcceptor, environment));
            builder.Append("/reversal/");
            return builder.ToString();
        }

        public static string getCancellationUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getECommerceBaseUrl(cardAcceptor, environment));
            builder.Append("/cancellation/");
            return builder.ToString();
        }

        public static string getTokenizationUrl(string cardAcceptor, string tokenName, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getTokenizationBaseUrl(cardAcceptor, environment));
            builder.Append("/");
            builder.Append(tokenName);
            builder.Append("/");
            return builder.ToString();
        }

        public static string getECommerceBaseUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            if (environment == HpEnvironment.LIVE)
            {
                builder.Append("https://ecommerce.handpoint.com");  // TODO Add live / test urls
            }
            else if (environment == HpEnvironment.TEST)
            {
                builder.Append("https://tweb34.handpoint.com");
            }
            builder.Append(ECOMMERCE_PATH);
            builder.Append(cardAcceptor);
            return builder.ToString();
        }

        public static string getTokenizationBaseUrl(string cardAcceptor, HpEnvironment environment)
        {
            StringBuilder builder = new StringBuilder();
            if (environment == HpEnvironment.LIVE)
            {
                builder.Append("https://ecommerce.handpoint.com");
            }
            else if (environment == HpEnvironment.TEST)
            {
                builder.Append("https://tweb34.handpoint.com");
            }
            builder.Append(TOKENIZATION_PATH);
            builder.Append(cardAcceptor);
            return builder.ToString();
        }
    }
}
