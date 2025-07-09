using PaletYonetimDomain.Common;

namespace PaletYonetimDomain.Entities
{
    public class AuditLogEntity : BaseEntity
    {
        public int AuditLogID { get; set; }
        public string UserID { get; set; } // Kullanıcı kimliği
        public string UserName { get; set; } // Kullanıcı adı
        public string Action { get; set; } // CREATE, UPDATE, DELETE, VIEW
        public string EntityName { get; set; } // Pallet, Product, Customer, etc.
        public int EntityID { get; set; } // İlgili entity'nin ID'si
        public string OldValues { get; set; } // JSON formatında eski değerler
        public string NewValues { get; set; } // JSON formatında yeni değerler
        public string IPAddress { get; set; } // Kullanıcının IP adresi
        public string UserAgent { get; set; } // Tarayıcı bilgisi
        public string Description { get; set; } // İşlem açıklaması
        public bool IsSuccessful { get; set; } // İşlem başarılı mı?
        public string ErrorMessage { get; set; } // Hata mesajı (varsa)
    }
} 