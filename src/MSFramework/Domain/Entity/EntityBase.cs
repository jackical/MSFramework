﻿using System;
using System.Collections.Generic;
using System.Reflection;
using MSFramework.Domain.Event;

namespace MSFramework.Domain.Entity
{
	/// <inheritdoc/>
	[Serializable]
	public abstract class EntityBase : IEntity
	{
		private List<IEvent> _domainEvents;

		public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents?.AsReadOnly();

		public void AddDomainEvent(IEvent @event)
		{
			_domainEvents ??= new List<IEvent>();
			_domainEvents.Add(@event);
		}

		public void RemoveDomainEvent(IEvent @event)
		{
			_domainEvents?.Remove(@event);
		}

		public void ClearDomainEvents() => _domainEvents?.Clear();

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[ENTITY: {GetType().Name}] Keys = {string.Join(", ", GetKeys())}";
		}

		public abstract object[] GetKeys();
	}

	/// <inheritdoc cref="IEntity{TKey}" />
	[Serializable]
	public abstract class EntityBase<TKey> : EntityBase, IEntity<TKey>
	{
		/// <inheritdoc/>
		public virtual TKey Id { get; protected set; }

		protected EntityBase()
		{
		}

		protected EntityBase(TKey id)
		{
			// ReSharper disable once VirtualMemberCallInConstructor
			Id = id;
		}


		public bool IsTransient()
		{
			return Id.Equals(default);
		}

		public bool EntityEquals(object obj)
		{
			if (obj == null || !(obj is EntityBase<TKey>))
			{
				return false;
			}

			//Same instances must be considered as equal
			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			//Transient objects are not considered as equal
			var other = (EntityBase<TKey>) obj;
			if (EntityHelper.HasDefaultId(this) && EntityHelper.HasDefaultId(other))
			{
				return false;
			}

			//Must have a IS-A relation of types or must be same type
			var typeOfThis = GetType().GetTypeInfo();
			var typeOfOther = other.GetType().GetTypeInfo();
			if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
			{
				return false;
			}

			// todo:
			// //Different tenants may have an entity with same Id.
			// if (this is IMultiTenant && other is IMultiTenant &&
			//     this.As<IMultiTenant>().TenantId != other.As<IMultiTenant>().TenantId)
			// {
			// 	return false;
			// }

			return Id.Equals(other.Id);
		}

		public override object[] GetKeys()
		{
			return new object[] {Id};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[ENTITY: {GetType().Name}] Id = {Id}";
		}
	}
}