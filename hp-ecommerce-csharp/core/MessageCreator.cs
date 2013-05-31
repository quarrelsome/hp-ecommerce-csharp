using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HpEcommerce.messages;
using HpEcommerce.exceptions;

namespace HpEcommerce.core
{
    public class MessageCreator
    {
        internal static AuthorizationRequest authorizationRequest(string paymentScenario, string currency, string amount,
                                                            string token, string cardNumber, string expiryDateMMYY,
                                                            string cardVerificationCode, string customerReference)
        {
            AuthorizationRequest authorizationRequest = new AuthorizationRequest();
            authorizationRequest.PaymentScenario = paymentScenario;
            authorizationRequest.Currency = currency;
            authorizationRequest.Amount = amount;
            authorizationRequest.Token = token;
            authorizationRequest.CardNumber = cardNumber;
            authorizationRequest.ExpiryDateMMYY = expiryDateMMYY;
            authorizationRequest.CardVerificationCode = cardVerificationCode;
            authorizationRequest.CustomerReference = customerReference;

            string validationErrors = validateAuthorizationRequest(authorizationRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }

            return authorizationRequest;
        }


        private static string validateAuthorizationRequest(AuthorizationRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            ValidateCommonFields(request, validationErrors);
            if (!hasValidAuthorizationCardData(request))
            {
                validationErrors.Append("Request has invalid card data. It must have either Card Number and Expiry date or Token");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

        private static bool hasValidAuthorizationCardData(AuthorizationRequest message)
        {
            return (message.CardNumber != null && message.ExpiryDateMMYY != null) || message.Token != null;
        }

        internal static PaymentRequest paymentRequest(string paymentScenario, string currency, string amount,
                                                    string token, string cardNumber, string expiryDateMMYY,
                                                    string cardVerificationCode, string customerReference, string authorizationGuid)
        {
            PaymentRequest paymentRequest = new PaymentRequest();
            paymentRequest.AuthorizationGuid = authorizationGuid;
            paymentRequest.PaymentScenario = paymentScenario;
            paymentRequest.Currency = currency;
            paymentRequest.Amount = amount;
            paymentRequest.Token = token;
            paymentRequest.CardNumber = cardNumber;
            paymentRequest.ExpiryDateMMYY = expiryDateMMYY;
            paymentRequest.CardVerificationCode = cardVerificationCode;
            paymentRequest.CustomerReference = customerReference;

            string validationErrors = validatePaymentRequest(paymentRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }

            return paymentRequest;
        }



        private static string validatePaymentRequest(PaymentRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            ValidateCommonFields(request, validationErrors);
            if (!isValidPaymentRequest(request))
            {
                validationErrors.Append("Request has invalid card data. It must have either Card Number and Expiry date or Token");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

        private static bool isValidPaymentRequest(PaymentRequest message)
        {
            return (message.CardNumber != null && message.ExpiryDateMMYY != null) || message.Token != null || message.AuthorizationGuid != null;
        }

        internal static RefundRequest refundRequest(string paymentScenario, string currency, string amount,
                                              string token, string cardNumber, string expiryDateMMYY,
                                              string cardVerificationCode, string customerReference, string paymentGuid)
        {
            RefundRequest refundRequest = new RefundRequest();
            refundRequest.PaymentGuid = paymentGuid;
            refundRequest.PaymentScenario = paymentScenario;
            refundRequest.Currency = currency;
            refundRequest.Amount = amount;
            refundRequest.Token = token;
            refundRequest.CardNumber = cardNumber;
            refundRequest.ExpiryDateMMYY = expiryDateMMYY;
            refundRequest.CustomerReference = customerReference;
            string validationErrors = validateRefundRequest(refundRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }

            return refundRequest;
        }

        private static string validateRefundRequest(RefundRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            ValidateCommonFields(request, validationErrors);
            if (!isValidRefundRequest(request))
            {
                validationErrors.Append("Request has invalid card data. It must have either Card Number and Expiry date or Token");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

        private static void ValidateCommonFields(FinancialRequest request, StringBuilder validationErrors)
        {
            if (request.getPaymentScenario() == null)
            {
                validationErrors.Append("PaymentScenario is required.\n");
            }
            if (request.getCurrency() == null)
            {
                validationErrors.Append("Currency is required.\n");
            }
            if (request.getAmount() == null)
            {
                validationErrors.Append("Amount is required.\n");
            }
        }

        private static bool isValidRefundRequest(RefundRequest message)
        {
            return (message.CardNumber != null && message.ExpiryDateMMYY != null) || message.Token != null || message.PaymentGuid != null;
        }

        internal static ReversalRequest reversalRequest(string authorizationGuid, string paymentGuid, string refundGuid, string cusomterReference)
        {
            ReversalRequest reversalRequest = new ReversalRequest();
            reversalRequest.AuthorizationGuid = authorizationGuid;
            reversalRequest.PaymentGuid = paymentGuid;
            reversalRequest.RefundGuid = refundGuid;
            reversalRequest.CustomerReference = cusomterReference;
            string validationErrors = validateReversalRequest(reversalRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }

            return reversalRequest;
        }



        private static string validateReversalRequest(ReversalRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (!isValidReversalRequest(request))
            {
                validationErrors.Append("Request has invalid data. It must have either authorization guid, payment guid or refund guid");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

        private static bool isValidReversalRequest(ReversalRequest message)
        {
            return message.AuthorizationGuid != null || message.PaymentGuid != null || message.RefundGuid != null;
        }

        internal static CancellationRequest cancellationRequest(string transactionType, string currency, string amount, string terminalDateTime)
        {
            CancellationRequest cancellationRequest = new CancellationRequest();
            cancellationRequest.Amount = amount;
            cancellationRequest.Currency = currency;
            cancellationRequest.TransactionType = transactionType;
            cancellationRequest.TerminalDateTime = terminalDateTime;

            string validationErrors = validateCancellationRequest(cancellationRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }
            return cancellationRequest;
        }

        private static string validateCancellationRequest(CancellationRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (request.Currency == null)
            {
                validationErrors.Append("Currency is required.\n");
            }
            if (request.Amount == null)
            {
                validationErrors.Append("Amount is required.\n");
            }
            if (request.TransactionType == null)
            {
                validationErrors.Append("Amount is required.\n");
            }

            if (request.TerminalDateTime == null)
            {
                validationErrors.Append("Amount is required.\n");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

        internal static TokenRequest tokenRequest(string cardNumber, string expiryDateMMYY)
        {
            TokenRequest tokenRequest = new TokenRequest();
            tokenRequest.CardNumber = cardNumber;
            tokenRequest.ExpiryDateMMYY = expiryDateMMYY;
            string validationErrors = validateTokenRequest(tokenRequest);
            if (validationErrors != null)
            {
                throw new HpECommerceException("Message failed validation \n" + validationErrors);
            }
            return tokenRequest;
        }

        private static string validateTokenRequest(TokenRequest request)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (request.CardNumber == null)
            {
                validationErrors.Append("CardNumber is required.\n");
            }
            if (request.ExpiryDateMMYY == null)
            {
                validationErrors.Append("ExpiryDateMMYY is required.\n");
            }

            if (validationErrors.Length == 0)
            {
                return null;
            }
            else
            {
                return validationErrors.ToString();
            }
        }

    }
}
