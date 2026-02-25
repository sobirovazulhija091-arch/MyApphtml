public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public string? Description { get; set; }=null!;
    
    // public int? ParentCategoryId { get; set; }
}