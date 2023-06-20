using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class InstitutionCategory
{
    public int Id { get; set; }

    public string Category { get; set; }

    public virtual ICollection<Institution> Institutions { get; set; } = new List<Institution>();
}
