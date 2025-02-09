
# Palet Yönetim Sistemi

## Proje Tanımı
Bu proje, paletlerin, müşteri ilişkilerinin ve stok hareketlerinin yönetildiği bir sistemdir. Clean Architecture prensipleri ve CQRS yapısı kullanılarak geliştirilmiştir. Proje, kullanıcıların paletler, müşteriler ve diğer ilgili varlıklar üzerinde CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirmelerini sağlar.

---

## Özellikler
- **Müşteri Yönetimi**: Müşteri ekleme, listeleme, güncelleme ve silme işlemleri.
- **Palet Yönetimi**:
  - Paletlerin dinamik numaralandırılması.
  - Paletlere müşteri ve raf bağlantısı.
- **Raf Yönetimi**: Rafların oluşturulması ve yönetilmesi.
- **Prefix Yönetimi**: Tüm paletlerin ortak prefix değerini dinamik olarak değiştirme ve yönetme.
- **Otomatik Tarih Yönetimi**:
  - CreatedTime ve UpdatedTime alanlarının dinamik olarak yönetimi.
- **Seed Data**:
  - İlk kurulumda başlangıç verilerinin otomatik olarak eklenmesi.
- **Swagger UI**: API'nin test edilmesi için kullanıcı dostu bir arayüz.

---

## Kullanılan Teknolojiler
- **Backend**: .NET Core (C#), Entity Framework Core
- **CQRS**: MediatR kullanılarak komut ve sorgu işlemleri ayrıştırıldı.
- **Veritabanı**: SQL Server
- **Clean Architecture**: Proje, katmanlı mimariye uygun şekilde Domain, Application, Infrastructure ve API katmanlarına ayrılmıştır.
- **Dokümantasyon**: Swagger kullanılarak API belgeleri oluşturuldu.
- **Kullanıcı Yönetimi**:ASP.Net Identity

---

## Kurulum Talimatları
1. Projeyi klonlayın:
   ```sh
   git clone <repository-url>
   ```
2. Projeyi açın ve `appsettings.json` dosyasını düzenleyerek SQL Server bağlantı ayarlarını yapın:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=<server>;Database=PaletYonetimDB;Trusted_Connection=True;"
     }
   }
   ```
3. Projeyi çalıştırmadan önce aşağıdaki komutları kullanarak bağımlılıkları yükleyin:
   ```sh
   dotnet restore
   ```
4. Projeyi başlatın:
   ```sh
   dotnet run
   ```
5. Swagger arayüzüne erişmek için tarayıcıda şu adresi açın:
   ```
   http://localhost:6001/swagger
   ```

---

## Şu Ana Kadar Yapılanlar
### 1. Entity’ler ve CRUD İşlemleri
- Customer, Rack, Pallet, Category, Product, Representative, StockMovement, Transaction entitiyleri için CRUD işlemleri tamamlandı.

### 2. CQRS Yapısı
- MediatR kullanılarak komut ve sorgu işlemleri ayrı katmanlar halinde yapılandırıldı.

### 3. BaseEntity
- CreatedTime ve UpdatedTime alanlarını içeren bir BaseEntity sınıfı oluşturuldu ve tüm varlıklar bu sınıftan türetildi.

### 4. Prefix Yönetimi
- Palet numaralarının dinamik bir prefix değeriyle başlaması sağlandı.
- Prefix değerini merkezi bir yerden yönetmek için ConfigurationSetting tablosu ve PrefixService oluşturuldu.

### 5. Seed Data
- SeedData sınıfı kullanılarak başlangıç verileri eklendi.

---

## Şu Anki Durum
- **Tamamlanan Entity’ler**: Customer, Rack, Pallet, Category, Product, Representative, StockMovement, Transaction 
- **Tamamlanan İşlemler**: CRUD işlemleri, Prefix Yönetimi, Tarih Yönetimi, Validation işlemleri, ASP.Net Identity

---

## Sonraki Adımlar
- Vue.js ile frontend uygulamaları.
- Daha detaylı loglama ve hata yönetimi.
  

---

## Ekran Görüntüleri
### ![image](https://github.com/user-attachments/assets/f8dc13b3-a306-4650-b27e-1e6c46e16e21)
### ![image](https://github.com/user-attachments/assets/8e122367-8750-48a1-9de3-fe236e5714e7)


---

## Katkıda Bulunma
Eğer projeye katkıda bulunmak isterseniz, lütfen bir Pull Request açmadan önce bir Issue oluşturun. Katkılarınızdan memnuniyet duyarım!
