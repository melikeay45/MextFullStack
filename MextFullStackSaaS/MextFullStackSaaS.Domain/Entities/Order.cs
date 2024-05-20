using MextFullStackSaaS.Domain.Common;
using MextFullStackSaaS.Domain.Enums;
using MextFullStackSaaS.Domain.Identity;

namespace MextFullStackSaaS.Domain.Entities
{
    public class Order:EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model{ get; set; }
        public DesignType DesignType { get; set; }
        public int Quantity{ get; set; }
    }
}
