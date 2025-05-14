using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
    public class Log : Entity
    {
        [Key]
        public int ID { get; set; }
        public string? MachineName { get; set; }
        public DateTime Logged { get; set; }
        public string? Level { get; set; }  // Error, Warning, Info, Debug, Critical
        public string? Message { get; set; }
        public string? Logger { get; set; }
        public string? Properties { get; set; }
        public string? Callsite { get; set; }
        public string? Exception { get; set; }
        
        // Extended fields for better logging
        public string? LogType { get; set; }  // Error, UserAction, SystemAction, Security
        public int? UserId { get; set; }      // User who performed the action
        public string? Username { get; set; } // Username for quick reference
        public string? ActionName { get; set; } // What action was performed
        public string? EntityName { get; set; } // What entity was affected
        public int? EntityId { get; set; }    // ID of the entity affected
        public string? IPAddress { get; set; } // IP Address for security logging
        public string? RequestInfo { get; set; } // Additional request information
        public bool IsSuccess { get; set; }   // Whether the action was successful
    }
}