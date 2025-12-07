using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApiDotNet.Models
{
    /// <summary>
    /// Represents a user in the system. Includes basic properties and validation
    /// attributes to ensure that only valid data is accepted.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for the user. Generated server-side when creating
        /// new records.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user's name. Must be between 2 and 100 characters.
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address. Must be a valid email format.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Optional age of the user. Must be non-negative if provided.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int? Age { get; set; }
    }
}