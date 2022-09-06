using System;
using System.Collections.Generic;
using System.Linq;

namespace Pools.Core.Models
{
    public abstract class Pool
    {
        protected const float HEIGHT = 1.5f;

        public string ReferenceNumber { get; set; }

        public string Suburb { get; set; }

        public DateTime InstallationDate { get; set; }

        public IEnumerable<Worker> AssignedWorkers { get; set; }

        public Pool(string referenceNumber, string suburb, DateTime installationDate, IEnumerable<Worker> assignedWorkers)
        {
            ReferenceNumber = referenceNumber;
            Suburb = suburb;
            InstallationDate = installationDate;
            AssignedWorkers = assignedWorkers;
        }

        public virtual float Volume { get; }
        public float MaterialCost
        {
            get => (float)Math.Round(1000 * Volume, 2);
        }

        public float LabourCost
        {
            get => (float)Math.Round(10 * Volume * AssignedWorkers.Count(), 2);
        }

        public float TotalCost
        {
            get => (float)Math.Round(MaterialCost + LabourCost, 2);
        }
    }
}
