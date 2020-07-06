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
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Eind Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
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