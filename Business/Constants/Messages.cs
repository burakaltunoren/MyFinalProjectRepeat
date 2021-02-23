using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages                                    
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımdadır";
        public static string ProductsListed = "Ürünler Listelendi";
    }


    // bu sabit ve basit bir mesaj içeren class ve new'lemeyeceğiz o nedenle "static" ifadesi eklendi
}   // ProductAdded ve ProductNameInvalid bir değişken olmasına rağmen büyük harfle başladık. Çünkü public. public dğşknler PascalCase yazılır.
    // temel mesajlarımızı bu class'a koyuyoruz.
