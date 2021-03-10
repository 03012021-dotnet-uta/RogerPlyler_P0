using System;

namespace SaltySweet
{
    class Program
    {
        static int sweetCount = 0;
        static int saltyCount = 0;
        static int snsCount = 0;
        static int sweet = 3;
        static int salty = 5;
        static string sweetText = "sweet ";
        static string saltyText = "salty ";
        static string snsText = "sweet'nSalty ";
        static void Main(string[] args)
        {

            SNSCheck(sweet,salty,sweetText,saltyText,snsText);
            printSweet(sweetText,sweetCount);
            printSweet(saltyText,saltyCount);
            printSweet(snsText,snsCount);
            
        }

        static void SNSCheck(int sweet,int salty, string sweetText,string saltyText,string snsText){

            //hundreds
                for(int b = 0; b < 10; b++){
            //tens
                    for(int c = 0; c < 10; c++){
            //ones
                        for(int d = 1;d<=10; d++){
                            var test = b*100 + c*10 + d;
                            if( test % sweet == 0 && test % salty == 0){
                                Console.Write(snsText);
                                snsCount += 1;
                            }else if (test % sweet == 0){
                                Console.Write(sweetText);
                                sweetCount += 1;
                            }else if (test % salty == 0){
                                saltyCount += 1;
                                Console.Write(saltyText);
                            }else{
                                Console.Write(test + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
        }

        static void printSweet(string countText, int countNum){
            Console.WriteLine(countText +"Count: " + countNum);
        }
    }
}
// Print the numbers 1 to 1000 to the console. 
// Print them in groups of 10 per line with a space separating each number.  
// When the number is multiple of three, print “sweet” instead of the number on the console.  
// If the number is a multiple of five, print “salty” (instead of the number) to the console.  
// For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).  
// After the numbers have all been printed, print out how many sweet’s, how many salty’s, and how many sweet’nSalty’s. These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa). 
// Include verbose commentary in the source code to tell me what each few lines are doing. 
// The coding Challenge is due by midnight, today, 03.10.21. 
// Push the “compilable” source code to your P0 repo. 
