var express = require('express');
var app = express();
var path = require('path');
app.use(express.static(__dirname));

app.get('/', function(req, res){
	res.sendFile(path.join(__dirname + '/main.html'));
});

app.listen(3000, function(){
  console.log("Server is up! : 3000");
})
