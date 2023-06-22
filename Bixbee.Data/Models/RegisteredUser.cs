using System;
using System.Collections.Generic;

namespace Bixbee.Data.Models;

public partial class RegisteredUser
{
    public long ID { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string PhoneNo { get; set; }

    public string Email { get; set; }

    public bool? ActivationStatus { get; set; }

    public DateTime? LastAccess { get; set; }

    public bool? IsLocked { get; set; }

    public byte[] Password { get; set; }

    public DateTime? DateCreated { get; set; }
}
