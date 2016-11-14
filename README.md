# KMB Modal Login Kullanımı
**(for english read readme.en.md file in repository)**

![KMB Modal Login - Login Page](https://github.com/kadirmuratbaseren/Using-KMB-Modal-Login/blob/master/ReadmeFiles/04-kmb-modal-login-login-page.png?raw=true)


## Ne Sağlar?

**[Modal Login with Jquery Effects](http://bootsnipp.com/snippets/featured/modal-login-with-jquery-effects)** snippet'ının ASP.NET MVC projesi ile kullanılacak şekilde uyarlanmış halidir. **Login(giriş), register(kayıt), lost password(şifremi unuttum) pencereleri ile basit bir profil sayfası içerir. Profil güncelleme, silme işlemleri içinde gerekli ekran ve kodlamalar yapılmıştır.** 

**Şifremi unuttum** işlemlerinde iki farklı yöntem de bulunmaktadır. Birinci yöntem, şifrenin kullanıcı e-posta adresine gönderilmesidir. İkinci yöntem, şifre resetleme link'i oluşturularak kullanıcıya e-posta ile iletilerek, resetleme sayfasına yönlendirilir. 

E-posta gönderme kodları proje içinde mevcuttur. **Web.config 'den gerekli ayarların yapılması ile e-posta gönderme ve veritabanı ayarlarının yapılması yeterli olacaktır.** 

Modal Login, kendi Controller'ına sahiptir. Controller içinde gerekli kodlar yazılmıştır. Login, register ve lost password işlemleri jquery ajax işlemleri ile yapılmaktadır.


## Nasıl Kullanılır? 

![KMB Modal Login - Layout ve Partial Views](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/03-kmb-modal-login-partial-for-layout.png)

Modal Login, **partial view(ModalLoginPartial.cshtml)** olarak projenizde istediğiniz sayfada kullanılabilir yapıdadır. Ayrıca menü de kullanılmak üzere, menü linklerini içeren bir **partial view(ModalLoginMenuPartial.cshtml)** daha içerir. 

![KMB Modal Login - Layout da Bootstap ve JQuery Ayarı](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/02-kmb-modal-login-layout-page.png)

Modal Login, **Entity Framework CodeFirst ile çalışmaktadır ve veritabanı ile tablo otomatik oluşmaktadır.** İlgili Nuget paketini projenize eklendikten sonra şu adımları izleyerek gerekli ayarları arayüz ile yapabilirsiniz. **Nuget paketi projenize; Bootstrap, JQuery, Entity Framework 'ü ekleyecektir.**


## Nuget Package Manager ile Projeye Ekleme 

> Install-Package KMBModalLogin

Nuget paketi yüklendikten sonra Controllers klasörüne **"ModalLoginController"** eklenir. Gerekli action 'lar bu controller'da bulunmaktadır. Gerekli class'lar **proje altında "ModalLoginPlugin"** klasörün de bulunmaktadır. Ayrıca View'larda **Views klasörü altında "ModalLogin"** isimli klasör de bulunmaktadır. **Partial View'lar "Shared" klasöründe bulunmaktadır.**

![KMB Modal Login - Sample Page ile Kurulum ve Açıklama](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/01-kmb-modal-login-sample-page.png)

View'lardan **index.cshtml** sayfasını hemen çalıştırarak ConnectionString tanımlamanızı kolayca yapabilirsiniz. Web.config dosyası içinden kendiniz düzenlemek isterseniz, gerekli yönergeleri bu sayfa da görebilirsiniz. **Veritabanı bu sayfada gerekli connectionstring tanımını yaptıktan sonra ilk login denemesinde EF CodeFirst ile oluşturulacaktır. Örnek olarak, bir kullanıcı insert işlemi yapılmaktadır.** Yine bu sayfa da örnek kullanıcı bilgisi bulunmaktadır. Deneme için kullanabilirsiniz.

Modal Login view'larında **"ModalLoginLayout.cshtml"** kullanılmaktadır. Burada yer alan PartialView tanımlamalarına bakarak siz de projenizde istediğiniz yere gerekli Modal Login partial 'larını kullanabilirsiniz.

**Şifremi unuttum işlemleri için gerekli e-posta gönderme tanımlamaları için web.config içinde appSettings altında gerekli key'ler i düzenleyiniz.**

Modal Login 'in kullandığı javascript dosyası **Script klasörü altında modal-login.js** ismiyle bulunmaktadır. CSS kodları için **Content klasörü altında modal-login.css** dosyasından gerekli değişiklikleri yapabilirsiniz.


## Ekran Görüntüleri

Kullanıcı kayıt ve şifremi unuttum pencerelerinin ekran görüntüleri aşağıdaki şekildedir.

![KMB Modal Login - Register(kayıt) Sayfası](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/05-kmb-modal-login-register.png)

![KMB Modal Login - Lost Password(Şifremi Unuttum) Sayfası](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/06-kmb-modal-login-lost-password.png)


## Video Anlatım

Dilerseniz video'lu anlatımım ile anlatmak istediklerimi izleyebilirsiniz.

[![KMB Modal Login - Video Anlatım](https://raw.githubusercontent.com/kadirmuratbaseren/Using-KMB-Modal-Login/master/ReadmeFiles/00-kmb-modal-login-video-image.png)](https://www.youtube.com/watch?v=Xc5QrWEdxnM&t=825s)
