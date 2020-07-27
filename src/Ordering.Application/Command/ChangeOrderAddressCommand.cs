﻿using System;
using MSFramework.Application;
using Ordering.Domain.AggregateRoot;

namespace Ordering.Application.Command
{
	public class ChangeOrderAddressCommand : IRequest
	{
		public Address NewAddress { get; set; }
		
		public Guid OrderId { get; set; }
    }
}
