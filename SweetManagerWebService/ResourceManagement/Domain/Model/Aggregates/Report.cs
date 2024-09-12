using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.ResourceManagement.Domain.Model.Entities;

namespace SweetManagerWebService.ResourceManagement.Domain.Model.Aggregates
{
    public partial class Report
    {
        public int Id { get; }
        public int TypesReportsId { get; set; }
        public int AdminsId { get; set; }
        public int WorkersId { get; set; }
        public string FileUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual Admin Admin { get; } = null!;
        public virtual TypeReport TypeReport { get; } = null!;
        public virtual Worker Worker { get; } = null!;
    }
}