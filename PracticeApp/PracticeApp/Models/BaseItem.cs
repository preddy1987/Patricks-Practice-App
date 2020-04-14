using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    public abstract class BaseItem
    {
        public Guid? Id { get; set; }

        public BaseItem()
        {
            if(!Id.HasValue)
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
