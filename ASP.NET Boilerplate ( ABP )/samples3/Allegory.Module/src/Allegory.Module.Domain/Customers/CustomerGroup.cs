using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;


namespace Allegory.Module.Customers
{
    public class CustomerGroup: AggregateRoot<Guid>
    {
        public virtual string Code { get; protected set; }
        public virtual string Description { get; protected set; }

        public CustomerGroup()
        {
            
        }

        internal CustomerGroup(
            Guid id,
            string code,
            string description = default):base(id)
        {
            SetCode(code);
            SetDescription(description);
        }
       
        internal virtual void SetCode(string code) 
        {
            Check.NotNullOrWhiteSpace(code, nameof(Code), CustomerGroupConstants.MaxCodeLength);
            Code = code;
        }

        public virtual void SetDescription(string description)
        {
            Check.Length(description, nameof(Description), CustomerGroupConstants.MaxDescriptionLength);
            Description = description;
        }
    }
}
