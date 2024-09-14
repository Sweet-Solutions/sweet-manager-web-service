using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace SweetManagerWebService.IAM.Domain.Model.Entities.Assignments;

public partial class AssignmentWorker : IEntityWithCreatedUpdatedDate
{
    [NotMapped]
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [NotMapped]
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}