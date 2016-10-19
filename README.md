# Using-KMB-Modal-Login
Using KMBModalLogin popup in ASP.NET MVC Projects. 

You can use Visual Studio and download modal login automatically. For download, you can use nuget package manager. Enter KMBModalLogin to search box and just download it. 

> **PM > Install-Package [KMBModalLogin](https://www.nuget.org/packages/KMBModalLogin/)**


## How to use KMB Modal Login - Video

[![How to use KMB Modal Login - video content](https://lh3.googleusercontent.com/8Go6-APj7Ew2beQ1BKH2lv9uZF7iMZesPfGDDt-l8BUd5RIb7wxU5dY1JzEKt5jTGm_NLz4ctM5_DB-fV1lJpzP2JFjR7XDDFrnVsO8db6L3Dv9CYTxEFoREQLZ-uBmjwvPCMs-sdMCx9EzdRDvGcnAQXqvu9jMkLTh33ZcNJkf942SB6ypRjYaZ_szzdA3K9y9OSrQAjCz6VUO5HJLm2BN-UCnIVzZj4qwTJMIvSur_whTtoH21VtOjNJ5z1pTWKsyjSeC88MkhGVSUnPt7HoEcDgEj1onTsciC46upJ7_gWcvxx9JorWwt1JbTqpdzX6KktBt5BsRHBh0gqlNHo22z3NpqIpQDCtg9ZUsGAdnqx2BoYt0gIbeJB4baxzmZ9KFmDsTBToRWAg9tmRJwD0FvTYLUlg3_VTP0DTMs5wH9fOwJiwR3LxmFys77vls9Kb7qb4-iSSAaT3dqEhtrAGplD4JzoWrVywwrrE0YkKaSBcUnv7qq-fhlA32209tlzBswYeNUOrjVzlzatNiT9Z5kk98zqhzupn7noQgGUK-HbZa_CP9wRYsH9jGItwCAqfW2A-E=s454-w200-no)](https://youtu.be/Xc5QrWEdxnM "Using KMB Modal Login")

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
