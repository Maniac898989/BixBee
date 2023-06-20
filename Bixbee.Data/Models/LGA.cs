using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class LGA
{
    public long Id { get; set; }

    public long? StateID { get; set; }

    public string StateCode { get; set; }

    public string Town { get; set; }

    public virtual State State { get; set; }
}
