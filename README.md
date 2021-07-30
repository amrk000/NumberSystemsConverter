# Number Systems Converter
Number Systems Converter Class for C++, Java &amp; C#. Supports bits setting, negative numbers &amp; all bases up to 36.

# Usage:

### C++
```c++
int main() {
    Converter converter(16); //create object & set bits
    cout << converter.convert("ffff",16,10) <<endl; //convert from hex to decimal
    cout << converter.convert("65",8,2) <<endl; //convert from octal to binary
    
    converter.setBits(8); //change bits to 8
    cout << converter.convert("ff",16,2) <<endl; //convert from hex to binary
    
    converter.setBits(converter.getBits()/2); //reduce bits by half
    cout << converter.convert("ffff",2,10) <<endl; //convert from binary to decimal
}
```
</hr>

### Java

```java

public class Main {

    public static void main(String[] args) {
        Converter converter = new Converter(16); //create object & set bits
        System.out.println(converter.convert("ffff",16,10)); //convert from hex to decimal
        System.out.println(converter.convert("65",8,2)); //convert from octal to binary
        
        converter.setBits(8); //change bits to 8
        System.out.println(converter.convert("ff",16,2)); //convert from hex to binary
         
        converter.setBits(converter.getBits()/2); //reduce bits by half
        System.out.println(converter.convert("ffff",2,10)); //convert from binary to decimal
          
    }
}
```

</hr>

### C#

```c#
 static void Main(string[] args){
          Converter c = new Converter(16); //create object & set bits
          Console.WriteLine(converter.convert("ffff",16,10)); //convert from hex to decimal
          Console.WriteLine(converter.convert("65",8,2)); //convert from octal to binary
          
          converter.setBits(8); //change bits to 8
          Console.WriteLine(converter.convert("ff",16,2)); //convert from hex to binary
          
          converter.setBits(converter.getBits()/2); //reduce bits by half
          Console.WriteLine(converter.convert("ffff",2,10)); //convert from binary to decimal
             
}
```


