# Authenticated .Net Core 3.1 with MongoDB

This mini-app uses the most common MongoDB actions through it's official driver, the app is locked down using JWT authorization (Bearer Tokens), all actions must be done via a registered account that acquired a Bearer token through it's login.

There are two types of users in this simple project, Regular users and Admins, their actions are accessible via the two endpoints `/user` and `/admin`.

## Summary:
**Users:**
- Has no particular roles
- Can Register
- Can Login to retrieve a Bearer Token
- Can update their own "FirstName"
    - *(For the sake of simplicity, only modifying FirstNames are available for now, other features would take a similar approach so no need to add them)*

**Admins:**
- Has the role "ADMIN"
- Can access and modify "Sensitive Info" like:
    - Getting all users
    - Deleting a user through its "username"
    - Deleting all users (including self)

## Usage: (1) Regular Users

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

### Update "FirstName"
`http://localhost:5000/api/user/UpdateFirstName?NewFirstName=xyz`

REQUEST: `PUT`

RESPONSE (Correct Combination) `[200 Ok]`
```
{
    "payload": "Account 'adminuser' has been successfully updated, new firstname: xyz.."
}
```

-------------
## Usage: (2) Admins

### Accessing Sensitive Info
`http://localhost:5000/api/user/GetAllUsers`

REQUEST: `GET`

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

RESPONSE (No logged in users) `[401 Unauthorized]`

### Deleting all users
`http://localhost:5000/api/admin/DeleteAllUsers`

REQUEST: `DELETE`

RESPONSE (Correct Combination) `[200 Ok]`
```
{
    "message": "Access as Admin Granted",
    "payload": "All users where deleted, you need to create a new account."
}
```

RESPONSE (Normal User Logged In) `[403 Forbidden]`

RESPONSE (No logged in users) `[401 Unauthorized]`

### Deleting a single user
`http://localhost:5000/api/admin/DeleteUser?userId=7b29d448-46ae-4314-ac97-d2646a002bc7`

REQUEST: `DELETE`

RESPONSE (Correct Combination) `[200 Ok]`
```
{
    "message": "Access as Admin Granted",
    "payload": "Account accountName Deleted Successfully.."
}
```

RESPONSE `[404 NotFound]`
```
{
    "message": "Access as Admin Granted",
    "payload": "Specified user was not found.."
}
```

RESPONSE (Normal User Logged In) `[403 Forbidden]`

RESPONSE (No logged in users) `[401 Unauthorized]`