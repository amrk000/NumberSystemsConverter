// Number Systems Converter by Amrk000
#include<iostream>
#include<cmath>
#include<string>
#include<sstream>
using namespace std;

class Converter {
private:
    int bits;

    string decimalToBase(string number, int base) {

        bool negative = false;

        if (number.at(0) == '-') {
            number = number.substr(1);
            negative = true;
        }

        string output;

        long numberL;
        stringstream stringToNum;
        stringToNum << number;
        stringToNum >> numberL;

        while (numberL != 0) {

            switch (numberL % base) {
            case 10:
                output.append("A");
                break;

            case 11:
                output.append("B");
                break;

            case 12:
                output.append("C");
                break;

            case 13:
                output.append("D");
                break;

            case 14:
                output.append("E");
                break;

            case 15:
                output.append("F");
                break;

            case 16:
                output.append("G");
                break;

            case 17:
                output.append("H");
                break;

            case 18:
                output.append("I");
                break;

            case 19:
                output.append("J");
                break;

            case 20:
                output.append("K");
                break;

            case 21:
                output.append("L");
                break;

            case 22:
                output.append("M");
                break;

            case 23:
                output.append("N");
                break;

            case 24:
                output.append("O");
                break;

            case 25:
                output.append("P");
                break;

            case 26:
                output.append("Q");
                break;

            case 27:
                output.append("R");
                break;

            case 28:
                output.append("S");
                break;

            case 29:
                output.append("T");
                break;

            case 30:
                output.append("U");
                break;

            case 31:
                output.append("V");
                break;

            case 32:
                output.append("W");
                break;

            case 33:
                output.append("X");
                break;

            case 34:
                output.append("Y");
                break;

            case 35:
                output.append("Z");
                break;

            default: output.append(to_string(numberL % base));
            }
            numberL = numberL / base;
        }

        reverse(output.begin(), output.end());

        if (negative) return convert(nigativeBinaryTwosComp(convert(FillDigits(output, base), base, 2)), 2, base);
        else return FillDigits(output, base);
    }

    string baseToDecimal(string number, int base) {

        reverse(number.begin(), number.end());

        long decimal = 0;
        int counter = 0;
        int digit;
        long convert;
        int value;

        while (counter < number.length()) {

            switch (toupper(number.at(counter))) {
            case 'A':
                value = 10;
                break;
            case 'B':
                value = 11;
                break;
            case 'C':
                value = 12;
                break;
            case 'D':
                value = 13;
                break;
            case 'E':
                value = 14;
                break;
            case 'F':
                value = 15;
                break;
            case 'G':
                value = 16;
                break;
            case 'H':
                value = 17;
                break;
            case 'I':
                value = 18;
                break;
            case 'J':
                value = 19;
                break;
            case 'K':
                value = 20;
                break;
            case 'L':
                value = 21;
                break;
            case 'M':
                value = 22;
                break;
            case 'N':
                value = 23;
                break;
            case 'O':
                value = 24;
                break;
            case 'P':
                value = 25;
                break;
            case 'Q':
                value = 26;
                break;
            case 'R':
                value = 27;
                break;
            case 'S':
                value = 28;
                break;
            case 'T':
                value = 29;
                break;
            case 'U':
                value = 30;
                break;
            case 'V':
                value = 31;
                break;
            case 'W':
                value = 32;
                break;
            case 'X':
                value = 33;
                break;
            case 'Y':
                value = 34;
                break;
            case 'Z':
                value = 35;
                break;
            default:
                value = 0;
                break;
            }

            if (value == 0)
                digit = number.at(counter) - '0';
            else
                digit = value;

            convert = pow(base, counter);

            decimal += digit * convert;

            counter++;

        }

        return to_string(decimal);
    }

    //takes and returns only binary
    string nigativeBinaryTwosComp(string binary) {

        string output;
        for (int i = 0; i < binary.length(); ++i)
        {
            if (binary.at(i) == '0') output += "1";
            else output += "0";
        }

        long decimal;
        stringstream stringToNum;
        stringToNum << baseToDecimal(output, 2);
        stringToNum >> decimal;

        decimal += 1;

        output = decimalToBase(to_string(decimal), 2);

        return output;
    }

    string FillDigits(string number, int base) {
        if (base == 10) return number;

        int totalDigits = 4;
        if (base == 8) totalDigits = (int)ceil(4 / 3.0);
        else if (base == 16) totalDigits = 1;

        int blocks = bits / 4;

        totalDigits *= blocks; //set blocks limit

        int extrabitsCount = totalDigits - (number.length() % totalDigits);
        string extrabits;

        if (number.length() != totalDigits) for (int i = 0; i < extrabitsCount; ++i) extrabits.append("0");

        return  extrabits + number;
    }

    string decimalRangeShifter(string d) {
        long unsignedmaxvalue = pow(2, bits) - 1;
        long signedmaxvalue = (unsignedmaxvalue - 1) / 2;
        long signedminvalue = (unsignedmaxvalue - signedmaxvalue) * -1;

        long decimal;
        stringstream stringToNum;
        stringToNum << d;
        stringToNum >> decimal;

        if (decimal > signedmaxvalue) return to_string((unsignedmaxvalue + 1 - decimal) * -1);
        else return to_string(decimal);
    }

public:
    Converter(int bits) {
        this->bits = bits;
    }

    Converter() {
        this->bits = 64;
    }

    string convert(string number, int fromBase, int toBase) {
        try {
            if (fromBase == toBase) return FillDigits(number, toBase);
            else if (toBase == 10) return decimalRangeShifter(baseToDecimal(number, fromBase));
            else if (fromBase == 10) return decimalToBase(number, toBase);
            else return decimalToBase(baseToDecimal(number, fromBase), toBase);
        }
        catch (exception e) {
            return "Conversion Error!";
        }
    }

    void setBits(int bits) {
        this->bits = bits;
    }

    int getBits(int bits) {
        return bits;
    }
};

int main() {
    Converter converter(16);
    cout << converter.convert("ffff",16,8)<<endl;
}
