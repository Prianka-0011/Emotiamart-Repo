namespace EmotiaMart.Domain.Entities;
public interface IAuditable
{
    DateTime? CreatedDate { get; set; }
    Guid? CreatedById { get; set; }
    DateTime? UpdatedDate { get; set; }
    Guid? UpdatedById { get; set; }
}