using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerReparationStore.Models
{
    
    public class ReparationOrder
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [Display(Name = "Planned Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }

    [NotMapped]
    public class ReparationOrderVM
    {
        public ReparationOrder ReparationOrder { get; set; }
        public int AmountClosed { get; set; }

    }

    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public enum Status
    {
        Awaiting,
        Processing,
        AwaitingParts,
        ReparationDone,
        WaitingForPickup,
        Closed
    }
}