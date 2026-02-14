using Microsoft.AspNetCore.Mvc;
using Supabase;
using System.Text.Json;
using GYMIND.API.DTOs;

namespace GYMIND.API.Controllers
{
    [ApiController]
    [Route("api/kpi")]
    public class KpiController : ControllerBase
    {
        private readonly Client _supabase;

        public KpiController(Client supabase)
        {
            _supabase = supabase;
        }

        [HttpPost("branch-traffic-now")]
        public async Task<IActionResult> BranchTrafficNow([FromBody] KpiBranchTrafficNowRequestDto req)
        {
            if (req == null || req.GymBranchId == Guid.Empty)
                return BadRequest(new { message = "GymBranchId is required." });

            try
            {
                // Call Supabase RPC function
                var rpc = await _supabase.Rpc(
                    "kpi_branch_traffic_now",
                    new { p_gymbranchid = req.GymBranchId }
                );

                // ✅ Deserialize the JSON payload returned by Supabase (NOT the response wrapper)
                var rows = JsonSerializer.Deserialize<List<KpiBranchTrafficNowRowDto>>(
                    rpc.Content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                ) ?? new List<KpiBranchTrafficNowRowDto>();

                if (rows.Count == 0)
                    return NotFound(new { message = "No traffic data found for this branch." });

                return Ok(rows[0]);
            }
            catch (Exception ex)
            {
                // Temporary debug response (remove detailed errors in production)
                return StatusCode(500, new
                {
                    message = "KPI RPC failed.",
                    error = ex.Message
                });
            }
        }
    }
}