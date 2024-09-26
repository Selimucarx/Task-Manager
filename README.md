## TASK MANAGER

**Bu web uygulaması, kullanıcıların kişisel görevlerini yönetmelerine olanak tanır. Kullanıcılar, günlük, haftalık veya aylık periyotlarla kendilerine özel görevler oluşturabilir ve bu görevleri ihtiyaçlarına göre silebilirler. Ayrıca, uygulama üzerinden kullanıcı kaydı, giriş ve çıkış işlemleri gerçekleştirilebilir. JWT tabanlı kimlik doğrulama sistemi ile güvenli bir oturum yönetimi sağlanmıştır.**


## Yaptıklarım:

- **Rolleri Enum Olarak Tutmak:** Şu an sadece tek bir rol olmasına rağmen, ileride yeni rollerin eklenebilmesi için rolleri `enum` yapısıyla yönetilebilir ve genişletilebilir hale getirdim.
- **Esnek ve Yönetilebilir Hata Mesajları:** Hata mesajlarını `enum` yapısında tutarak, daha esnek ve yönetilebilir bir hata yönetim sistemi oluşturdum.
- **ID Güvenliği için GUID Kullanmak:** ID'lerin güvenliğini artırmak için veritabanında `GUID` kullanarak daha güvenilir bir yapı sağladım.
- **Parola Güvenliği:** Kullanıcı parolalarının güvenliğini sağlamak amacıyla parola hashleme işlemi uyguladım.
- **Enum Verilerinin Anlaşılır Olması:** Veritabanındaki `enum` verilerini daha anlaşılır hale getirmek için string formatına dönüştürdüm.
- **Kodun Anlaşılır ve Temiz Olması:** Kodun daha temiz ve anlaşılır olması için `mapping` kullanarak nesneler arası dönüşümü düzenli hale getirdim.
- **Bağımlılığı Azaltmak için Interfaceler Kullanmak:** Proje içindeki bağımlılıkları azaltmak için `interface`ler aracılığıyla esnek bir yapı oluşturdum.
- **Validasyonlar:** Aynı e-posta adresiyle birden fazla kayıt yapılmasını engellemek gibi validasyonlar ekledim.


## Yapmadıklarım:

- **BaseEntity Kullanımı:** Projeyi daha modüler ve anlaşılır hale getirmek için bir `BaseEntity` oluşturup, bu temel yapıyı mimariye entegre edebilirdim.
- **Request ve Response Sınıfları:** DTO'lar yerine `Request` ve `Response` sınıflarını kullanarak veri iletişimini daha esnek ve kontrol edilebilir hale getirebilirdim.
- **Dockerize Etme:** Projeyi Dockerize ederek daha taşınabilir ve dağıtılabilir bir hale getirebilirdim.




### API ISTEKLERI


***POST*** `/api/auth/register` = Kullanıcı kaydı oluşturur.
```
{
  "email": "selim@selim",
  "password": "selim",
  "role": "User"
}
```

***POST*** ` /api/auth/login ` =  Kullanıcı girişini sağlar ve JWT token döner.
```
{
  "email": "selim@selim",
  "password": "selim"
}
```




***POST*** ` /api/tasks ` = Kullanıcıya ait görev oluşturur.
- Authorization: Bearer Token
```
{
  "title": "Baslik Test",
  "description": "Aciklama Test",
  "frequency": "Weekly"
}
```
***POST*** `/api/auth/logout` = Kullanıcının oturumunu sonlandırır.
- Authorization: Bearer Token


***DELETE*** `/api/tasks/{taskId}`= Kullanıcıya ait görevi siler.
- Authorization: Bearer Token

## Nasıl Çalışır?

1) **Depoyu Klonlayın:**
   Projeyi yerel bilgisayarınıza klonlayın.


2) **Veritabanı Bağlantı Ayarlarını Yapın:**
   `appsettings.json` dosyasında kendi **SQL Server** ayarlarınızı yapılandırın. Eğer Windows kimlik doğrulaması kullanmıyorsanız, `User Id` ve `Password` ekleyin.

   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=YourServerName;Database=TaskManagerDB;Trusted_Connection=True;Encrypt=False;"
   }

3) **NuGet Paketlerini Yükleyin:**
   Kök dizinde terminali açın ve projede kullanılan NuGet bağımlılıklarını yüklemek için şu komutu çalıştırın: ```dotnet restore```


4) **Veritabanı Yapılandırmasını Uygulayın:**
Veritabanı migration'larını uygulamak için şu komutu çalıştırın```dotnet ef database update```


5) **Artık Başlayabiliriz:** Son olarak  ```dotnet run``` komutunu çalıştırın.





## Not: 
Eksiklerimin farkındayım. Okulda başlangıç seviyesinde C# eğitimi aldım ve kendi çabalarımla Java'da Junior seviyesine ulaştığımı düşünüyorum. C# ile Java'nın syntax'larının neredeyse aynı olması nedeniyle temel dil yapısında sorun yaşamadım. Ancak, Spring Boot ve .NET arasındaki syntax farkı beni zorladı. Yine de Spring Boot'taki mantığı bildiğim için, .NET'te onun karşılığını bularak ilerleyebildim. Programlama mantığının daha önemli olduğuna inanıyorum. Yaptığım her şeyi neden yaptığımı biliyorum ve syntax öğrenmenin işin kolay kısmı olduğunu düşünüyorum. Sizi hayal kırıklığına uğratmayacağımdan eminim.Vakit ayırdığınız için teşekkür ederim.