using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id;
    }
    
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}