using System;
namespace CA.Domain.Constants
{
    public class SalaryRate
    {
        public class Contract
        {
            public const decimal Rate = 500;
            public const decimal Tax = 0;
        }

        public class Regular
        {
            public const decimal Rate = 20000;
            public const decimal Tax = 12;
        }
    }
}
