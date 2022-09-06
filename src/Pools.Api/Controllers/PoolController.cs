using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pools.Core.Models;
using Pools.Core.Services;
using System.Linq;
using System;

namespace Pools.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoolController : ControllerBase
    {
        private readonly IPoolService _poolService;

        public PoolController(IPoolService poolService)
        {
            _poolService = poolService;
        }

        [HttpGet("")]
        public IEnumerable<Pool> GetAll()
        {
            IEnumerable<Pool> pools = _poolService.GetAll();
            return pools.OrderBy(p => p.Suburb).ThenBy(p => p.InstallationDate);
        }

        [HttpGet("gettotalcost")]
        public float GetTotalCost()
        {
            float totalCosts = 0;
            IEnumerable<Pool> pools = _poolService.GetAll();
            foreach (var pool in pools)
            {
                totalCosts += pool.TotalCost;
            }
            return (float)Math.Round(totalCosts, 2);
        }
    }
}
