console.log("WHYYYYY");
var output = "";
for (var a = 0; a < 10; a++) {
    for (var b = 0; b < 10; b++) {
        output = "";
        for (var c = 1; c <= 10; c++) {
            var i = a * 100 + b * 10 + c ;
            if(i%3 == 0 && i%5 == 0)
            {
                output += " Fizzbuzz";
            }else if(i % 3 == 0){
                output += " Fizz";
            }else if(i % 5 == 0){
                output += " Buzz";
            }else{
                output += " " + i;
            }
        }
        console.log(output);
    }
}
console.log("out of for loops");