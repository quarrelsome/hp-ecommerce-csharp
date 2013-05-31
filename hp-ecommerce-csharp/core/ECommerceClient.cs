using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HpEcommerce.messages;
using HpEcommerce.exceptions;

namespace HpEcommerce.core
{
    public class ECommerceClient
    {
        const string AUTHORIZATION = "authorization";
        const string PAYMENT = "payment";
        const string REFUND = "refund";
        const string WEB_PAYMENT_SCENARIO = "WEB";
        public BixbyClient client;

        public ECommerceClient(string cardAcceptor, string sharedSecret, HpEnvironment environment)
        {
            client = new BixbyClient(cardAcceptor, sharedSecret, environment);
        }

        public Authorization authorize(string currency, string amount, string cardNumber, string expiryDateMMYY, string customerReference)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, null, customerReference);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorize(string currency, string amount, string cardNumber, string expiryDateMMYY)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, null, null);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorizeWithCvc(string currency, string amount, string cardNumber, string expiryDateMMYY, string cvc)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, cvc, null);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorizeWithCvc(string currency, string amount, string cardNumber, string expiryDateMMYY, string cvc, string customerReference)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, cvc, customerReference);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorizeWithToken(string currency, string amount, string token)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, null);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorizeWithToken(string currency, string amount, string token, string customerReference)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, customerReference);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }

        public Authorization authorizeAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token, string customerReference)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, customerReference);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }


        public Authorization authorizeAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token)
        {
            try
            {
                AuthorizationRequest request = MessageCreator.authorizationRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, null);
                return client.sendAuthorizationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Authorization failed", e);
            }
        }


        public Payment payment(string currency, string amount, string cardNumber, string expiryDateMMYY)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, null, null, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment payment(string currency, string amount, string cardNumber, string expiryDateMMYY, string customerReference)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, null, customerReference, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentWithCvc(string currency, string amount, string cardNumber, string expiryDateMMYY, string cardVerificationCode, string customerReference)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, cardVerificationCode, customerReference, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentWithCvc(string currency, string amount, string cardNumber, string expiryDateMMYY, string cardVerificationCode)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        cardNumber, expiryDateMMYY, cardVerificationCode, null, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentWithToken(string currency, string amount, string token)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, null, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentWithToken(string currency, string amount, string token, string customerReference)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, customerReference, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, null, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment paymentAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token, string customerReference)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, token,
                        null, null, null, customerReference, null);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Payment captureAuthorization(string currency, string amount, string authorizationGuid)
        {
            try
            {
                PaymentRequest request = MessageCreator.paymentRequest(WEB_PAYMENT_SCENARIO, currency, amount, null,
                        null, null, null, null, authorizationGuid);
                return client.sendPaymentRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Payment failed", e);
            }
        }

        public Refund refund(string currency, string amount, string cardNumber, string expiryDateMMYY, string customerReference)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount,
                                              null, cardNumber, expiryDateMMYY,
                                              null, customerReference, null); 
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refund(string currency, string amount, string cardNumber, string expiryDateMMYY)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount,
                                              null, cardNumber, expiryDateMMYY,
                                              null, null, null);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refundWithToken(string currency, string amount, string token, string customerReference)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount, token, null, null, null, customerReference, null);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refundWithToken(string currency, string amount, string token)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount, token, null, null, null, null, null);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refundAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token, string customerReference)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount, token, cardNumber, expiryDateMMYY, null, customerReference, null);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refundAndStoreToken(string currency, string amount, string cardNumber, string expiryDateMMYY, string token)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount, token, cardNumber, expiryDateMMYY, null, null, null);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Refund refundPayment(string currency, string amount, string paymentGuid)
        {
            try
            {
                RefundRequest request = MessageCreator.refundRequest(WEB_PAYMENT_SCENARIO, currency, amount, null, null, null, null, null, paymentGuid);
                return client.sendRefundRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Refund failed", e);
            }
        }

        public Reversal reverseAuthorization(string authorizationGuid)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(authorizationGuid, null, null, null);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Reversal reverseAuthorization(string authorizationGuid, string customerReference)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(authorizationGuid, null, null, customerReference);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Reversal reversePayment(string paymentGuid)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(null, paymentGuid, null, null);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Reversal reversePayment(string paymentGuid, string customerReference)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(null, paymentGuid, null, customerReference);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Reversal reverseRefund(string refundGuid)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(null, null, refundGuid, null);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Reversal reverseRefund(string refundGuid, string customerReference)
        {
            try
            {
                ReversalRequest request = MessageCreator.reversalRequest(null, null, refundGuid, customerReference);
                return client.sendReversalRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Reversal failed", e);
            }
        }

        public Cancellation cancelAuthorization(string currency, string amount, string terminalDateTimeOriginal)
        {
            try
            {
                CancellationRequest request = MessageCreator.cancellationRequest(AUTHORIZATION, currency, amount, terminalDateTimeOriginal);
                return client.sendCancellationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Cancellation failed", e);
            }
        }

        public Cancellation cancelPayment(string currency, string amount, string terminalDateTimeOriginal)
        {
            try
            {
                CancellationRequest request = MessageCreator.cancellationRequest(PAYMENT, currency, amount, terminalDateTimeOriginal);
                return client.sendCancellationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Cancellation failed", e);
            }
        }

        public Cancellation cancelRefund(string currency, string amount, string terminalDateTimeOriginal)
        {
            try
            {
                CancellationRequest request = MessageCreator.cancellationRequest(REFUND, currency, amount, terminalDateTimeOriginal);
                return client.sendCancellationRequest(request);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Cancellation failed", e);
            }
        }


        public Token createToken(string token, string cardNumber, string expiryDateMMYY)
        {
            try
            {
                TokenRequest request = MessageCreator.tokenRequest(cardNumber, expiryDateMMYY);
                return client.sendPutToken(request, token);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Failed creating token", e);
            }
        }

        public Token editToken(string token, string cardNumber, string expiryDateMMYY)
        {
            try
            {
                TokenRequest request = MessageCreator.tokenRequest(cardNumber, expiryDateMMYY);
                return client.sendPostToken(request, token);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Failed editing token", e);
            }
        }

        public Token getToken(string token)
        {
            try
            {
                return client.sendGetToken(token);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Failed editing token", e);
            }
        }

        public Token deleteToken(string token)
        {
            try
            {
                return client.sendGetToken(token);
            }
            catch (HpECommerceException e)
            {
                throw new HpECommerceException("Failed editing token", e);
            }
        }
    }
}
