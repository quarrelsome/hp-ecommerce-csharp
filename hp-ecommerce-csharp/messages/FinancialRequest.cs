using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HpEcommerce.messages
{
    interface FinancialRequest
    {
        string getCurrency();
        string getAmount();
        string getPaymentScenario();
    }
}
