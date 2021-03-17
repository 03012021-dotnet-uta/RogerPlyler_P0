console.log("WHYYYYY");
var sweet = 0;
var salty = 0;
var sns = 0;
var output = "";
for (var a = 0; a < 10; a++) {
    for (var b = 0; b < 10; b++) {
        output = "";
        for (var c = 1; c <= 10; c++) {
            var i = a * 100 + b * 10 + c ;
            if(i%3 == 0 && i%5 == 0)
            {
                output += " Saltyn'Sweet";
                sns = sns + 1;
            }else if(i % 3 == 0){
                output += " Sweet";
                sweet = sweet + 1;
            }else if(i % 5 == 0){
                output += " Salty";
                salty = salty + 1;
            }else{
                output += " " + i;
            }
        }
        console.log(output);
    }
}
console.log("Salty " + salty + " Sweet " + sweet + " Sweet n Salty " + sns);