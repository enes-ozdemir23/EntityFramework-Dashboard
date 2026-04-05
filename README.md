# 📊 EntityFramework DashBoard

ASP.NET Core ve Entity Framework Core kullanılarak 70+ LINQ ve EF Core metodunun uygulamalı olarak ele alındığı kapsamlı bir proje serisidir.
---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Backend | ASP.NET Core, C# |
| ORM | Entity Framework Core, LINQ |
| Veritabanı | MSSQL |
| Mimari | Repository Design Pattern, Unit of Work |
| Frontend | HTML, CSS, Bootstrap, JavaScript, Ajax |
| Görselleştirme | Dashboard, Chart |


---

## 📚 Kapsanan Konular

### Entity Framework Core
- ✅ Code First yaklaşımı ve Migration yönetimi
- ✅ İlişkili tablolar
- ✅ Repository Design Pattern
- ✅ Unit of Work implementasyonu
- ✅ Performanslı sorgu yazma teknikleri
- ✅ View tarafında EF Core kullanımı

### LINQ (70+ Metod)
- ✅ Filtreleme: `Where`, `Find`, `FirstOrDefault`, `SingleOrDefault`
- ✅ Sıralama: `OrderBy`, `OrderByDescending`, `ThenBy`
- ✅ Gruplama: `GroupBy`, `GroupJoin`
- ✅ Dönüştürme: `Select`, `SelectMany`
- ✅ Birleştirme: `Join`, `Concat`, `Union`
- ✅ Sayısal: `Count`, `Sum`, `Average`, `Min`, `Max`
- ✅ Dinamik filtreleme ve sorgu zincirleme
- ✅ Optimize sorgu yazma teknikleri

---

## 🛠️ Kurulum

```bash
# 1. Repoyu klonla
git clone https://github.com/enesozdemir23/EFCoreMasterclass.git

# 2. appsettings.json bağlantı dizesini düzenle
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EFCoreDb;Trusted_Connection=True;"
}

# 3. Migration uygula
dotnet ef database update

# 4. Uygulamayı çalıştır
dotnet run
```

---

## 👤 Geliştirici

**Enes Özdemir**  
📧 ozdemir.enes2323@gmail.com  
(https://github.com/enes-ozdemir23)
