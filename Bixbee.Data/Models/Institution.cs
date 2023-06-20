using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class Institution
{
    public long Id { get; set; }

    public string StateCode { get; set; }

    public string University { get; set; }

    public int? TypeID { get; set; }

    public int? CategoryID { get; set; }

    public virtual InstitutionCategory Category { get; set; }

    public virtual InstitutionType Type { get; set; }
}
