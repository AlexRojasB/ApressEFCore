using InventoryModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace InventoryModels
{
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel
    {
        public int Id { get; set; }
        [StringLength(InventoryModelsConstants.MAX_USERID_LENGTH)]
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
