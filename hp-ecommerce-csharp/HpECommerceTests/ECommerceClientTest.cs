using HpEcommerce.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HpEcommerce.messages;
using HpEcommerce.exceptions;

namespace HpECommerceTests
{


    /// <summary>
    ///This is a test class for ECommerceClientTest and is intended
    ///to contain all ECommerceClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ECommerceClientTest
    {

        // Test Environment
        const string SHARED_SECRET = "8F10C8AD35B7AEC11675B50DBF6ACEAA0B4EC280B92500E51A02F7BBBE7B07C6";
        const string CARD_ACCEPTOR = "7f6451e8314defbb50d0";

        const HpEnvironment TEST_ENVIRONMENT = HpEnvironment.TEST;

        // Note all test card numbers are retrieved from http://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm
        const string VISA_TEST_CARD = "4222222222222";
        const string MASTERCARD_TEST_CARD = "5105105105105100";
        const string AMERICAN_EXPRESS_TEST_CARD = "371449635398431";
        const string EXPIRY_DATE_DECEMBER_2015 = "1215";
        const string AMOUNT_70_APPROVE_AMOUNT = "70.00";
        const string AMOUNT_120_DECLINE_AMOUNT = "120.00";
        const string VISA_CARD_NAME = "VISA";
        const string AMERICAN_EXPRESS_CARD_NAME = "American Express";
        const string TEST_TOKEN_01 = "TEST_TOKEN_01";
        const string CURRENCY_ISK = "ISK";


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for reverseRefund
        ///</summary>
        [TestMethod()]
        public void reverseRefundTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Refund refund = client.refund(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Reversal reversal = client.reverseRefund(refund.RefundGuid);

            Assert.IsNotNull(reversal.ReversalGuid);
            Assert.AreEqual(refund.RefundGuid, reversal.RefundGuid);
            Assert.IsNotNull(reversal.ApprovalCode);
        }

        /// <summary>
        ///A test for reversePayment
        ///</summary>
        [TestMethod()]
        public void reversePaymentTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Payment payment = client.payment(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Reversal reversal = client.reversePayment(payment.PaymentGuid);

            Assert.IsNotNull(reversal.ReversalGuid);
            Assert.AreEqual(payment.PaymentGuid, reversal.PaymentGuid);
            Assert.IsNotNull(reversal.ApprovalCode);
        }

        /// <summary>
        ///A test for reverseAuthorization
        ///</summary>
        [TestMethod()]
        public void reverseAuthorizationTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Authorization authorization = client.authorize(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Reversal reversal = client.reverseAuthorization(authorization.AuthorizationGuid);

            Assert.IsNotNull(reversal.ReversalGuid);
            Assert.AreEqual(authorization.AuthorizationGuid, reversal.AuthorizationGuid);
            Assert.IsNotNull(reversal.ApprovalCode);
        }

        /// <summary>
        ///A test for refundWithToken
        ///</summary>
        [TestMethod()]
        public void refundWithTokenTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Refund refund = client.refundWithToken(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, getToken(client).TokenName);
            Assert.IsNotNull(refund.RefundGuid);
            Assert.IsNotNull(refund.ApprovalCode);
        }

        /// <summary>
        ///A test for refund
        ///</summary>
        [TestMethod()]
        public void refundTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Refund refund = client.refund(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);

            Assert.IsNotNull(refund.RefundGuid);
            Assert.IsNotNull(refund.ApprovalCode);
        }

        /// <summary>
        ///A test for paymentWithToken
        ///</summary>
        [TestMethod()]
        public void paymentWithTokenTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Payment payment = client.paymentWithToken(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, getToken(client).TokenName);

            Assert.IsNotNull(payment.PaymentGuid);
            Assert.IsNotNull(payment.ApprovalCode);
        }

        /// <summary>
        ///A test for payment
        ///</summary>
        [TestMethod()]
        public void paymentTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Payment payment = client.payment(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);

            Assert.IsNotNull(payment.PaymentGuid);
            Assert.IsNotNull(payment.ApprovalCode);
        }

        /// <summary>
        ///A test for captureAuthorization
        ///</summary>
        [TestMethod()]
        public void captureAuthorizationTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Authorization authorization = client.authorize(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Payment payment = client.captureAuthorization(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, authorization.AuthorizationGuid);

            Assert.IsNotNull(payment.PaymentGuid);
            Assert.IsNotNull(payment.ApprovalCode);
        }

        /// <summary>
        ///A test for cancelRefund
        ///</summary>
        [TestMethod()]
        public void cancelRefundTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Refund refund = client.refund(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Assert.IsNotNull(refund.RefundGuid);
            Assert.IsNotNull(refund.ApprovalCode);
            Cancellation cancellation = client.cancelRefund(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, refund.TerminalDateTime);
            Assert.IsNotNull(cancellation.CancellationGuid);
            Assert.IsNotNull(cancellation.RefundGuid);
            Assert.IsNotNull(cancellation.ApprovalCode);
        }

        /// <summary>
        ///A test for cancelPayment
        ///</summary>
        [TestMethod()]
        public void cancelPaymentTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Payment payment = client.payment(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Assert.IsNotNull(payment.PaymentGuid);
            Assert.IsNotNull(payment.ApprovalCode);
            Cancellation cancellation = client.cancelPayment(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, payment.TerminalDateTime);
            Assert.IsNotNull(cancellation.CancellationGuid);
            Assert.IsNotNull(cancellation.PaymentGuid);
            Assert.IsNotNull(cancellation.ApprovalCode);
        }

        /// <summary>
        ///A test for cancelAuthorization
        ///</summary>
        [TestMethod()]
        public void cancelAuthorizationTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Authorization authorization = client.authorize(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Assert.IsNotNull(authorization.AuthorizationGuid);
            Assert.IsNotNull(authorization.ApprovalCode);
            Cancellation cancellation = client.cancelAuthorization(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, authorization.TerminalDateTime);
            Assert.IsNotNull(cancellation.CancellationGuid);
            Assert.IsNotNull(cancellation.AuthorizationGuid);
            Assert.IsNotNull(cancellation.ApprovalCode);
        }

        /// <summary>
        ///A test for authorizeWithToken
        ///</summary>
        [TestMethod()]
        public void authorizeWithTokenTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Authorization authorization = client.authorizeWithToken(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, getToken(client).TokenName);
            Assert.IsNotNull(authorization.AuthorizationGuid);
            Assert.IsNotNull(authorization.ApprovalCode);
        }

        /// <summary>
        ///A test for authorize
        ///</summary>
        [TestMethod()]
        public void authorizeTest()
        {
            ECommerceClient client = new ECommerceClient(CARD_ACCEPTOR, SHARED_SECRET, TEST_ENVIRONMENT);
            Authorization authorization = client.authorize(CURRENCY_ISK, AMOUNT_70_APPROVE_AMOUNT, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            Assert.IsNotNull(authorization.AuthorizationGuid);
            Assert.IsNotNull(authorization.ApprovalCode);
        }

        private Token getToken(ECommerceClient client)
        {
            Token token = null;
            try
            {
                token = client.getToken(TEST_TOKEN_01);
            }
            catch (HpServerError e)
            {
                token = client.createToken(TEST_TOKEN_01, VISA_TEST_CARD, EXPIRY_DATE_DECEMBER_2015);
            }
            return token;
        }
    }
}
