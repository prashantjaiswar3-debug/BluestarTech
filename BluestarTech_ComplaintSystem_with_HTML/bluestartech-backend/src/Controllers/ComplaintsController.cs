using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BluestarTech.Data;
using BluestarTech.Models;
using BluestarTech.Services;

[ApiController]
[Route("api/complaints")]
public class ComplaintsController : ControllerBase {
    private readonly AppDbContext _db;
    private readonly IAssignmentService _assigner;
    public ComplaintsController(AppDbContext db, IAssignmentService assigner) { _db = db; _assigner = assigner; }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Complaint dto) {
        dto.CreatedAt = DateTime.UtcNow;
        dto.Status = "New";
        _db.Complaints.Add(dto);
        await _db.SaveChangesAsync();

        var best = await _assigner.GetBestStaffAsync(dto.AreaId, null);
        if (best != null) await _assigner.AssignComplaintAsync(dto.ComplaintId, best.StaffId, "System");

        return CreatedAtAction(nameof(Get), new { id = dto.ComplaintId }, dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var c = await _db.Complaints.FindAsync(id);
        if (c == null) return NotFound();
        return Ok(c);
    }

    [HttpPost("{id}/assign/{staffId}")]
    public async Task<IActionResult> Assign(int id, int staffId) {
        await _assigner.AssignComplaintAsync(id, staffId, User?.Identity?.Name ?? "Manual");
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] int? assignedStaffId) {
        var q = _db.Complaints.AsQueryable();
        if (assignedStaffId.HasValue) q = q.Where(c => c.AssignedStaffId == assignedStaffId.Value);
        return Ok(await q.OrderByDescending(c=>c.CreatedAt).Take(200).ToListAsync());
    }
}