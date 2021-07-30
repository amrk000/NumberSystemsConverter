// Number Systems Converter by Amrk000
using System;

class Converter
{
    int bits;

    string decimalToBase(string number, int b)
    {
        
        bool negative = false;

        if (number[0] == '-')
        {
            number = number.Substring(1);
            negative = true;
        }

        string output = new string("");

        long numberL= long.Parse(number);

        while (numberL != 0)
        {

            switch (numberL % b)
            {
                case 10:
                    output+="A";
                    break;

                case 11:
                    output += "B";
                    break;

                case 12:
                    output += "C";
                    break;

                case 13:
                    output += "D";
                    break;

                case 14:
                    output += "E";
                    break;

                case 15:
                    output += "F";
                    break;

                case 16:
                    output += "G";
                    break;

                case 17:
                    output += "H";
                    break;

                case 18:
                    output += "I";
                    break;

                case 19:
                    output += "J";
                    break;

                case 20:
                    output += "K";
                    break;

                case 21:
                    output += "L";
                    break;

                case 22:
                    output += "M";
                    break;

                case 23:
                    output += "N";
                    break;

                case 24:
                    output += "O";
                    break;

                case 25:
                    output += "P";
                    break;

                case 26:
                    output += "Q";
                    break;

                case 27:
                    output += "R";
                    break;

                case 28:
                    output += "S";
                    break;

                case 29:
                    output += "T";
                    break;

                case 30:
                    output += "U";
                    break;

                case 31:
                    output += "V";
                    break;

                case 32:
                    output += "W";
                    break;

                case 33:
                    output += "X";
                    break;

                case 34:
                    output += "Y";
                    break;

                case 35:
                    output += "Z";
                    break;

                default: 
                    output+=(numberL % b).ToString();
                    break;
            }
            numberL = numberL / b;
        }

        char[] arr = output.ToCharArray();
        Array.Reverse(arr);
        output = new string(arr);

        if (negative) return convert(nigativeBinaryTwosComp(convert(FillDigits(output, b), b, 2)), 2, b);
        else return FillDigits(output, b);
    }

    string baseToDecimal(string number, int b)
    {
        char[] arr = number.ToCharArray();
        Array.Reverse(arr);
        number = new string(arr);

        number.ToUpper();

        long dec = 0;
        int counter = 0;
        int digit;
        long convert;
        int value;

        while (counter < number.Length)
        {

            switch (number[counter])
            {
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
                digit = int.Parse(number[counter].ToString());
            else
                digit = value;

            convert = (long) Math.Pow(b, counter);

            dec += digit * convert;

            counter++;

        }

        return dec.ToString();
    }

    //takes and returns only binary
    string nigativeBinaryTwosComp(string binary)
    {

        string output = new string("");
        for (int i = 0; i < binary.Length; ++i)
        {
            if (binary[i] == '0') output += "1";
            else output += "0";
        }

        long dec = long.Parse(baseToDecimal(output, 2));

        dec += 1;

        output = decimalToBase(dec.ToString(), 2);

        return output;
    }

    string FillDigits(string number, int b)
    {
        if (b == 10) return number;

        int totalDigits = 4;
        if (b == 8) totalDigits = (int) Math.Ceiling(4 / 3.0);
        else if (b == 16) totalDigits = 1;

        int blocks = bits / 4;

        totalDigits *= blocks; //set blocks limit

        int extrabitsCount = totalDigits - (number.Length % totalDigits);
        string extrabits = new string("");

        if (number.Length != totalDigits) for (int i = 0; i < extrabitsCount; ++i) extrabits+="0";

        return extrabits + number;
    }

    string decimalRangeShifter(string d)
    {
        long unsignedmaxvalue = (long)Math.Pow(2, bits) - 1;
        long signedmaxvalue = (unsignedmaxvalue - 1) / 2;
        long signedminvalue = (unsignedmaxvalue - signedmaxvalue) * -1;

        long dec = long.Parse(d);

        if (dec > signedmaxvalue) return ((unsignedmaxvalue + 1 - dec) * -1).ToString();
        else return dec.ToString();
    }

    public Converter(int bits)
    {
        this.bits = bits;
    }

    public Converter()
    {
        this.bits = 64;
    }

    public string convert(string number, int fromBase, int toBase)
    {
       try
        {
            if (fromBase == toBase) return FillDigits(number, toBase);
            else if (toBase == 10) return decimalRangeShifter(baseToDecimal(number, fromBase));
            else if (fromBase == 10) return decimalToBase(number, toBase);
            else return decimalToBase(baseToDecimal(number, fromBase), toBase);
        }
       catch (Exception e)
        {
           return "Conversion Error!\n" + e.Message;
        }
    }

    public void setBits(int bits)
    {
        this.bits = bits;
    }

    public int getBits(int bits)
    {
        return bits;
    }

}

