# madrinathapa

# Start the services in the given order

# 1. Microservice 1 - Hello-world (node.js)
  
  Execute the commands in the given order
  
    i. npm install seneca --save
    ii. npm install express --save
    iii. npm install seneca-web --save
    iv. npm install seneca-web-adapter-express --save
    v. npm install body-parser --save
    vi. Navigate to /Assignment1/Services/hello-world
      Execute: node greet-service.js
    vii. Navigate to /Assignment1/Services/hello-world
      Execute: node index.js   

# 2. Microservice 2 - Circle (Flask with Python)

   Installations
    i. Install Python from [here](https://www.python.org/downloads/)
    ii. Install Flask from [here](http://flask.pocoo.org/docs/0.12/installation/)
    iii. Install Requests from [here](http://docs.python-requests.org/en/master/user/install/)
         pipenv install requests
    
    To run the service navigate to /Assignment1/Services/Circle-Service
    Execute: python circle.py

# 3. Microservice 3 - Square(ASP.NET Core)

  Install [ASP.NET Core 1.1](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md) . 
  
   Execute the commands in the given order
  
    i.Navigate to /Assignment1/Services/Square
      Execute: dotnet restore
    ii.Navigate to /Assignment1/Services/Square
      Execute: dotnet build
    iii.Navigate to /Assignment1/Services/Square/Square
      Execute: dotnet run

# 4. SgaApi (ASP.NET Core Web API server)
   
   Execute the commands in the given order

      i.Navigate to /Assignment1/Server/SgaApi
        Execute: dotnet restore
      ii.Navigate to /Assignment1/Server/SgaApi
        Execute: dotnet build
      iii.Navigate to /Assignment1/Server/SgaApi/SgaApi
        Execute: dotnet run

# 5 User Interface
  
   Steps involved
   
     i. Navigate to /Assignment1/UI/Application
        Open main.html

# References: 

     i.  [Getting started - Seneca](http://senecajs.org/getting-started/)
     ii. [ASP.NET Core 1.1](https://docs.microsoft.com/en-us/dotnet/core/macos-prerequisites)
     iii.[Spring Tool Suite](https://spring.io/blog/2015/03/18/spring-boot-support-in-spring-tool-suite-3-6-4)
