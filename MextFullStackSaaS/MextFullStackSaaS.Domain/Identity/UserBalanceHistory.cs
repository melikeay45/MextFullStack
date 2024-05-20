using MextFullStackSaaS.Domain.Common;
using MextFullStackSaaS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaaS.Domain.Identity
{
    public class UserBalanceHistory:EntityBase<Guid>
    {
        public Guid UserBalanceId { get; set; }

        public UserBalance UserBalance { get; set; }

        public UserBalanceHistoryType Type { get; set; }

        public int Amount { get; set; }

        public int PreviousCredits { get; set; }

        public int CurentCredits { get; set; }

    }
}
