# madrinathapa

# Start the services in the given order

# 1. Microservice 1 - Hello-world (node.js)
  
  Execute the commands in the given order
  
    i. npm install seneca —save
    ii. npm install express —save
    iii. npm install seneca-web —save
    iv. npm install body-parser —save
    v. Navigate to /Assignment1/Services/hello-world
      Execute: node greet-service.js
    vi. Navigate to /Assignment1/Services/hello-world
      Execute: node index.js   

# 2. Microservice 2 - Circle (Spring Boot)

   Execute the commands in the given order
  
    i.Navigate to /Assignment1/Services/Circle
      Execute: ./mvnw spring-boot:run (Run)
    ii.Navigate to /Assignment1/Services/Circle
      Execute: ./mvnw clean package (Build the JAR file)
    iii.Navigate to /Assignment1/Services/Circle
      Execute: java -jar target/Circle-0.0.1-SNAPSHOT.jar (Run the JAR file)

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
   
   
