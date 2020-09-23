﻿using System;
using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}