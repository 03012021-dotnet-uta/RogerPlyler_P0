let input = document.getElementById("input");
let start = document.getElementById("start");
let error = document.getElementById("error");
let reset = document.getElementById("reset");
let game = document.getElementById("game");
input.style.display = "none";
function Start(){
    input.style.display = "block";
    start.style.display = "none";
    error.style.display = "none";
    reset.style.display = "none";
    
}
const SNSForm = document.getElementById('SNSform');
const Output = document.querySelector('.output');
const SNSbutton = document.querySelector('.SNSbutton');
function SNSoutput(High,Low,PerLine) {
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

function ResetGame(){
    Output.innerHTML = "";
    reset.style.display = "none";
    game.style.display = "block";
    error.style.display = "none";
}