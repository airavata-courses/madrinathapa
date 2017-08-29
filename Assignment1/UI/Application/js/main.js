

jQuery(function ($) {
    //First service
    $( "#btnGreet" ).click(function() {
      alert("First service is called");
      var name = $("#inpName").val();

      if(name.length>1){
        var uri = "http://localhost:4099/api/greeting/"+name;
        $.getJSON(uri, function(result){
          $("#greet").html("<br/><div class='alert alert-success'>"+result.result+"</div>");
          //alert(result.result);
        });
      }
    });

    //Second Service
    $( "#btnCircle" ).click(function() {
       alert("Second Service is called");
       var radius =$("#inpCircle").val();

       if(radius.length>1){
         var uri = "http://localhost:4099/api/circle/"+radius;
         $.getJSON(uri, function(result){
           var result = "Area of a circle with radius " + result.radius + " is: " + result.area;
           $("#circle").html("<br/><div class='alert alert-success'>"+result+"</div>");
         });
       }
    });

    //Third Service
    $( "#btnSquare" ).click(function() {
      alert("Third Service is called");
      var side =$("#inpSquare").val();

      if(side.length>1){
        var uri = "http://localhost:4099/api/square/"+side;
        $.getJSON(uri, function(result){
          var result = "Area of a square with side " + result.Side + " is: " + result.Area;
          $("#square").html("<br/><div class='alert alert-success'>"+result+"</div>");
        });
      }
    });
});
