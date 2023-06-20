using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class State
{
    public long Id { get; set; }

    public string Code { get; set; }

    public string State1 { get; set; }

    public string Capital { get; set; }

    public string Latitude { get; set; }

    public string Longtitude { get; set; }

    public virtual ICollection<LGA> LGAs { get; set; } = new List<LGA>();
}
