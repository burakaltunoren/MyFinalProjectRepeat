using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message):this(success)
        {
            Message = message;
            
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }



    // Getter'lar read-only oldukleri için constructor 'da set edilebilirler.
    // Overloading var. Aynı metodu farklı kodlarla iki defa kullandık.
}   // this " bu class 'ın kendisi demek. 2 parametre yollandığında 1. constructor zaten açlışacak ama this(success) yapısı sayesinde 1. ctro çalıştığında tek parametreli olan ctor'a da success yolla
    // eylemi olduğundan ikinci de çalışacak.
