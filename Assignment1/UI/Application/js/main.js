

jQuery(function ($) {
    //First service
    $( "#btnGreet" ).click(function() {
      var name = $("#inpName").val();

      if(name.length>0){
        alert("First service is called!");
        var uri = "http://localhost:4099/api/greeting/"+name;
        $.getJSON(uri, function(result){
          $("#greet").html("<br/><div class='alert alert-success'>"+result.result+"</div>");
          //alert(result.result);
        });
      }else{
        alert("Enter the name!");
      }
    });

    //Second Service
    $( "#btnCircle" ).click(function() {
       var radius =$("#inpCircle").val();

       if(radius.length>0){
         alert("Second Service is called!");
         var uri = "http://localhost:4099/api/circle/"+radius;
         $.getJSON(uri, function(result){
           var result = "Area of a circle with radius " + result.radius + " is: " + result.area;
           $("#circle").html("<br/><div class='alert alert-success'>"+result+"</div>");
         });
       }else{
         alert("Enter radius!");
       }
    });

    //Third Service
    $( "#btnSquare" ).click(function() {
      var side =$("#inpSquare").val();
      if(side.length>0){
        alert("Third Service is called!");
        var uri = "http://localhost:4099/api/square/"+side;
        $.getJSON(uri, function(result){
          alert(result);
          var result = "Area of a square with side " + result.Side + " is: " + result.Area;
          $("#square").html("<br/><div class='alert alert-success'>"+result+"</div>");
        });
      }else{
        alert("Enter side!");
      }
    });
});
