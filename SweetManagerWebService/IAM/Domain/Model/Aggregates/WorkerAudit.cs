using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace SweetManagerWebService.IAM.Domain.Model.Aggregates;

public partial class Worker : IEntityWithCreatedUpdatedDate
{
    [NotMapped]
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [NotMapped]
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}