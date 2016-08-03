# IdentityServer4

This is an implementation of IdentityServer4 on asp.core using all the newsest tools and frameworks.


## How to run

Run `net restore`


In Visual Studio use command kestrel from project.json file:
```json
"commands": {
    "web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.Kestrel --server.urls http://localhost:5000;https://localhost:5001",
    "kestrel": "Microsoft.AspNet.Server.Kestrel --server.urls http://localhost:5000;https://localhost:5001",
    "run-socket": "Microsoft.AspNet.Server.Kestrel --server.urls http://unix:/tmp/kestrel-test.sock"
  }
```

## Dependencies

1. Asp.Core
2. IdentityServer4
3. Bootstrap 4
