using MextFullStack.Domain.Common;


namespace MextFullStack.Domain.Entities
{

    //string referans tür olduğu için burda entitybase deki struct kısıtlamasından dolayı hata veriyor.
    public class Customer:EntityBase<string>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedOn { get; set; }

        public Customer()
        {
            CreatedOn = DateTime.Now;

            Id = Guid.NewGuid().ToString();
        }
    }
}
