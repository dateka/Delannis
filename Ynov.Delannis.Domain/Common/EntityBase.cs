using System;

namespace Ynov.Delannis.Domain.Common
{
    public class EntityBase
    {
        public string Id { get; private set; }
        public EntityBase() => Id = Guid.NewGuid().ToString();
    }
}