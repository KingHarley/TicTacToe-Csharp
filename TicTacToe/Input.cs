using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal static class Input
    {
        private static string? ReadInput() =>
            Console.ReadLine();

        private static bool TryConvertInputToField(string? input, out Field? field)
        {
            field = input switch
            {
                "A1" => new Field(0, 0),
                "A2" => new Field(1, 0),
                "A3" => new Field(2, 0),
                "B1" => new Field(0, 1),
                "B2" => new Field(1, 1),
                "B3" => new Field(2, 1),
                "C1" => new Field(0, 2),
                "C2" => new Field(1, 2),
                "C3" => new Field(2, 2),
                _ => null
            };
            return field != null;
        }

        private static void PromptForInput() =>
            Console.WriteLine("Please choose your move! e.g. A2, B3 etc...");


        public static Field GetInputField(Field[] possibleMoves)
        {
            var gotValidField = false;
            Field? field = null;
            while(gotValidField != true)
            {
                PromptForInput();
                var input = ReadInput();
                var gotField = TryConvertInputToField(input, out field);
                gotValidField = gotField && field != null && possibleMoves.Any(m => m.Column == field.Column && m.Row == field.Row);
                if (!gotValidField)
                    Console.WriteLine($"{input} is not an acceptable field that is open: A1 - C3");
            }

            if (field == null)
                throw new Exception($"We did not get a field even though we expected to have one");
            return field;
        }
    }
}
