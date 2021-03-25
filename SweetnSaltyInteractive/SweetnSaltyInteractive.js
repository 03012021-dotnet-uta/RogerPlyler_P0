let input = document.getElementById("input");
let start = document.getElementById("start");
let error = document.getElementById("error");
let reset = document.getElementById("reset");
//let game = document.getElementById("game");
let highfeild = document.getElementById("high");
let lowfeild = document.getElementById("low");
let PLfeild = document.getElementById("PL");
//Const


const SNSForm = document.getElementById('SNSform');
const Output = document.querySelector('.output');
const SNSbutton = document.querySelector('.SNSbutton');
input.style.display = "none";
function Start(){
    input.style.display = "block";
    start.style.display = "none";
    error.style.display = "none";
    reset.style.display = "none";
    PLfeild.style.display = "none";
    lowfeild.style.display = "none";
    highfeild.style.display = "block";
}

//OLD SNS When I noticed that each one has to be submitted individually

/*function SNSoutput(High,Low,PerLine) {
    High++;
    var difference = High - Low;
    var differenceLines = (difference) % PerLine;
    var times = (difference - differenceLines) /PerLine;
    var sweetCount = 0;
    var saltyCount = 0;
    var SNSCount = 0;
    var lastNum = 0;
    var out = "";
    if(difference<200){
        error.style.display = "block";
        error.innerText = "Diffrence should be greater than 200";
    }else if(difference/PerLine < 100 && PerLine < 0){
        error.style.display = "block";
        error.innerText = "Has to be above 100th the diffrence in per line";
    }else{

        error.style.display = "none";
    for(j = 0; j < times; j++){
        
        for (i = 0; i < PerLine; i++){
            var test = PerLine * j + i +parseInt(Low);
            if( test % 3 == 0 && test % 5 ==0){
                out += " Sweetn'Salty";
                SNSCount += 1;
            }else if (test % 3 == 0){
                out += ' <b class = "sweet">sweet</b>';
                sweetCount += 1;
            }else if (test % 5 == 0) {
                out += " <b class = 'salty'>salty</b>";
                saltyCount += 1;
            }else{
            out += " " + test;
            }
            lastNum = parseInt(test);
        }
        out += "<br>";
    }

    for(x = lastNum + 1 ; x < High; x++){
        if( x % 3 == 0 && x % 5 ==0){
            out += " Sweetn'Salty";
            SNSCount += 1;
        }else if (x % 3 == 0){
            out += ' <b class = "sweet">sweet</b>';
            sweetCount += 1;
        }else if (x % 5 == 0) {
            out += " <b class = 'salty'>salty</b>";
            saltyCount += 1;
        }else{
            out += " " + x;
        }
    }
    out += "<br> Salty " + saltyCount + " Sweet " + sweetCount + " SNS " + SNSCount; 
    Output.innerHTML += out + " ";
    game.style.display = "none";
    reset.style.display = "block";
    }
}
*/
//Redoing how reset works

function ResetGame(){
    Output.innerHTML = "";
    reset.style.display = "none";
    start.style.display = "block";
    error.style.display = "none";
}
var h = 0;
var l = 0;
var PL = 0;
//taking High
function HighInput(inputHigh){
    h = inputHigh;
    console.log(h);
    h++;
    highfeild.style.display = "none";
    lowfeild.style.display = "block";
}
//taking Low
function LowInput(inputLow){
    
    l = inputLow;
    if(h-l < 200){
        error.style.display = "block";
        error.innerText = "Must have a diffrence of 200 or more";
    }else{
        error.style.display = "none";
        lowfeild.style.display = "none";
        PLfeild.style.display = "block";
    }
}


function PerLineInput(inputPL) {
    PL = inputPL;
    var difference = h - l;
    var differenceLines = (difference) % PL;
    var times = (difference - differenceLines) /PL;
    var sweetCount = 0;
    var saltyCount = 0;
    var SNSCount = 0;
    var lastNum = 0;
    var out = "";
    if(difference<200){
        error.style.display = "block";
        error.innerText = "Diffrence should be greater than 200";
    }else if(difference/PL < 100 || PL <= 0){
        error.style.display = "block";
        error.innerText = "Has to be above 100th the diffrence in per line";
    }else{

        error.style.display = "none";
    for(j = 0; j < times; j++){
        
        for (i = 0; i < PL; i++){
            var test = PL * j + i +parseInt(l);
            if( test % 3 == 0 && test % 5 ==0){
                out += " Sweetn'Salty";
                SNSCount += 1;
            }else if (test % 3 == 0){
                out += ' <b class = "sweet">sweet</b>';
                sweetCount += 1;
            }else if (test % 5 == 0) {
                out += " <b class = 'salty'>salty</b>";
                saltyCount += 1;
            }else{
            out += " " + test;
            }
            lastNum = parseInt(test);
        }
        out += "<br>";
    }

    for(x = lastNum + 1 ; x < h ; x++){
        if( x % 3 == 0 && x % 5 ==0){
            out += " Sweetn'Salty";
            SNSCount += 1;
        }else if (x % 3 == 0){
            out += ' <b class = "sweet">sweet</b>';
            sweetCount += 1;
        }else if (x % 5 == 0) {
            out += " <b class = 'salty'>salty</b>";
            saltyCount += 1;
        }else{
            out += " " + x;
        }
    }
    out += "<br> Salty " + saltyCount + " Sweet " + sweetCount + " SNS " + SNSCount; 
    Output.innerHTML += out + " ";
    PLfeild.style.display = "none";
    reset.style.display = "block";
    }
}