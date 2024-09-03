using CSProjeDemo2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class DosyaOku
{
    public void dosyaOku()
    {
        string json = File.ReadAllText("personel.json");
        List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Title: {person.Title}");
        }
        foreach (var item in people)
        {
            if (item.Title == "Memur")
            {
                Console.WriteLine("Çalışma Saatini Giriniz.");
                int mCalismaSaati=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Memur Kademesinizi Giriniz.");
                MemurKademesi memurKademesi = new MemurKademesi();
                Memur memur = new Memur(mCalismaSaati,memurKademesi);
            }
        }
    }
}
