using System;
using System.Collections.Generic;

namespace Pools.Core.Models
{
    public class RectanglePool : SquarePool
    {
        //private const float HEIGHT = 1.5f;

        //public float Length { get; set; }

        public float Width { get; set; }

        public RectanglePool(string referenceNumber, string suburb, DateTime installationDate, float length, float width, IEnumerable<Worker> employees)
            : base(referenceNumber, suburb, installationDate, length, employees)
        {
            Length = length;
            Width = width;
        }

        public override float Volume
        {
            get => Length * Width * HEIGHT;
        }
    }
}
