using System;
using System.ComponentModel.DataAnnotations.Schema;
using product.Data;

public class ChangedEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }

    public string CreaterId { get; set; }
    
}