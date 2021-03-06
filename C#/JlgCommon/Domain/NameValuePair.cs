﻿using System;

namespace JlgCommon.Domain
{
    public class NameValuePair<TName, TValue> 
    {
        public virtual Guid Id { get; set; }
        public virtual TName Name { get; set; }
        public virtual TValue Value { get; set; }
        public virtual Guid? OwnerId { get; set; }

        public NameValuePair()
        {
            Id = Guid.NewGuid();
        }

        public NameValuePair(TName name, TValue value)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
        }

        public NameValuePair(TName name, TValue value, Guid ownerId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
            OwnerId = ownerId;
        }
    }
}
