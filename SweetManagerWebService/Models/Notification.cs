namespace SweetManagerWebService.Models
{
    public partial class Notification
    {
        public int Id { get; }
        public int TypesNotificationsId { get; set; }
        public int? OwnersId { get; set; }
        public int? AdminsId { get; set; }
        public int? WorkersId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual Admin? Admin { get; }
        public virtual Owner? Owner { get; }
        public virtual TypeNotification TypeNotification { get; } = null!;
        public virtual Worker? Worker { get; }
    }
}