using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class InstitutionType
{
    public int ID { get; set; }

    public string Type { get; set; }

    public virtual ICollection<Institution> Institutions { get; set; } = new List<Institution>();
}
