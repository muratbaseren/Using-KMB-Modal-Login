# Using-KMB-Modal-Login
Using KMBModalLogin popup in ASP.NET MVC Projects. 

| Build server| Platform       | Status      |
|-------------|----------------|-------------|
| AppVeyor    | Windows        |[![Build status](https://ci.appveyor.com/api/projects/status/9cqwlv6cx24u14la/branch/master?svg=true)](https://ci.appveyor.com/project/muratbaseren/using-kmb-modal-login/branch/master) |

You can use Visual Studio and download modal login automatically. For download, you can use nuget package manager. Enter KMBModalLogin to search box and just download it. 

> **PM > Install-Package [KMBModalLogin](https://www.nuget.org/packages/KMBModalLogin/)**


## How to use KMB Modal Login - Video

[![How to use KMB Modal Login - video content](https://lh3.googleusercontent.com/WkIgFj9NMcUqmM6mRw_tRXzwenYvQemdbt-pd41HlKfgX7jfuwuVssjUf73TTbnVJbZstKgXhj5b8GjkoXH2xypKix6M36SZYgqzLs6mC5HTM5hte5xQFYvk1it0Ari4IEmKM9MP1ahLHjGbTto4VaMTiwHupMIXU5Pr9zHrvDIGv1eGjT9xoMgw3Fix-_cgFbt8iAxVxYjrzu-jVTIXnwFXEZc7znP_npd1YNbpjo5B8OxUqnvnvIAnEFImYS8slzZstrgil9k2jwUlToDx9YBThweO9e6nWHNCKW4l775t7V8siaMdqoq1RjXtePB4-8tclptwnIUfAcMMYtbatpRNht3SW_i_s01UcifrlMyQVNcM33aKJFCkyT04c1qvkc7ykV8ul9MJSfVX2hZM7m-vQ3RDWtKdKjJ90CCaa3a7gQtXHDS_50OxJD1z2E2alVgDCSKOKquG5pRKlQ28MKGHzs99sgspQKGRU5OgDI_tQBfuYW8wzS4SynMRX3rMxzDprQad8YMsatBbqHrVOc60IA57qWedY-lY8Ke56neNuxxdSvglDzzyJ7he1QhUs7YnH4MeVxlAoLN0rFapxPHLierR_cLSBOetA6Dgl7qNGNVh=w250-no)](https://youtu.be/Xc5QrWEdxnM "Using KMB Modal Login")

## **You can start quickly with "/Views/KmbLogin/Index" page**

This page provides required configuration.. **KmbLoginController.cs** includes **Entity Framework - CodeFirst** codes. So sample database is going to create automatically but it require to set connectionstring in web.config by your Microsoft SQL Server. You can set quickly web.config with **KmbLogin/Index** page that is in Views folder. Also, sample user is going to insert to database automatically when database created. **KmbLogin/Index page has all information and configuration for you.**


#### KmbLogin/Index Page

![KmbLogin/Index Page](http://goo.gl/d9RNxz)

> **Use links for test on right-top corner. If you set web.config with Index page then logged user suddenly can be logout. Because web.config has changed and web application session can clear. After that it runs correctly.**

## Sample Layout

You can use quickly **_ModalLoginMenuItemPartial.cshtml** partial view that shows **SignIn** and **SignUp** links.
KmbLayout that in shared folder, has two partials.

> **You can sure using JQuery(>=2.2.4), Bootstrap(>=3.3.0) and EntityFramework(>=6.1.3) to Project**  


#### Adding Scripts to Head Block on KmbLayout

![Adding Scripts to Head Block on KmbLayout](http://goo.gl/a32GQl)


#### Adding Partials to KmbLayout

![Adding Partials to KmbLayout](http://goo.gl/gqE597)


## Login Screen

For login your user(s) in website.

![KMBModalLogin Login Screen](https://goo.gl/rre4Px)


## SignUp/Register Screen

For register your new user(s) in website.

![KMBModalLogin SignUp-Register Screen](https://goo.gl/bEyp7O)


## Lost Password Screen

Remember Password for lost password of user(s) in website.

![KMBModalLogin Lost Password Screen](https://goo.gl/xaA5iN)
