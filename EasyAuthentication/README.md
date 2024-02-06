# About EasyAuthentication : 

EasyAuthentication is the clean and realy clear authentication and authorization service.
In this project I use Clean architecture and also use MediateR, FluentValidation, AutoMapper and JWT to implement this structure.
Totally I developed it after some years of expriences and use a lots of diffrent authentication that we can use Mobile authentication and Email authentication.

## How to use : 

In the "Configurations" folder and IdentityServicesRegistration we have JwtSettings and IdentityConnectionString that they read from appsettings on your project like following codes:

```

"ConnectionStrings": {
    "IdentityConnectionString": "Data Source= <DB_IP> ; User Id = <DB_USER> ; Password = <DB_PASSWORD> ; Initial Catalog= <DB_NAME> ;TrustServerCertificate=True"
  },

  "JwtSettings": {
    "Key": "<YOUR_KEY>",
    "Issuer": "<YOUR_ISSUER>",
    "Audience": "<YOUR_AUDIENCE>",
    "DurationInMinutes": 43200//for 30 days
  },

```

Add this config to your program.cs

```
 builder.Services.AddDbContext<IdentityDbContext>(options =>
 {
     options.UseSqlServer(configuration
         .GetConnectionString("<YOUR_CONNECTIONSTRING>"), b => b.MigrationsAssembly("<YOUR_PROJECTLAYER>")); 
 }); 
```
