using System;

namespace BluestarTech.Models {
    public class Area { public int AreaId {get;set;} public string Name {get;set;} }
    public class Role { public int RoleId {get;set;} public string Name {get;set;} }
    public class Staff { public int StaffId {get;set;} public string Name {get;set;} public int? AreaId {get;set;} public int? RoleId {get;set;} public bool IsActive {get;set;} }
    public class Customer { public int CustomerId {get;set;} public string Name {get;set;} public int? AreaId {get;set;} }
    public class Complaint {
        public int ComplaintId {get;set;}
        public int CustomerId {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public string Category {get;set;}
        public DateTime CreatedAt {get;set;}
        public string Status {get;set;}
        public int? AreaId {get;set;}
        public int? AssignedStaffId {get;set;}
        public DateTime? AssignedAt {get;set;}
    }
    public class AssignmentLog { public int LogId {get;set;} public int ComplaintId {get;set;} public int? StaffId {get;set;} public string Action {get;set;} public string? ByUser {get;set;} public DateTime CreatedAt {get;set;} }
}