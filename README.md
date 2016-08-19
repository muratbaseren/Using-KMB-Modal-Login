# Using-KMB-Modal-Login
Using KMBModalLogin popup in ASP.NET MVC Projects. 

You can use Visual Studio and download modal login automatically. For download, you can use nuget package manager. Enter KMBModalLogin to search box and just download it. 

*[KMB Modal Login](https://www.nuget.org/packages/KMBModalLogin/)*

The nuget package will install below files:
* Content/modal-login.css
* Scripts/modal-login.js
* Models/ModalLoginJsonResult.cs
* Models/SyaUser.cs
* Images/preferences-system-login.png
* Controllers/ModalLoginController
* **Views/Shared/_ModalLoginPartial.cshtml**
* **Views/Shared/_ModalLoginMenuItemPartial.cshtml**


İki adet partial bu işi yapmaktadır. 
Shared klasöründe layout da bunlar kullanılmaktadır. 
Kendi controller ına sahiptir.

Layout da jquery versiyonunun güncel olduğuna emin olunuz. 
