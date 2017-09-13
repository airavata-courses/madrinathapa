# madrinathapa

# Start the services in the given order

# 1. Install RabbitMQ
  
    i. sudo apt-get update
    ii. sudo apt-get install rabbitmq-server

# 2. Microservice 1 - Hello-world (node.js)
  
  Execute the commands in the given order
  
    Navigate to /Assignment1/Services/hello-world
      i. npm install
      ii. npm install amqplib
      iii.node main.js   
      
# 3. Microservice 2 - Circle-Servie (Python)

   Installations
    
       i. Install Python from [here](https://www.python.org/downloads/)
       ii. pip install amqplib
       iii. Install Requests from [here](http://docs.python-requests.org/en/master/user/install/)
            pipenv install requests
 
       To run the service navigate to: /Assignment1/Services/Circle-Service
       Execute: python circleRabbitMQ.py
 
# 4. Microservice 3 - Square-Service(ASP.NET Core)

  Install [ASP.NET Core 1.1](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md) . 
  
   Execute the commands in the given order
  
    i.Navigate to /Assignment1/Services/Square-Service
      Execute: dotnet restore
    ii.Navigate to /Assignment1/Services/Square-Service
      Execute: dotnet build
    iii.Navigate to /Assignment1/Services/Square-Service
      Execute: dotnet run

# 5. SgaApi (ASP.NET Core Web API server)
   
   Execute the commands in the given order

      i.Navigate to /Assignment1/Server/SgaApi
        Execute: dotnet restore
      ii.Navigate to /Assignment1/Server/SgaApi
        Execute: dotnet build
      iii.Navigate to /Assignment1/Server/SgaApi/SgaApi
        Execute: dotnet run

# 6. User Interface
  
   Steps involved
   
     i. Navigate to /Assignment1/UI/Application
        Open main.html

# References: 
   i.  [Getting started - Seneca](http://senecajs.org/getting-started/)

   ii. [ASP.NET Core 1.1](https://docs.microsoft.com/en-us/dotnet/core/macos-prerequisites)

   iii.[Spring Tool Suite](https://spring.io/blog/2015/03/18/spring-boot-support-in-spring-tool-suite-3-6-4)

   iv. [RabbitMQ Tutorial](https://github.com/rabbitmq/rabbitmq-tutorials)
