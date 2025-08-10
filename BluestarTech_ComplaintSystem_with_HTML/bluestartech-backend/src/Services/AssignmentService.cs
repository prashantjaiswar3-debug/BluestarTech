using Microsoft.EntityFrameworkCore;
using BluestarTech.Data;
using BluestarTech.Models;

namespace BluestarTech.Services {
    public interface IAssignmentService {
        Task<Staff?> GetBestStaffAsync(int? areaId, int? roleId);
        Task AssignComplaintAsync(int complaintId, int staffId, string? byUser = null);
    }

    public class AssignmentService : IAssignmentService {
        private readonly AppDbContext _db;
        public AssignmentService(AppDbContext db) { _db = db; }

        public async Task<Staff?> GetBestStaffAsync(int? areaId, int? roleId) {
            var query = _db.Staff.Where(s => s.IsActive);
            if (areaId.HasValue) query = query.Where(s => s.AreaId == areaId);
            if (roleId.HasValue) query = query.Where(s => s.RoleId == roleId);

            var staffLoad = await query
                .Select(s => new {
                    Staff = s,
                    OpenCount = _db.Complaints.Count(c => c.AssignedStaffId == s.StaffId && (c.Status == "Assigned" || c.Status == "InProgress"))
                })
                .OrderBy(x => x.OpenCount)
                .ThenBy(x => x.Staff.StaffId)
                .FirstOrDefaultAsync();

            return staffLoad?.Staff;
        }

        public async Task AssignComplaintAsync(int complaintId, int staffId, string? byUser = null) {
            var complaint = await _db.Complaints.FindAsync(complaintId);
            if (complaint == null) throw new Exception("Complaint not found.");

            complaint.AssignedStaffId = staffId;
            complaint.AssignedAt = DateTime.UtcNow;
            complaint.Status = "Assigned";

            _db.AssignmentLogs.Add(new AssignmentLog {
                ComplaintId = complaintId,
                StaffId = staffId,
                Action = "Assigned",
                ByUser = byUser,
                CreatedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
        }
    }
}