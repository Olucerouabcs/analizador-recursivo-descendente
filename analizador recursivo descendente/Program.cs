using System;

class RecursiveDescentParser
{
    private string input;
    private int index;

    public RecursiveDescentParser(string input)
    {
        this.input = input;
        this.index = 0;
    }

    // Función principal para analizar la gramática
    public bool Parse()
    {
        bool result = A();
        if (result && index == input.Length)
        {
            Console.WriteLine("La cadena es válida según la gramática.");
            return true;
        }
        else
        {
            Console.WriteLine("La cadena no es válida según la gramática.");
            return false;
        }
    }

    // Funciones auxiliares para cada símbolo no-terminal de la gramática
    private bool A()
    {
        if (B() && C())
        {
            return true;
        }
        else if (C() && D())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool B()
    {
        if (Da())
        {
            return true;
        }
        else if (Match('b'))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool D()
    {
        if (Match("dd"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool C()
    {
        if (Match('c') && C() && A())
        {
            return true;
        }
        else
        {
            return true; // producción vacía
        }
    }

    // Funciones para emparejar terminales
    private bool Da()
    {
        return Match('d') && Match('a');
    }

    private bool Match(char c)
    {
        if (index < input.Length && input[index] == c)
        {
            index++;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Match(string s)
    {
        if (index + s.Length <= input.Length && input.Substring(index, s.Length) == s)
        {
            index += s.Length;
            return true;
        }
        else
        {
            return false;
        }
    }
}

// Ejemplo de uso
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese una cadena: ");
        string input = Console.ReadLine();
        RecursiveDescentParser parser = new RecursiveDescentParser(input);
        parser.Parse();

        Console.ReadKey();
    }
}