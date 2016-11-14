# KMB Modal Login Kullanımı
**(for english read readme.en.md file in repository)**

**[Modal Login with Jquery Effects](http://bootsnipp.com/snippets/featured/modal-login-with-jquery-effects)** snippet'ının ASP.NET MVC projesi ile kullanılacak şekilde uyarlanmış halidir. **Login(giriş), register(kayıt), lost password(şifremi unuttum) pencereleri ile basit bir profil sayfası içerir. Profil güncelleme, silme işlemleri içinde gerekli ekran ve kodlamalar yapılmıştır.** 

**Şifremi unuttum** işlemlerinde iki farklı yöntem de bulunmaktadır. Birinci yöntem, şifrenin kullanıcı e-posta adresine gönderilmesidir. İkinci yöntem, şifre resetleme link'i oluşturularak kullanıcıya e-posta ile iletilerek, resetleme sayfasına yönlendirilir. 

E-posta gönderme kodları proje içinde mevcuttur. **Web.config 'den gerekli ayarların yapılması ile e-posta gönderme ve veritabanı ayarlarının yapılması yeterli olacaktır.** 

Modal Login, kendi Controller'ına sahiptir. Controller içinde gerekli kodlar yazılmıştır. Login, register ve lost password işlemleri jquery ajax işlemleri ile yapılmaktadır.

Modal Login, **partial view(ModalLoginPartial.cshtml)** olarak projenizde istediğiniz sayfada kullanılabilir yapıdadır. Ayrıca menü de kullanılmak üzere, menü linklerini içeren bir **partial view(ModalLoginMenuPartial.cshtml)** daha içerir.

Modal Login, **Entity Framework CodeFirst ile çalışmaktadır ve veritabanı ile tablo otomatik oluşmaktadır.** İlgili Nuget paketini projenize ekledikten sonra şu adımları izleyerek gerekli ayarları arayüz ile yapabilirsiniz.

> Install-Package KMBModalLogin

Nuget paketi yüklendikten sonra Controllers klasörüne **"ModalLoginController"** eklenir. Gerekli action 'lar bu controller'da bulunmaktadır. Gerekli class'lar **proje altında "ModalLoginPlugin"** klasörün de bulunmaktadır. Ayrıca View'larda **Views klasörü altında "ModalLogin"** isimli klasör de bulunmaktadır. **Partial View'lar "Shared" klasöründe bulunmaktadır.**

View'lardan **index.cshtml** sayfasını hemen çalıştırarak ConnectionString tanımlamanızı kolayca yapabilirsiniz. Web.config dosyası içinden kendiniz düzenlemek isterseniz, gerekli yönergeleri bu sayfa da görebilirsiniz. **Veritabanı bu sayfada gerekli connectionstring tanımını yaptıktan sonra ilk login denemesinde EF CodeFirst ile oluşturulacaktır. Örnek olarak, bir kullanıcı insert işlemi yapılmaktadır.** Yine bu sayfa da örnek kullanıcı bilgisi bulunmaktadır. Deneme için kullanabilirsiniz.

Modal Login view'larında **"ModalLoginLayout.cshtml"** kullanılmaktadır. Burada yer alan PartialView tanımlamalarına bakarak siz de projenizde istediğiniz yere gerekli Modal Login partial 'larını kullanabilirsiniz.

**Şifremi unuttum işlemleri için gerekli e-posta gönderme tanımlamaları için web.config içinde appSettings altında gerekli key'ler i düzenleyiniz.**

Modal Login 'in kullandığı javascript dosyası **Script klasörü altında modal-login.js** ismiyle bulunmaktadır. CSS kodları için **Content klasörü altında modal-login.css** dosyasından gerekli değişiklikleri yapabilirsiniz.
