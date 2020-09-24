# Authenticated .Net Core 3.1 with MongoDB

## Usage:

### Registration
`http://localhost:5000/api/user/Register`

REQUEST: `POST`
```
{
    "username": "your_username",
    "password": "any_password_will_do",
    "role": "ADMIN",
    "firstName": "Full",
    "lastName": "Name",
    "streetAddress": "Your",
    "city": "Primary",
    "state": "Address",
    "zipCode": "12345"
}
```

**NOTES:** the `"role"` parameter can either be an `ADMIN` or can be left empty, `ADMINS` have elevated 

-------------

### Login
`http://localhost:5000/api/user/Login`

REQUEST: `POST`
```
{
    "username": "your_username",
    "password": "any_password_will_do"
}
```

RESPONSE (Correct Combination) `[200 Ok]`
```
{
    eyJhbGciOiJIUzI1NiIsInR5cCI6IkpX•••
}
```

RESPONSE (Wrong Combination) `[401 Unauthorized]`
```
{
    Wrong username or password
}
```

**NOTES:** the token is of type "Bearer", and the word "Bearer" must be added in the `Authorization` header field before the token.

-------------

### Accessing Sensitive Info
`http://localhost:5000/api/user/GetSenstiveData`

REQUEST: `GET`
```
{
   	
}
```

RESPONSE (Correct Combination) `[200 Ok]`
```
{
    "message": "Access as Admin Granted",
    "payload": [
        {
            "id": "b58d7368-2306-4b62-9f3f-b17c2ed4bba5",
            "firstName": "admin",
            "lastName": "user",
            "primaryAddress": {
                "id": "00000000-0000-0000-0000-000000000000",
        "streetAddress": "Your",
	    "city": "Primary",
	    "state": "Address",
	    "zipCode": "12345"
            },
            "role": "ADMIN",
            "username": "adminuser",
            "password": "1234"
        },
        {
            "id": "7b29d448-46ae-4314-ac97-d2646a002bc7",
            "firstName": "another",
            "lastName": "user",
            "primaryAddress": {
                "id": "00000000-0000-0000-0000-000000000000",
        "streetAddress": "Your",
	    "city": "Primary",
	    "state": "Address",
	    "zipCode": "12345"
            },
            "role": "",
            "username": "anotheruser",
            "password": "1234"
        }
    ]
}
```

RESPONSE (Normal User Logged In) `[403 Forbidden]`
```
{
    
}
```

RESPONSE (No logged in users) `[401 Unauthorized]`
```
{
    
}
```
