using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Products;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
public class Review
{
    public string UserId { get; set; }
    public string ProductId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}