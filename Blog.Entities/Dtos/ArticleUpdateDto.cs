using Blog.Entities.Concrete;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MinLength(20, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string Content { get; set; }
        [DisplayName("Thumbanil")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string Thumbnail { get; set; }
        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MaxLength(150, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string SeoAuthor { get; set; }
        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır.")]
        public string SeoTags { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilememelidir.")]
        public bool IsDeleted { get; set; }
    }
}
