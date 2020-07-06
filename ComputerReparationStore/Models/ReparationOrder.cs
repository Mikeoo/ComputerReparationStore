using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparationStore.Models
{
    public class ReparationOrder
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
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