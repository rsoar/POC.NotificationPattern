using NotificationPatternSample.Domain.Validators;

namespace NotificationPatternSample.Domain.Entities
{
    public class Customer : BaseEntity
    {
        protected Customer() { }

        public Customer(string name)
        {
            Name = name;

            Validate(this, new CustomerValidator());
        }

        public string Name { get; set; }
    }
}
