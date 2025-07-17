
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportProductMVC.Models;

public partial class Product
{
    public int ProductID { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
    [Display(Name = "Tên sản phẩm")]
    public string? NamePro { get; set; }

    [StringLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự")]
    [Display(Name = "Mô tả")]
    public string? DecriptionPro { get; set; }

    [Required(ErrorMessage = "Danh mục không được để trống")]
    [Display(Name = "Danh mục")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(0, 1000000000, ErrorMessage = "Giá phải từ 0 đến 1 tỷ")]
    [Display(Name = "Giá")]
    public decimal? Price { get; set; }

    [Display(Name = "Ảnh sản phẩm")]
    public string? ImagePro { get; set; }

    [Required(ErrorMessage = "Ngày sản xuất không được để trống")]
    [Display(Name = "Ngày sản xuất")]
    public DateOnly ManufacturingDate { get; set; }
}
