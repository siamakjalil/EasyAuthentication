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
builder.Services.ConfigureIdentityServices(builder.Configuration);
```

## How to use AuthenticationFeatures :
``` 
// register 
await _mediator.Send(new RegisterRequest()
{
    RegisterDto = new RegisterDto()
    {
        Email = "",
        MobileNumber = "",
    }
});

// send auth code to mobile 
await _mediator.Send(new SendAuthCodeRequest()
{
    SendAuthCode = new SendAuthCode()
    {
        MobileNumber = ""
    }
});

// login by auth code
await _mediator.Send(new LoginByAuthCodeRequest()
{
    LoginByAuthCode = new LoginByAuthCode()
    {
        MobileNumber = "",
        ActivationCode = ""
    }
});

// login by pass
await _mediator.Send(new LoginByPassRequest()
{
    LoginByPass = new LoginByPass()
    {
        Email = "",
        MobileNumber = "",
        Password = ""
    }
});

// set pass 
await _mediator.Send(new SetPassRequest()
{
    SetPass = new SetPass()
    {
        UserId = Guid.Empty,
        Pass = "",
        RePass = ""
    }
});

// change pass 
await _mediator.Send(new ChangePassRequest()
{
    ChangePass = new ChangePass()
    {
        ReNewPass = "",
        NewPass = "",
        CurrentPass = "",
        UserId = Guid.Empty
    }
});
```
## How to use RoleFeatures :
```
await _mediator.Send(new GetRoleListRequest(){});
await _mediator.Send(new GetRoleRequest() { Id = 1 });
await _mediator.Send(new GetUserRolesRequest() { Id = Guid.Empty});

// add or update role
await _mediator.Send(new UpsertRoleRequest()
{
    RoleDto = new RoleDto()
    { 
        Title = "role"
    }
});

// pass roleId
await _mediator.Send(new DeleteRoleRequest(){Id = 1});
// pass userRoleId
await _mediator.Send(new DeleteRoleFromUserRequest(){Id = 1});

await _mediator.Send(new AddRoleToUserRequest(){UserId = Guid.Empty , RoleId = 1});
```

