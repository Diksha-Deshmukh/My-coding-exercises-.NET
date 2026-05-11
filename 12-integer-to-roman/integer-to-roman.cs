public class Solution {
    public string IntToRoman(int num) {
        if (num >= 1000){
            return "M" + IntToRoman(num - 1000);
        } else if (num >= 900){
            return "CM" + IntToRoman(num - 900);
        } else if (num >= 500){
            return "D" + IntToRoman(num - 500);
        } else if (num >= 400){
            return "CD" + IntToRoman(num - 400);
        } else if (num >= 100){
            return "C" + IntToRoman(num - 100);
        } else if (num >= 90){
            return "XC" + IntToRoman(num - 90);
        } else if (num >= 50){
            return "L" + IntToRoman(num - 50);
        } else if (num >= 40){
            return "XL" + IntToRoman(num - 40);
        } else if (num >= 10){
            return "X" + IntToRoman(num - 10);
        } else if (num >= 9){
            return "IX" + IntToRoman(num - 9);
        } else if (num >= 5){
            return "V" + IntToRoman(num - 5);
        } else if (num >= 4){
            return "IV" + IntToRoman(num - 4);
        } else if (num >= 1){
            return "I" + IntToRoman(num - 1);
        }
        return "";
    }
}